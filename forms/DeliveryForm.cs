using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace ISDP_AlexanderK.forms
{
    public partial class DeliveryForm : Form
    {
        private bool canDelivery = false;
        private bool canMoveInventory = false;
        private string currentRoute = "";
        private string dateFormat = "yyyy-MM-dd";
        private DBConnection dbCon = new DBConnection();
        private User user = new User();

        public DeliveryForm(User userVar)
        {
            user = userVar;

            foreach (string permission in user.Permissions)
            {
                if (permission == "DELIVERY")
                    canDelivery = true;
                if (permission == "MOVEINVENTORY")
                    canMoveInventory = true;
            }

            InitializeComponent();
        }

        private void btnDeliver_Click(object sender, EventArgs e)
        {
            if (canDelivery)
            {
                bool canDeliver = false;
                string location = currentRoute.Split('-')[1];

                ArrayList orderIDs = new ArrayList();

                for (int i = 0; i < dgvOrders.Rows.Count; i++)
                {
                    if (dgvOrders.Rows[i].Cells[5].Value.ToString().Equals(location))
                    {
                        canDeliver = true;
                        orderIDs.Add(dgvOrders.Rows[i].Cells[0].Value);
                    }
                }

                if (canDeliver)
                {
                    MySqlCommand updateStatus = new MySqlCommand($"UPDATE txn tx, deliverytxns dtx SET tx.txnStatus = 'DELIVERED' " +
                        $"WHERE tx.txnID = dtx.txnID AND dtx.deliveryID = {txtDeliveryID.Text} " +
                        $"and originalLocationID = '{location}'", dbCon.Connection);
                    updateStatus.ExecuteNonQuery();
                    updateStatus.Dispose();

                    for (int i = 0; i < orderIDs.Count; i++)
                    {
                        new Audit("Order Delivered", user.UserID, orderIDs[i].ToString(), $"Order {orderIDs[i]} Status changed to DELIVERED");
                    }
                }
                else
                    MessageBox.Show($"All orders for this location have already been delivered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PopulateDGV("Orders");
                CheckButtons();
            }
            else
                MessageBox.Show($"No permission to deliver.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPickup_Click(object sender, EventArgs e)
        {
            int index = dgvOrders.SelectedRows[0].Index;

            InTransit();
            PopulateDGV("Orders");
            CheckButtons();

            dgvOrders.Rows[index].Selected = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateDGV("Delivery");
            PopulateDGV("Orders");
            CurrentRoute();
            PopulateDetails();
            CheckButtons();
        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            if (canDelivery)
            {
                if (currentRoute == "")
                {
                    MySqlCommand updateDetail = new MySqlCommand($"UPDATE delivery set details = '{lstRoutes.Items[0]}' where deliveryID = '{txtDeliveryID.Text}'", dbCon.Connection);
                    updateDetail.ExecuteNonQuery();
                    updateDetail.Dispose();
                }
                else
                {
                    string newRoute = lstRoutes.Items[lstRoutes.Items.IndexOf(currentRoute) + 1].ToString();
                    MySqlCommand updateDetail = new MySqlCommand($"UPDATE delivery set details = '{newRoute}' where deliveryID = '{txtDeliveryID.Text}'", dbCon.Connection);
                    updateDetail.ExecuteNonQuery();
                    updateDetail.Dispose();
                }

                int index = dgvDelivey.SelectedRows[0].Index;

                PopulateDGV("Delivery");
                CurrentRoute();
                PopulateDetails();
                CheckButtons();

                dgvDelivey.Rows[index].Selected = true;
            }
            else
                MessageBox.Show($"No permission to deliver.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CheckButtons()
        {
            btnPickup.Enabled = false;
            btnTransport.Enabled = false;
            btnDeliver.Enabled = false;
            bool transport = true;
            bool deliver = true;
            string location = currentRoute != "" ? currentRoute.Split('-')[1] : "";

            if (dgvOrders.SelectedRows.Count > 0)
            {
                if (canMoveInventory)
                {
                    if (dgvOrders.SelectedRows[0].Cells[7].Value.ToString() == "READY")
                        btnPickup.Enabled = true;
                }
                else
                    MessageBox.Show($"No permission to move inventory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            for (int i = 0; i < dgvOrders.Rows.Count; i++)
            {
                if (dgvOrders.Rows[i].Cells[7].Value.ToString() == "READY" ||
                    lstRoutes.SelectedIndex == lstRoutes.Items.Count - 1 ||
                    (dgvOrders.Rows[i].Cells[7].Value.ToString() != "CLOSED" && dgvOrders.Rows[i].Cells[5].Value.ToString() == location))
                    transport = false;

                if (location == "" || (dgvOrders.Rows[i].Cells[7].Value.ToString() != "IN TRANSIT" && dgvOrders.Rows[i].Cells[5].Value.ToString() == location))
                    deliver = false;
            }

            if (transport) btnTransport.Enabled = true;

            if (deliver) btnDeliver.Enabled = true;
        }

        private void CurrentRoute()
        {
            string route = "";
            MySqlDataReader detailSDR = new MySqlCommand($"SELECT details FROM delivery WHERE details IS NOT NULL AND deliveryID = {txtDeliveryID.Text}", dbCon.Connection).ExecuteReader();

            if (detailSDR.Read())
            {
                route = detailSDR.GetString(0);
            }
            detailSDR.Close();

            currentRoute = route;
        }

        private void DeliveryForm_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                PopulateDGV("Delivery");
            }

            
        }

        private void dgvDelivey_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDelivey.SelectedRows.Count > 0)
            {
                PopulateDGV("Orders");
                PopulateDetails();
                CheckButtons();
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            CheckButtons();
        }

        private void dtpDeliveryDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateDGV("Delivery");
        }

        private void InTransit()
        {
            string orderID = dgvOrders.SelectedRows[0].Cells[0].Value.ToString();

            MySqlDataReader orderListSDR = new MySqlCommand($"SELECT ti.itemID, (ti.quantity * i.caseSize) FROM txnitem ti, item i WHERE ti.itemID = i.itemid AND ti.txnID = {orderID}", dbCon.Connection).ExecuteReader();
            ArrayList orderlist = new ArrayList();

            while (orderListSDR.Read())
            {
                orderlist.Add(new string[] { orderListSDR.GetString(0), orderListSDR.GetString(1) });
            }
            orderListSDR.Close();

            foreach (string[] order in orderlist)
            {
                int exists = 0;
                MySqlDataReader existsSDR = new MySqlCommand($"SELECT COUNT(*) FROM inventory WHERE itemID = {order[0]} AND locationID = 'VHCL'", dbCon.Connection).ExecuteReader();

                if (existsSDR.Read())
                {
                    exists = existsSDR.GetInt16(0);
                }
                existsSDR.Close();

                if (exists == 0)
                {
                    MySqlCommand insertInventory = new MySqlCommand("INSERT INTO inventory " +
                            "(itemID, locationID, quantity, reorderAmount, reorderLevel)" +
                            $"VALUES ({order[0]}, 'VHCL', {order[1]}, 0, 0)", dbCon.Connection);
                    insertInventory.ExecuteNonQuery();
                    insertInventory.Dispose();
                }
                else
                {
                    MySqlCommand updateInventory = new MySqlCommand("UPDATE inventory " +
                            $"SET quantity = (quantity + {order[1]})" +
                            $"WHERE itemID = {order[0]} AND locationID = 'VHCL'", dbCon.Connection);
                    updateInventory.ExecuteNonQuery();
                    updateInventory.Dispose();
                }
            }
            new Audit("Pickup order", user.UserID, orderID, $"Order items from order {orderID} were picked up and added to vehicle");

            MySqlCommand updateStatus = new MySqlCommand($"UPDATE txn SET txnStatus = 'IN TRANSIT' where txnID = {orderID}", dbCon.Connection);
            updateStatus.ExecuteNonQuery();
            updateStatus.Dispose();

            new Audit("Order Status Changed", user.UserID, orderID, $"Order {orderID} Status changed to IN TRANSIT");
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void PopulateDetails()
        {
            if (dgvDelivey.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDelivey.SelectedRows[0];

                txtDeliveryID.Text = row.Cells[0].Value.ToString();
                txtDeliveryDate.Text = DateTime.Parse(row.Cells[1].Value.ToString()).ToString("d");
                txtWeight.Text = row.Cells[2].Value.ToString();
                txtVehicle.Text = row.Cells[3].Value.ToString();
                txtDeliveryDetails.Text = row.Cells[4].Value.ToString();
                lstRoutes.Items.Clear();

                MySqlCommand cmd = new MySqlCommand(SQLCommands.ROUTELIST + $"{txtDeliveryID.Text} order by r.distance desc", dbCon.Connection);
                MySqlDataReader sdr = cmd.ExecuteReader();

                ArrayList routes = new ArrayList();
                while (sdr.Read())
                    routes.Add(sdr.GetString(1));
                sdr.Close();

                for (int i = 0; i < routes.Count; i++)
                {
                    lstRoutes.Items.Add(routes[i]);
                }

                CurrentRoute();

                lstRoutes.SelectedIndex = currentRoute != "" ? lstRoutes.Items.IndexOf(currentRoute) : -1;
            }
        }

        private void PopulateDGV(string type)
        {
            if (type == "Delivery" || dgvDelivey.Rows.Count > 0)
            {
                string SQLcommand = type == "Delivery" ? SQLCommands.DELIVERYLIST + $"'{dtpDeliveryDate.Value.ToString(dateFormat)} 00:00:00'" : SQLCommands.ORDERDELIVERYLIST + dgvDelivey.SelectedRows[0].Cells[0].Value;

                MySqlCommand sqlCmd = new MySqlCommand();
                sqlCmd.Connection = dbCon.Connection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = SQLcommand;
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);

                if (type == "Delivery")
                {
                    dgvDelivey.DataSource = dtRecord;
                    dgvDelivey.ReadOnly = true;

                    for (int i = 0; i < dgvDelivey.Columns.Count; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                dgvDelivey.Columns[i].HeaderText = "Delivey ID";
                                break;

                            case 1:
                                dgvDelivey.Columns[i].HeaderText = "Delivey Date";
                                break;

                            case 2:
                                dgvDelivey.Columns[i].HeaderText = "Delivery Weight";
                                break;

                            case 3:
                                dgvDelivey.Columns[i].HeaderText = "Vehicle Type";
                                break;

                            default:
                                dgvDelivey.Columns[i].Visible = false;
                                break;
                        }
                    }
                }
                else
                {
                    dgvOrders.DataSource = dtRecord;
                    dgvOrders.ReadOnly = true;

                    for (int i = 0; i < dgvOrders.Columns.Count; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                dgvOrders.Columns[i].HeaderText = "Order ID";
                                break;

                            case 1:
                                dgvOrders.Columns[i].HeaderText = "Order Type";
                                break;

                            case 2:
                                dgvOrders.Columns[i].HeaderText = "Creation Date";
                                break;

                            case 3:
                                dgvOrders.Columns[i].HeaderText = "Estimated Arrival";
                                break;

                            case 5:
                                dgvOrders.Columns[i].HeaderText = "Origin";
                                break;

                            case 6:
                                dgvOrders.Columns[i].HeaderText = "Destination";
                                break;

                            case 7:
                                dgvOrders.Columns[i].HeaderText = "Status";
                                break;

                            default:
                                dgvOrders.Columns[i].Visible = false;
                                break;
                        }
                    }
                }
            }
        }
    }
}
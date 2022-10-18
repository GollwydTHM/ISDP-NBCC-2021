using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ISDP_AlexanderK.forms
{
    public partial class StoreForm : Form
    {
        private DBConnection dbCon = new DBConnection();
        private User user = new User();

        public StoreForm(User userVar)
        {
            user = userVar;
            InitializeComponent();
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                PopulateDGV("Orders");
                //CheckPermission();
                dgvPrepared.Enabled = false;
                dgvUnprepared.Enabled = false;
            }
        }

        private void PopulateDGV(string dgv)
        {
            string command = dgv == "Orders" ? SQLCommands.ORDERLIST + "'CLOSED' AND txnStatus != 'NEW' AND txnType = 'ONLINEORDER'" : SQLCommands.ITEMSLIST + $"'{dgvOrders.SelectedRows[0].Cells[0].Value}'";

            //populate
            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.Connection = dbCon.Connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = command;
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);

            if (dgv == "Orders")
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
            else
            {
                dgvUnprepared.Rows.Clear();
                dgvPrepared.Rows.Clear();
                dgvUnprepared.ColumnCount = 9;
                dgvUnprepared.ReadOnly = true;
                dgvPrepared.ColumnCount = 9;
                dgvPrepared.ReadOnly = true;

                for (int i = 0; i < dgvUnprepared.Columns.Count; i++)
                {
                    switch (i)
                    {
                        case 1:
                            dgvUnprepared.Columns[i].HeaderText = "Item ID";
                            dgvPrepared.Columns[i].HeaderText = "Item ID";
                            break;

                        case 2:
                            dgvUnprepared.Columns[i].HeaderText = "Item Name";
                            dgvPrepared.Columns[i].HeaderText = "Item Name";
                            break;

                        case 3:
                            dgvUnprepared.Columns[i].HeaderText = "Quantity";
                            dgvPrepared.Columns[i].HeaderText = "Quantity";
                            break;

                        default:
                            dgvUnprepared.Columns[i].Visible = false;
                            dgvPrepared.Columns[i].Visible = false;
                            break;
                    }
                }

                for (int i = 0; i < dtRecord.Rows.Count; i++)
                {
                    dgvUnprepared.Rows.Add(dtRecord.Rows[i].ItemArray);
                }
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                PopulateDGV("Unprepared");
                checkPrepared();

                btnAdd.Enabled = false;
                btnRemove.Enabled = false;
                btnReceive.Enabled = false;
                btnProcess.Enabled = false;
                btnReceive.Enabled = false;
                dgvPrepared.Enabled = false;

                if (dgvOrders.SelectedRows[0].Cells[7].Value.ToString() == "PROCESSING")
                {
                    dgvOrders.Enabled = false;
                    dgvPrepared.Enabled = true;
                    dgvUnprepared.Enabled = true;
                    btnCancel.Enabled = true;
                    btnFulfil.Enabled = true;

                    CheckButtons();
                    

                }
                else if (dgvOrders.SelectedRows[0].Cells[7].Value.ToString() == "SUBMITTED")
                {
                    btnReceive.Enabled = true;
                }
                else if (dgvOrders.SelectedRows[0].Cells[7].Value.ToString() == "RECEIVED")
                {
                    btnProcess.Enabled = true;
                }
                else if (dgvOrders.SelectedRows[0].Cells[7].Value.ToString() == "READY")
                {
                    btnCompleteOrder.Enabled = true;
                }
            }
        }

        private void CheckButtons()
        {
            if (dgvUnprepared.Rows.Count > 0)
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;

            if (dgvPrepared.Rows.Count > 0)
                btnRemove.Enabled = true;
            else
                btnRemove.Enabled = false;
        }

        private void checkPrepared()
        {
            string notes = dgvOrders.SelectedRows[0].Cells[8].Value.ToString();
            string[] preparedItems = notes.Contains("-") ? notes.Split('-')[1].Split('|') : new string[] { };

            if (preparedItems.Length > 0)
            {
                foreach (string id in preparedItems)
                {
                    bool success = false;
                    foreach (DataGridViewRow row in dgvUnprepared.Rows)
                    {
                        if (row.Cells[1].Value.ToString() == id)
                        {
                            ArrayList cells = new ArrayList();
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                cells.Add(row.Cells[i].Value);
                            }

                            dgvPrepared.Rows.Add(cells.ToArray());
                            dgvUnprepared.Rows.Remove(row);
                            success = true;
                            break;
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool success = false;
            DataGridViewRow row = dgvUnprepared.SelectedRows[0];

            ArrayList cells = new ArrayList();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                cells.Add(row.Cells[i].Value);
            }

            MySqlDataReader quantitySDR = new MySqlCommand($"SELECT quantity FROM inventory WHERE itemID = {cells[1]} AND locationInStore = 'Storeroom' AND locationID = '{dgvOrders.SelectedRows[0].Cells[6].Value}'", dbCon.Connection).ExecuteReader();

            if (quantitySDR.Read())
            {
                if (int.Parse(cells[3].ToString()) <= quantitySDR.GetInt16(0))
                {
                    dgvPrepared.Rows.Add(cells.ToArray());
                    dgvUnprepared.Rows.Remove(row);
                    success = true;
                }
            }
            quantitySDR.Close();

            if (success)
            {
                MySqlCommand editCommand = new MySqlCommand($"UPDATE txn SET note = IFNULL(CONCAT(note, '|{cells[1]}'), '-|{cells[1]}') where txnID = '{dgvOrders.SelectedRows[0].Cells[0].Value}'", dbCon.Connection);
                editCommand.ExecuteNonQuery();
                editCommand.Dispose();

            }
            else
            {
                MessageBox.Show($"Insuficient inventory quantities, can't prepare item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CheckButtons();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvPrepared.SelectedRows[0];

            ArrayList cells = new ArrayList();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                cells.Add(row.Cells[i].Value);
            }

            dgvUnprepared.Rows.Add(cells.ToArray());
            dgvPrepared.Rows.Remove(row);

            MySqlCommand editCommand = new MySqlCommand($"UPDATE txn SET note = REPLACE(note, '|{cells[1]}', '') where txnID = '{dgvOrders.SelectedRows[0].Cells[0].Value}'", dbCon.Connection);
            editCommand.ExecuteNonQuery();
            editCommand.Dispose();

            CheckButtons();
        }

        private void StyleDGV(DataGridView dgv)
        {
            if (!dgv.Enabled)
            {
                dgv.DefaultCellStyle.BackColor = SystemColors.Control;
                dgv.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText;
            }
            else
            {
                dgv.DefaultCellStyle.BackColor = SystemColors.Window;
                dgv.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Window;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        private void dgvOrders_EnabledChanged(object sender, EventArgs e)
        {
            StyleDGV(dgvOrders);
        }

        private void dgvUnprepared_EnabledChanged(object sender, EventArgs e)
        {
            StyleDGV(dgvUnprepared);
        }

        private void dgvPrepared_EnabledChanged(object sender, EventArgs e)
        {
            StyleDGV(dgvPrepared);
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            UpdateStatus("RECEIVED");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            UpdateStatus("PROCESSING");
            dgvOrders.Enabled = false;
            dgvPrepared.Enabled = true;
            dgvUnprepared.Enabled = true;
            btnCancel.Enabled = true;
            btnFulfil.Enabled = true;
            CheckButtons();
        }

        private void UpdateStatus(string status)
        {
            string orderID = dgvOrders.SelectedRows[0].Cells[0].Value.ToString();

            MySqlCommand editCommand = new MySqlCommand($"UPDATE txn SET txnStatus = '{status}' where txnID = '{orderID}'", dbCon.Connection);
            editCommand.ExecuteNonQuery();
            editCommand.Dispose();

            new Audit("Order Status Changed", user.UserID, orderID, $"Order {orderID} Status changed to {status}");

            int index = dgvOrders.SelectedRows[0].Index;

            PopulateDGV("Orders");

            if (dgvOrders.Rows.Count > 0) 
                dgvOrders.Rows[index].Selected = true;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MySqlCommand editCommand = new MySqlCommand($"UPDATE txn SET note = SUBSTRING_INDEX(note, '|', 1) where txnID = '{dgvOrders.SelectedRows[0].Cells[0].Value}'", dbCon.Connection);
            editCommand.ExecuteNonQuery();
            editCommand.Dispose();

            UpdateStatus("RECEIVED");
            dgvOrders.Enabled = true;
            dgvPrepared.Enabled = false;
            dgvUnprepared.Enabled = false;
            btnCancel.Enabled = false;
            btnFulfil.Enabled = false;
            btnAdd.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void btnFulfil_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvPrepared.Rows.Count; i++)
            {
                string itemID = dgvPrepared.Rows[i].Cells[1].Value.ToString();
                string quantity = dgvPrepared.Rows[i].Cells[3].Value.ToString();
                string location = dgvOrders.SelectedRows[0].Cells[6].Value.ToString();

                MySqlCommand discountInventory = new MySqlCommand($"UPDATE inventory SET quantity = (quantity - {quantity}) WHERE itemID = {itemID} AND locationID = '{location}'", dbCon.Connection);
                discountInventory.ExecuteNonQuery();
                discountInventory.Dispose();

                int exists = 0;
                MySqlDataReader existsSDR = new MySqlCommand($"SELECT COUNT(*) FROM inventory WHERE itemID = {itemID} AND locationID = '{location}' AND locationInStore = 'Curbside'", dbCon.Connection).ExecuteReader();

                if (existsSDR.Read())
                {
                    exists = existsSDR.GetInt16(0);
                }
                existsSDR.Close();

                if (exists == 0)
                {
                    MySqlCommand insertInventory = new MySqlCommand("INSERT INTO inventory " +
                            "(itemID, locationID, quantity, reorderAmount, reorderLevel, locationInStore)" +
                            $"VALUES ({itemID}, '{location}', {quantity}, 0, 0, 'Curbside')", dbCon.Connection);
                    insertInventory.ExecuteNonQuery();
                    insertInventory.Dispose();
                }
                else
                {
                    MySqlCommand updateInventory = new MySqlCommand("UPDATE inventory " +
                            $"SET quantity = (quantity + {quantity})" +
                            $"WHERE itemID = {itemID} AND locationID = '{location}' AND locationInStore = 'Curbside'", dbCon.Connection);
                    updateInventory.ExecuteNonQuery();
                    updateInventory.Dispose();
                }
            }

            UpdateStatus("READY");
            dgvOrders.Enabled = true;
            dgvPrepared.Enabled = false;
            dgvUnprepared.Enabled = false;
            btnCancel.Enabled = false;
            btnFulfil.Enabled = false;
            btnAdd.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvPrepared.Rows.Count; i++)
            {
                string itemID = dgvPrepared.Rows[i].Cells[1].Value.ToString();
                string quantity = dgvPrepared.Rows[i].Cells[3].Value.ToString();
                string location = dgvOrders.SelectedRows[0].Cells[6].Value.ToString();

                MySqlCommand updateInventory = new MySqlCommand("UPDATE inventory " +
                 $"SET quantity = (quantity - {quantity})" +
                 $"WHERE itemID = {itemID} AND locationID = '{location}' AND locationInStore = 'Curbside'", dbCon.Connection);
                updateInventory.ExecuteNonQuery();
                updateInventory.Dispose();
            }

            UpdateStatus("CLOSED");
            dgvPrepared.Rows.Clear();
            btnFulfil.Enabled = false;
        }
    }
}
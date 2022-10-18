using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ISDP_AlexanderK.forms
{
    public partial class ModifyRecordsForm : Form
    {
        private string addOrEdit;
        private DBConnection dbCon = new DBConnection();
        private User user = new User();

        public ModifyRecordsForm(User userVar)
        {
            user = userVar;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableEdit(false);
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows[0].Cells[7].Value.ToString() != "CANCELLED")
            {
                MySqlCommand editCommand = new MySqlCommand($"UPDATE txn SET txnStatus = 'CANCELLED' where txnID = '{txtOrderID.Text}'", dbCon.Connection);
                editCommand.ExecuteNonQuery();
                editCommand.Dispose();

                new Audit("Order Cancelled", user.UserID, txtOrderID.Text, $"Order {txtOrderID.Text} Status changed to {txtOrderID.Text}");
            }
            else
                MessageBox.Show("Order was already cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PopulateDGV("Orders");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ClearOrderDetails();
            MySqlDataReader autoIncrement = new MySqlCommand("SELECT AUTO_INCREMENT FROM information_schema.TABLES WHERE " +
                "TABLE_SCHEMA = 'bullseye2021' AND TABLE_NAME = 'txn'", dbCon.Connection).ExecuteReader();
            if (autoIncrement.Read())
            {
                txtOrderID.Text = autoIncrement.GetString(0);
            }
            autoIncrement.Close();

            addOrEdit = "add";
            EnableEdit(true);
        }

        private void ClearOrderDetails()
        {
            txtOrderID.Text = "";
            cbxOrderType.SelectedItem = cbxOrderType.Items[0];
            dtpCreation.Value = DateTime.Now;
            dtpArrival.Value = DateTime.Now.AddDays(7);
            cbxVehicle.SelectedItem = cbxVehicle.Items[0];
            cbxOrigin.SelectedItem = cbxOrigin.Items[0];
            cbxDestination.SelectedItem = cbxDestination.Items[0];
            cbxStatus.SelectedItem = cbxStatus.Items[0];
            txtOrderNote.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            addOrEdit = "edit";
            EnableEdit(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool error = false;
            if (cbxOrigin.Text == cbxDestination.Text)
            {
                MessageBox.Show("Origin and Destination can't be the same", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            if (dtpArrival.Value < dtpCreation.Value)
            {
                MessageBox.Show("Arrival Date can't be before Creation Date", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }

            if (!error)
            {
                string format = "yyyy-MM-dd";
                string vehicleID = cbxVehicle.Text.ToString() == "" ? "null" : $"'{cbxVehicle.Text}'";
                string originalLocationID = cbxOrigin.Text.ToString() == "" ? "null" : $"'{cbxOrigin.Text}'";
                string destinationLocationID = cbxDestination.Text.ToString() == "" ? "null" : $"'{cbxDestination.Text}'";
                string txnType = cbxOrderType.Text.ToString() == "" ? "null" : $"'{cbxOrderType.Text}'";

                if (addOrEdit == "add")
                {
                    //check duplicated entry
                    MySqlCommand addCommand = new MySqlCommand($"INSERT INTO txn (txnType, creationDate, estimatedArrival, vehicleTypeID, originalLocationID, " +
                        $"destinationLocationID, txnStatus, note) VALUES({txnType}, '{dtpCreation.Value.ToString(format)}', " +
                        $"'{dtpArrival.Value.ToString(format)}', {vehicleID}, {originalLocationID}, " +
                        $"{destinationLocationID}, '{cbxStatus.Text}', '{txtOrderNote.Text}')", dbCon.Connection);

                    addCommand.ExecuteNonQuery();
                    addCommand.Dispose();

                    new Audit("Order Created", user.UserID, txtOrderID.Text, $"Order {txtOrderID.Text} was created in Modify Record");
                }
                else
                {
                    MySqlCommand updateCommand = new MySqlCommand($"UPDATE txn SET txnType = {txnType}, creationDate = '{dtpCreation.Value.ToString(format)}', " +
                        $"estimatedArrival = '{dtpArrival.Value.ToString(format)}', vehicleTypeID = {vehicleID}, originalLocationID = {originalLocationID}, " +
                        $"destinationLocationID = {destinationLocationID}, txnStatus = '{cbxStatus.Text}', note = '{txtOrderNote.Text}' WHERE txnID = {txtOrderID.Text}", dbCon.Connection);
                    updateCommand.ExecuteNonQuery();
                    updateCommand.Dispose();

                    new Audit("Order Updated", user.UserID, txtOrderID.Text, $"Order {txtOrderID.Text} was updated in Modify Record");
                }

                PopulateDGV("Orders");
                EnableEdit(false);
            }
        }

        private void dgvItems_EnabledChanged(object sender, EventArgs e)
        {
            StyleDGV(dgvItems);
        }

        private void dgvOrders_EnabledChanged(object sender, EventArgs e)
        {
            StyleDGV(dgvOrders);
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;

            if (dgvOrders.SelectedRows.Count > 0)
            {
                btnEdit.Enabled = true;

                if (dgvOrders.SelectedRows[0].Cells[7].Value.ToString() != "CANCELLED")
                    btnCancelOrder.Enabled = true;
                else
                    btnCancelOrder.Enabled = false;

                DataGridViewRow row = dgvOrders.SelectedRows[0];

                txtOrderID.Text = row.Cells[0].Value.ToString();
                cbxOrderType.Text = row.Cells[1].Value.ToString();
                dtpCreation.Value = DateTime.Parse(row.Cells[2].Value.ToString());
                dtpArrival.Value = row.Cells[3].Value.ToString() == "" ? DateTime.Now : DateTime.Parse(row.Cells[3].Value.ToString());
                cbxVehicle.Text = row.Cells[4].Value.ToString();
                cbxOrigin.Text = row.Cells[5].Value.ToString();
                cbxDestination.Text = row.Cells[6].Value.ToString();
                cbxStatus.Text = row.Cells[7].Value.ToString();
                txtOrderNote.Text = row.Cells[8].Value.ToString();

                PopulateDGV("Items");
            }
        }

        private void EnableEdit(bool enable)
        {
            if (enable)
            {
                grbOrder.Enabled = true;
                grbOrderButtons.Enabled = false;
                dgvOrders.Enabled = false;
            }
            else
            {
                grbOrder.Enabled = false;
                grbOrderButtons.Enabled = true;
                dgvOrders.Enabled = true;
            }
        }

        private void ModifyRecordsForm_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                PopulateComboBoxes();
                PopulateDGV("Orders");

                dgvItems.Enabled = false;
            }
        }

        private void PopulateComboBoxes()
        {
            MySqlDataReader txnstatusSDR = new MySqlCommand("SELECT txnStatus FROM txnstatus WHERE txnstatus != 'CANCELLED'", dbCon.Connection).ExecuteReader();
            while (txnstatusSDR.Read())
            {
                cbxStatus.Items.Add(txnstatusSDR.GetString(0));
            }
            txnstatusSDR.Close();

            MySqlDataReader transactionTypeSDR = new MySqlCommand("SELECT transactionType FROM transactiontype WHERE transactionType = 'ORDER' OR transactionType = 'BACKORDER' OR transactionType = 'EMERGENCY'", dbCon.Connection).ExecuteReader();
            while (transactionTypeSDR.Read())
            {
                cbxOrderType.Items.Add(transactionTypeSDR.GetString(0));
            }
            transactionTypeSDR.Close();

            MySqlDataReader vehicletypeSDR = new MySqlCommand("SELECT vehicleTypeID FROM vehicletype", dbCon.Connection).ExecuteReader();
            while (vehicletypeSDR.Read())
            {
                cbxVehicle.Items.Add(vehicletypeSDR.GetString(0));
            }
            vehicletypeSDR.Close();

            MySqlDataReader locationSDR = new MySqlCommand("SELECT locationID FROM location", dbCon.Connection).ExecuteReader();
            while (locationSDR.Read())
            {
                cbxOrigin.Items.Add(locationSDR.GetString(0));
                cbxDestination.Items.Add(locationSDR.GetString(0));
            }
            locationSDR.Close();
        }

        private void PopulateDGV(string dgv)
        {
            string command = dgv == "Orders" ? SQLCommands.ORDERLIST + "'CLOSED' AND txnType = 'ORDER' OR txnType = 'BACKORDER' OR txnType = 'EMERGENCY'" : SQLCommands.ITEMSLIST + $"'{txtOrderID.Text}'";

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
                dgvItems.DataSource = dtRecord;
                dgvItems.ReadOnly = true;

                for (int i = 0; i < dgvItems.Columns.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            dgvItems.Columns[i].HeaderText = "Order ID";
                            break;

                        case 1:
                            dgvItems.Columns[i].HeaderText = "Item ID";
                            break;

                        case 2:
                            dgvItems.Columns[i].HeaderText = "Item Name";
                            break;

                        case 3:
                            dgvItems.Columns[i].HeaderText = "Quantity";
                            break;

                        case 4:
                            dgvItems.Columns[i].HeaderText = "Total";
                            break;

                        default:
                            dgvItems.Columns[i].Visible = false;
                            break;
                    }
                }
            }
        }

        private void StyleDGV(DataGridView dgv)
        {
            if (!dgv.Enabled)
            {
                dgv.DefaultCellStyle.BackColor = SystemColors.Control;
                dgv.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText;
                dgv.EnableHeadersVisualStyles = false;
            }
            else
            {
                dgv.DefaultCellStyle.BackColor = SystemColors.Window;
                dgv.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Window;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
                dgv.EnableHeadersVisualStyles = true;
            }
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
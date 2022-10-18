using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace ISDP_AlexanderK.forms
{
    public partial class SupplierForm : Form
    {
        private string addOrEdit;
        private DBConnection dbCon = new DBConnection();
        private User user = new User();
        private ArrayList suppliers = new ArrayList();

        public SupplierForm(User userVar)
        {
            user = userVar;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addOrEdit = "add";
            nudItemID.Value = nudItemID.Minimum;
            nudItemID.Enabled = true;
            nudQuantity.Value = nudQuantity.Minimum;
            EnableEdit(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableEdit(false);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool duplicated = false;

            //check duplicated entry
            for (int i = 0; i < dgvOrders.Rows.Count; i++)
            {
                if (dgvOrders.Rows[i].Cells[7].Value.ToString() == "NEW")
                {
                    duplicated = true;
                }
            }

            if (!duplicated)
            {
                MySqlCommand addCommand = new MySqlCommand($"INSERT INTO txn SET txnType = 'SUPPLIERORDER'," +
                    $"originalLocationID = 'WARE', destinationLocationID = 'WARE',  txnStatus = 'NEW'", dbCon.Connection);
                addCommand.ExecuteNonQuery();
                addCommand.Dispose();
                PopulateDGV("Orders");

                if (dgvOrders.Rows.Count > 0)
                    dgvOrders.Rows[dgvOrders.Rows.Count - 1].Selected = true;

                PopulateOrderItems();

                new Audit("Create Order", user.UserID, txtOrderID.Text.ToString(), $"SUPPLIERORDER Order n.{txtOrderID.Text} was created");
            }
            else
            {
                MessageBox.Show($"Can't create an order of type 'SUPPLIERORDER' cause there is already one with the status 'NEW' created.",
                    "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeVisibility("Items");
            PopulateDGV("Items");
        }

        private void btnItemEdit_Click(object sender, EventArgs e)
        {
            addOrEdit = "edit";
            nudItemID.Enabled = false;
            EnableEdit(true);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CheckPermissions();
            CompleteOrder();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ChangeVisibility("Orders");
            PopulateDGV("Orders");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (addOrEdit == "add")
            {
                bool duplicated = false;
                //check duplicated entry
                for (int i = 0; i < dgvItems.Rows.Count; i++)
                {
                    if (dgvItems.Rows[i].Cells[1].Value.ToString() == nudItemID.Value.ToString())
                    {
                        duplicated = true;
                    }
                }

                if (!duplicated)
                {
                    MySqlCommand addCommand = new MySqlCommand($"INSERT INTO txnItem SET txnID = {txtOrderID.Text}, " +
                        $"itemID = {nudItemID.Value}, quantity = {nudQuantity.Value}", dbCon.Connection);

                    addCommand.ExecuteNonQuery();
                    addCommand.Dispose();

                    new Audit("Item added to order", user.UserID, txtOrderID.Text.ToString(), $"Items {nudItemID.Value} was added to order ID: {txtOrderID.Text}");

                    PopulateDGV("Items");
                    EnableEdit(false);
                }
                else
                {
                    MessageBox.Show($"Can't add an Item that already exists in the order: '{nudItemID.Value}'",
                        "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MySqlCommand editCommand = new MySqlCommand();
                editCommand.Connection = dbCon.Connection;

                if (nudQuantity.Value == 0)
                {
                    editCommand.CommandText = SQLCommands.DELETETXNITEM + $"({nudItemID.Value})";
                    new Audit("Item deleted from order", user.UserID, txtOrderID.Text, $"Items {nudItemID.Value} was deleted from order ID: {txtOrderID.Text}");
                }
                else
                {
                    editCommand.CommandText = $"UPDATE txnItem SET quantity = {nudQuantity.Value} where itemID = {nudItemID.Value}";
                    new Audit("Item quantity changed", user.UserID, txtOrderID.Text, $"Items {nudItemID.Value} in order {txtOrderID.Text} changed to {nudQuantity.Value}");
                }

                editCommand.ExecuteNonQuery();
                editCommand.Dispose(); ;
                PopulateDGV("Items");
                EnableEdit(false);
            }
        }

        private void ChangeVisibility(string change)
        {
            if (change == "Items")
            {
                dgvOrders.Visible = false;
                grbOrder.Enabled = false;
                grbOrder.Visible = false;
                grbOrderButtons.Enabled = false;
                grbOrderButtons.Visible = false;
                dgvItems.Visible = true;
                grbItem.Visible = true;
                grbItemsButtons.Enabled = true;
                grbItemsButtons.Visible = true;
                cbxSupplierFilter.Enabled = true;
            }
            else
            {
                dgvOrders.Visible = true;
                grbOrder.Enabled = true;
                grbOrder.Visible = true;
                grbOrderButtons.Enabled = true;
                grbOrderButtons.Visible = true;
                dgvItems.Visible = false;
                grbItem.Visible = false;
                grbItemsButtons.Enabled = false;
                grbItemsButtons.Visible = false;
                cbxSupplierFilter.Enabled = false;
            }
        }

        private void CheckPermissions()
        {
            btnNext.Enabled = false;
            btnEdit.Enabled = false;
            grbOrderButtons.Enabled = false;
            btnCreate.Enabled = false;

            for (int i = 0; i < user.Permissions.Count; i++)
            {
                switch (user.Permissions[i].ToString())
                {
                    case "CREATESUPPLIERORDER":
                        grbOrderButtons.Enabled = true;
                        btnCreate.Enabled = true;
                        if (txtStatus.Text == "NEW")
                        {
                            btnEdit.Enabled = true;
                            btnNext.Enabled = true;
                        }
                        break;
                }
            }
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                nudItemID.Value = int.Parse(dgvItems.SelectedRows[0].Cells[1].Value.ToString());
                nudQuantity.Value = int.Parse(dgvItems.SelectedRows[0].Cells[4].Value.ToString());
                nudQuantity.Increment = int.Parse(dgvItems.SelectedRows[0].Cells[5].Value.ToString());
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvOrders.SelectedRows[0];

                txtOrderID.Text = row.Cells[0].Value.ToString();
                txtOrderType.Text = row.Cells[1].Value.ToString();
                txtCreationDate.Text = row.Cells[2].Value.ToString();
                txtArrivalDate.Text = row.Cells[3].Value.ToString();
                txtVehicle.Text = row.Cells[4].Value.ToString();
                txtOrigin.Text = row.Cells[5].Value.ToString();
                txtDestination.Text = row.Cells[6].Value.ToString();
                txtStatus.Text = row.Cells[7].Value.ToString();
                txtOrderNote.Text = row.Cells[8].Value.ToString();
            }

            CheckPermissions();
        }

        private void EnableEdit(bool enable)
        {
            if (enable)
            {
                grbItem.Enabled = true;
                grbItemsButtons.Enabled = false;
            }
            else
            {
                grbItem.Enabled = false;
                grbItemsButtons.Enabled = true;
            }
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void LoadHelpfulClasses()
        {
            //Location Class
            MySqlDataReader supplierSDR = new MySqlCommand(SQLCommands.SUPPLIERCLASS, dbCon.Connection).ExecuteReader();
            while (supplierSDR.Read())
            {
                Supplier supTemp = new Supplier();

                supTemp.SupplierID = supplierSDR.GetInt32(0);
                supTemp.SupplierName = supplierSDR.GetString(1);

                suppliers.Add(supTemp);
            }
            supplierSDR.Close();
        }

        private void nudItemID_ValueChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand($"select * from item where active = '1' and itemID='{nudItemID.Value}'", dbCon.Connection);
            MySqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                txtDescription.Text = sdr.GetString(1);
                txtItemCategory.Text = sdr.GetString(2);
                txtCase.Text = sdr.GetString(3);
                nudQuantity.Value = 0;
                nudQuantity.Increment = sdr.GetInt32(3);
                txtSKU.Text = sdr.GetString(4);
                txtItemName.Text = sdr.GetString(5);
                txtSupplier.Text = GetSupplierName(sdr.GetInt32(6));
                txtCost.Text = sdr.GetString(7);
                txtRetail.Text = sdr.GetString(8);
                txtWeight.Text = sdr.GetString(9);
            }
            else
            {
                txtDescription.Text = "";
                txtItemCategory.Text = "";
                txtCase.Text = "";
                txtSKU.Text = "";
                txtItemName.Text = "";
                txtSupplier.Text = "";
                txtCost.Text = "";
                txtRetail.Text = "";
                txtWeight.Text = "";
            }
            sdr.Close();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                LoadHelpfulClasses();
                PopulateComboBox();
                PopulateDGV("Orders");
                CheckPermissions();
            }
        }

        private string GetSupplierName(int id)
        {
            string supplierName = "";
            foreach (Supplier sup in suppliers)
            {
                if (sup.SupplierID == id)
                {
                    supplierName = sup.SupplierID.ToString();
                    break;
                }
            }

            return supplierName;
        }

        private void PopulateComboBox()
        {
            foreach (Supplier sup in suppliers)
            {
                cbxSupplierFilter.Items.Add(sup.SupplierName);
            }
            cbxSupplierFilter.SelectedIndex = 0;
        }

        private void PopulateDGV(string dgv)
        {
            string command = dgv == "Orders" ? SQLCommands.SUPPLIERORDERSLIST : SQLCommands.SUPPLIERITEMSLIST + $"'{txtOrderID.Text}'";

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
                            dgvItems.Columns[i].HeaderText = "Supplier";
                            break;

                        case 4:
                            dgvItems.Columns[i].HeaderText = "Quantity";
                            break;

                        default:
                            dgvItems.Columns[i].Visible = false;
                            break;
                    }
                }
            }

            CheckPermissions();
        }

        private void PopulateOrderItems()
        {
            MySqlCommand cmd = new MySqlCommand(SQLCommands.SUPPLIERORDERPOPULATEITEM, dbCon.Connection);
            MySqlDataReader sdr = cmd.ExecuteReader();

            ArrayList idSet = new ArrayList();
            ArrayList quantitySet = new ArrayList();

            while (sdr.Read())
            {
                int id = sdr.GetInt32(0);
                int quantity = sdr.GetInt32(1);
                int amount = sdr.GetInt32(2);
                int level = sdr.GetInt32(3);
                int caseSize = sdr.GetInt32(4);

                if (caseSize != 0)
                {
                    if (quantity < level)
                    {
                        int caseQuant = 0;

                        int i = 1;

                        while (caseSize * i < amount)
                        {
                            i++;
                        }
                        while (caseSize * caseQuant + quantity < level)
                        {
                            caseQuant = caseQuant + i;
                            quantity = quantity + caseSize;
                        }

                        idSet.Add(id);
                        quantitySet.Add(caseQuant * caseSize);
                    }
                }
            }
            sdr.Close();

            if (idSet.Count > 0)
            {
                string sqlstring = SQLCommands.TXNITEMINSERT;

                for (int i = 0; i < idSet.Count; i++)
                {
                    sqlstring += $"({txtOrderID.Text}, {idSet[i]}, {quantitySet[i]})";

                    if (i != idSet.Count - 1)
                        sqlstring += ", ";
                }

                MySqlCommand addCommand = new MySqlCommand(sqlstring, dbCon.Connection);
                addCommand.ExecuteNonQuery();
                addCommand.Dispose();

                new Audit("Items added to order", user.UserID, txtOrderID.Text.ToString(), $"New items were added to order ID: {txtOrderID.Text}");
            }
        }

        private void CompleteOrder()
        {
            string orderID = txtOrderID.Text;
            string status = txtStatus.Text;
            string nextstep = status;

            if (status == "NEW")
            {
                MySqlDataReader countSDR = new MySqlCommand($"Select count(*) from txnItem where txnID = {orderID}", dbCon.Connection).ExecuteReader();
                countSDR.Read();

                if (countSDR.GetInt32(0) != 0)
                    nextstep = "CLOSED";
                else
                    MessageBox.Show($"Can't submit an empty order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                countSDR.Close();
            }

            if (status != nextstep)
            {
                MySqlCommand editCommand = new MySqlCommand($"UPDATE txn SET txnStatus = '{nextstep}', estimatedArrival = Now() WHERE txnID = '{orderID}'", dbCon.Connection);
                editCommand.ExecuteNonQuery();
                editCommand.Dispose();

                new Audit("Order Status Changed", user.UserID, orderID, $"Order {orderID} Status changed to {nextstep}");

                int index = dgvOrders.SelectedRows[0].Index;

                PopulateDGV("Orders");
                if (dgvOrders.Rows.Count > 0)
                    dgvOrders.Rows[index].Selected = true;
            }
        }

        private void cbxSupplierFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSupplierFilter.Text == "All")
            {
                foreach (DataGridViewRow row in dgvItems.Rows)
                    row.Visible = true;
            }
            else
            {
                if (dgvItems.SelectedRows.Count > 0)
                    dgvItems.SelectedRows[0].Selected = false;

                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgvItems.DataSource];
                currencyManager.SuspendBinding();

                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    if (row.Cells[3].Value.ToString() == cbxSupplierFilter.Text)
                        row.Visible = true;
                    else
                        row.Visible = false;
                }

                currencyManager.ResumeBinding();
            }
        }
    }
}
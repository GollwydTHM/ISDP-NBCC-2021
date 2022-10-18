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
    public partial class ProductForm : Form
    {
        private string addOrEdit = "";
        private DBConnection dbCon = new DBConnection();
        private ArrayList suppliers = new ArrayList();
        private User user = new User();

        public ProductForm(User userVar)
        {
            user = userVar;
            InitializeComponent();
        }

        private void ActivateEdit()
        {
            grbItem.Enabled = true;
            dgvProducts.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addOrEdit = "add";
            ActivateEdit();
            ClearDetails();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DeactivateEdit();
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int active = dgvProducts.SelectedRows[0].Cells[11].Value.ToString() == "0" ? 1 : 0;

                MySqlCommand editCommand = new MySqlCommand("UPDATE item SET active = " + active + " WHERE itemID = '" + nudItemID.Text + "'", dbCon.Connection);
                editCommand.ExecuteNonQuery();
                editCommand.Dispose();
                PopulateDGV();

                string action = active == 0 ? "Deactivation" : "Activation";

                new Audit($"Item {action}", user.UserID, "", $"Item ID {dgvProducts.SelectedRows[0].Cells[1].Value} {action}");
            }
            else
                MessageBox.Show("To deactivate a inventory you must first select one", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            addOrEdit = "edit";
            ActivateEdit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text != "")
            {
                int supplierID = GetSupplierID(cbxSupplier.Text);

                if (addOrEdit == "add")
                {
                    MySqlCommand addCommand = new MySqlCommand($"INSERT INTO Item SET description = '{txtDescription.Text}', itemCategory = '{cbxItemCategory.SelectedItem}', caseSize = {nudCaseSize.Value}, sku = '{txtSKU.Text}', itemName = '{txtItemName.Text}',  supplierID = {supplierID}, costPrice = {nudCost.Value}, retailPrice = {nudRetail.Value}, weight = {nudWeight.Value}, note = '{txtItemNotes.Text}', active = 1", dbCon.Connection);
                    addCommand.ExecuteNonQuery();
                    addCommand.Dispose();

                    int lastID = 0;
                    MySqlDataReader itemidSDR = new MySqlCommand("select MAX(itemID) from item", dbCon.Connection).ExecuteReader();
                    if (itemidSDR.Read()) lastID = itemidSDR.GetInt16(0);
                    itemidSDR.Close();

                    new Audit($"Item Added", user.UserID, "", $"Item {lastID} added in the database");
                }
                else
                {
                    MySqlCommand editCommand = new MySqlCommand($"UPDATE item SET description = '{txtDescription.Text}', itemCategory = '{cbxItemCategory.Text}', caseSize = {nudCaseSize.Value}, sku = '{txtSKU.Text}', itemName = '{txtItemName.Text}',  supplierID = {supplierID}, caseSize = {nudCaseSize.Value}, retailPrice = {nudRetail.Value}, weight = {nudWeight.Value}, note = '{txtItemNotes.Text}' where itemid = {nudItemID.Value}", dbCon.Connection);
                    editCommand.ExecuteNonQuery();
                    editCommand.Dispose();

                    new Audit($"Item Updated", user.UserID, "", $"Item {nudItemID.Value} was updated in the database");
                }

                PopulateDGV();
                DeactivateEdit();
            }
            else
            {
                MessageBox.Show("Please, enter the item's name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int GetSupplierID(string name)
        {
            int supplierID = 0;
            foreach (Supplier sup in suppliers)
            {
                if (sup.SupplierName == name)
                {
                    supplierID = sup.SupplierID;
                    break;
                }
            }

            return supplierID;
        }

        private void cbxSupplierFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void CheckActive()
        {
            for (int i = 0; i < dgvProducts.Rows.Count; i++)
            {
                if (dgvProducts.Rows[i].Cells[11].Value.ToString() == "0")
                    dgvProducts.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                else
                    dgvProducts.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void ClearDetails()
        {
            nudItemID.Value = nudItemID.Minimum;
            txtDescription.Text = "";
            cbxItemCategory.SelectedIndex = 0;
            txtSKU.Text = "";
            nudCaseSize.Value = nudCaseSize.Minimum;
            txtItemName.Text = "";
            cbxSupplier.SelectedIndex = 0;
            nudCost.Value = nudCost.Minimum;
            nudRetail.Value = nudRetail.Minimum;
            nudWeight.Value = nudWeight.Minimum;
            txtItemNotes.Text = "";
        }

        private void DeactivateEdit()
        {
            grbItem.Enabled = false;
            dgvProducts.Enabled = true;
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvProducts.SelectedRows[0];

                nudItemID.Value = int.Parse(row.Cells[0].Value.ToString());
                txtDescription.Text = row.Cells[1].Value.ToString();
                cbxItemCategory.Text = row.Cells[2].Value.ToString();
                nudCaseSize.Value = int.Parse(row.Cells[3].Value.ToString());
                txtSKU.Text = row.Cells[4].Value.ToString();
                txtItemName.Text = row.Cells[5].Value.ToString();
                cbxSupplier.Text = row.Cells[6].Value.ToString();
                nudCost.Value = decimal.Parse(row.Cells[7].Value.ToString());
                nudRetail.Value = decimal.Parse(row.Cells[8].Value.ToString());
                nudWeight.Value = decimal.Parse(row.Cells[9].Value.ToString());
                txtItemNotes.Text = row.Cells[10].Value.ToString();
            }
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

        private void PopulateComboBox()
        {
            foreach (Supplier sup in suppliers)
            {
                cbxSupplier.Items.Add(sup.SupplierName);
                cbxSupplierFilter.Items.Add(sup.SupplierName);
            }
            cbxSupplierFilter.SelectedIndex = 0;

            MySqlDataReader categorySDR = new MySqlCommand(SQLCommands.CATEGORYCLASS, dbCon.Connection).ExecuteReader();
            while (categorySDR.Read())
            {
                cbxItemCategory.Items.Add(categorySDR.GetString(0));
            }
            categorySDR.Close();
        }

        private void PopulateDGV()
        {

            //populate
            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.Connection = dbCon.Connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = SQLCommands.PRODUCTSDGV + GetSupplierID(cbxSupplierFilter.Text);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dgvProducts.DataSource = dtRecord;
            dgvProducts.ReadOnly = true;

            //hide unwanted collums and change header names
            for (int i = 0; i < dgvProducts.Columns.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvProducts.Columns[i].HeaderText = "Item ID";
                        break;

                    case 1:
                        dgvProducts.Columns[i].HeaderText = "Description";
                        dgvProducts.Columns[i].DisplayIndex = 2;
                        break;

                    case 2:
                        dgvProducts.Columns[i].HeaderText = "Category";
                        dgvProducts.Columns[i].DisplayIndex = 4;
                        break;

                    case 5:
                        dgvProducts.Columns[i].HeaderText = "Item Name";
                        dgvProducts.Columns[i].DisplayIndex = 3;
                        break;

                    case 7:
                        dgvProducts.Columns[i].HeaderText = "Cost Price";
                        break;

                    case 8:
                        dgvProducts.Columns[i].HeaderText = "Retail Price";
                        break;

                    case 9:
                        dgvProducts.Columns[i].HeaderText = "Weight";
                        break;

                    default:
                        dgvProducts.Columns[i].Visible = false;
                        break;
                }
            }
            CheckActive();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                LoadHelpfulClasses();
                PopulateComboBox();
                PopulateDGV();
            }

            for (int i = 0; i < user.Permissions.Count; i++)
            {
                switch (user.Permissions[i].ToString())
                {
                    case "EDITPRODUCT":
                        if (user.RoleID == "4" || user.RoleID == "999")
                        {
                            btnDeactivate.Enabled = true;
                            btnEdit.Enabled = true;
                        }
                        break;

                    case "ADDNEWPRODUCT":
                        if (user.RoleID == "4" || user.RoleID == "999") btnAdd.Enabled = true;
                        break;
                }
            }
        }
    }
}
using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ISDP_AlexanderK
{
    public partial class InventoryForm : Form
    {
        private string addOrEdit = "";
        private DBConnection dbCon = new DBConnection();
        private User user = new User();

        public InventoryForm(User userVar)
        {
            user = userVar;
            InitializeComponent();
        }
        private void ActivateEdit()
        {
            grbDetails.Enabled = true;
            dgvInventory.Enabled = false;
            if (addOrEdit == "add")
                grbItem.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addOrEdit = "add";
            ActivateEdit();
            ClearDetails();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DeactvateEdit();
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                int active = dgvInventory.SelectedRows[0].Cells[8].Value.ToString() == "0" ? 1 : 0;

                MySqlCommand editCommand = new MySqlCommand("UPDATE inventory SET active = " + active + " WHERE inventoryID = '" + txtInventoryID.Text + "'", dbCon.Connection);
                editCommand.ExecuteNonQuery();
                editCommand.Dispose();
                PopulateDGV();

                string action = active == 0 ? "Deactivation" : "Activation";

                new Audit($"Inventory {action}", user.UserID, "", $"Item ID {dgvInventory.SelectedRows[0].Cells[1].Value} {action}");
            }
            else
                MessageBox.Show("To deactivate a inventory you must first select one", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            addOrEdit = "edit";

            grbDetails.Enabled = true;
            dgvInventory.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool duplicated = false;
            //check duplicated entry
            for (int i = 0; i < dgvInventory.Rows.Count; i++)
            {
                if (dgvInventory.Rows[i].Cells[1].Value.ToString() == nudItemID.Value.ToString())
                {
                    duplicated = true;
                }
            }

            if (addOrEdit == "add")
            {
                if (!duplicated)
                {
                    MySqlCommand addCommand = new MySqlCommand($"INSERT INTO inventory SET itemID = {nudItemID.Value}, locationID = '{cbxLocation.SelectedItem.ToString()}', quantity = {nudQuantity.Value}, reorderAmount = {nudAmount.Value}, reorderLevel = {nudLevel.Value},  locationInStore = '{txtInStore.Text}', note = '{txtItemNotes.Text}', active = 1", dbCon.Connection);
                    addCommand.ExecuteNonQuery();
                    addCommand.Dispose();

                    new Audit($"Inventory Added", user.UserID, "", $"Inventory added for item {nudItemID.Value} in location {cbxLocation.SelectedItem}");
                }
                else
                {
                    MessageBox.Show("There is already a record with the Item ID: '" + nudItemID.Value.ToString() + "'", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MySqlCommand editCommand = new MySqlCommand($"UPDATE inventory SET itemID = '{nudItemID.Value.ToString()}', quantity = {nudQuantity.Value.ToString()}, reorderAmount = {nudAmount.Value.ToString()}, reorderLevel = {nudLevel.Value.ToString()}, locationInStore = '{txtInStore.Text}' WHERE inventoryid = '{txtInventoryID.Text}'", dbCon.Connection);
                editCommand.ExecuteNonQuery();
                editCommand.Dispose();

                new Audit($"Inventory Updated", user.UserID, "", $"Inventory {txtInventoryID.Text} was update for item {nudItemID.Value} in location {cbxLocation.SelectedItem}");

            }

            if (!duplicated)
            {
                PopulateDGV();
                DeactvateEdit();
            }
        }

        private void cbxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void CheckActive()
        {
            for (int i = 0; i < dgvInventory.Rows.Count; i++)
            {
                if (dgvInventory.Rows[i].Cells[8].Value.ToString() == "0")
                    dgvInventory.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                else
                    dgvInventory.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void ClearDetails()
        {
            txtInventoryID.Text = "";
            nudItemID.Value = 10000;
            nudQuantity.Value = 0;
            nudAmount.Value = 0;
            nudLevel.Value = 0;
            txtInStore.Text = "";
            txtInventoryNote.Text = "";
        }

        private void DeactvateEdit()
        {
            grbDetails.Enabled = false;
            grbItem.Enabled = false;
            dgvInventory.Enabled = true;
        }

        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvInventory.SelectedRows[0];

                txtInventoryID.Text = row.Cells[0].Value.ToString();
                nudItemID.Value = int.Parse(row.Cells[1].Value.ToString());
                nudQuantity.Value = int.Parse(row.Cells[3].Value.ToString());
                nudAmount.Value = int.Parse(row.Cells[4].Value.ToString());
                nudLevel.Value = int.Parse(row.Cells[5].Value.ToString());
                txtInStore.Text = row.Cells[6].Value.ToString();
                txtInventoryNote.Text = row.Cells[7].Value.ToString();
            }
        }

        private void dgvInventory_Sorted(object sender, EventArgs e)
        {
            CheckActive();
        }

        private void inventory_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                PopulateComboBox();
                PopulateDGV();
            }

            for (int i = 0; i < user.Permissions.Count; i++)
            {
                switch (user.Permissions[i].ToString())
                {
                    case "EDITINVENTORY":
                        if (user.RoleID == "3" || user.RoleID == "4" || user.RoleID == "7" || user.RoleID == "999")
                            btnDeactivate.Enabled = true;
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        break;

                    case "MOVEINVENTORY":
                        txtInStore.Enabled = true;
                        txtInventoryNote.Enabled = true;
                        break;
                }
            }
        }

        private void nudItemID_ValueChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand($"select * from item where active = '1' and itemID='{nudItemID.Value.ToString()}'", dbCon.Connection);
            MySqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                txtDescription.Text = sdr.GetString(0);
                txtItemCategory.Text = sdr.GetString(1);
                txtCase.Text = sdr.GetString(2);
                txtSKU.Text = sdr.GetString(3);
                txtItemName.Text = sdr.GetString(4);
                txtSupplier.Text = sdr.GetString(5);
                txtCost.Text = sdr.GetString(6);
                txtRetail.Text = sdr.GetString(7);
                txtWeight.Text = sdr.GetString(8);
                txtItemNotes.Text = sdr.GetString(9);
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
                txtItemNotes.Text = "";
            }
            sdr.Close();
        }

        private void PopulateComboBox()
        {
            MySqlDataReader locationsDR = new MySqlCommand("select locationID from location", dbCon.Connection).ExecuteReader();
            while (locationsDR.Read())
            {
                cbxLocation.Items.Add(locationsDR.GetString(0));
            }
            locationsDR.Close();

            if (user.RoleID == "999")
            {
                cbxLocation.Enabled = true;
            }
            else
                cbxLocation.Text = user.LocationID;
        }

        private void PopulateDGV()
        {
            //populate
            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.Connection = dbCon.Connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = SQLCommands.INVENTORY + $" AND locationID = '{cbxLocation.Text}'";
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dgvInventory.DataSource = dtRecord;
            dgvInventory.ReadOnly = true;

            //hide unwanted collums and change header names
            for (int i = 0; i < dgvInventory.Columns.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvInventory.Columns[i].HeaderText = "Inventory ID";
                        break;

                    case 1:
                        dgvInventory.Columns[i].HeaderText = "Item ID";
                        break;

                    case 3:
                        dgvInventory.Columns[i].HeaderText = "Quantity";
                        dgvInventory.Columns[i].DisplayIndex = 5;
                        break;

                    case 4:
                        dgvInventory.Columns[i].HeaderText = "Reorder Amount";
                        dgvInventory.Columns[i].DisplayIndex = 6;
                        break;

                    case 5:
                        dgvInventory.Columns[i].HeaderText = "Reorder Level";
                        dgvInventory.Columns[i].DisplayIndex = 7;
                        break;

                    case 6:
                        dgvInventory.Columns[i].HeaderText = "In Store Location";
                        dgvInventory.Columns[i].DisplayIndex = 4;
                        break;

                    case 11:
                        dgvInventory.Columns[i].HeaderText = "Category";
                        dgvInventory.Columns[i].DisplayIndex = 3;
                        break;

                    case 14:
                        dgvInventory.Columns[i].HeaderText = "Name";
                        dgvInventory.Columns[i].DisplayIndex = 2;
                        break;

                    default:
                        dgvInventory.Columns[i].Visible = false;
                        break;
                }
            }
            CheckActive();
        }
    }
}
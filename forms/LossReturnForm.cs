using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ISDP_AlexanderK.forms
{
    public partial class LossReturnForm : Form
    {
        private DBConnection dbCon = new DBConnection();
        private User user = new User();
        private string version = "";

        public LossReturnForm(User userVar, string versionTemp)
        {
            user = userVar;
            version = versionTemp;
            InitializeComponent();
        }

        private void LossReturnForm_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                LoadVersion();
                PopulateComboBox();
                CheckPermissions();
            }
        }

        private void LoadVersion()
        {
            if (version == "Loss")
            {
                lblTitle.Text = "Loss/Damage";
                lblPlaceholder.Text = "Record Type:";
                cbxOptions.Items.Add("LOSS");
                cbxOptions.Items.Add("DAMAGE");
                cbxOptions.SelectedIndex = 0;
            }
            else if (version == "Return")
            {
                lblTitle.Text = "Return";
                lblPlaceholder.Text = "Condition:";
                cbxOptions.Items.Add("GOOD");
                cbxOptions.Items.Add("BAD");
                cbxOptions.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show($"Wrong version selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
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
                txtSKU.Text = sdr.GetString(4);
                txtItemName.Text = sdr.GetString(5);
                txtSupplier.Text = sdr.GetString(6);
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
        private void CheckPermissions()
        {
            btnSubmit.Enabled = false;

            for (int i = 0; i < user.Permissions.Count; i++)
            {
                switch (user.Permissions[i].ToString())
                {                   
                    case "CREATELOSS":
                        if (version == "Loss")                       
                            btnSubmit.Enabled = true;                        
                        break;

                    case "PROCESSRETURN":
                        if (version == "Return")
                            btnSubmit.Enabled = true;
                        break;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (version == "Loss")
            {
                string txnType = cbxOptions.SelectedItem.ToString();
                string location = cbxLocation.SelectedItem.ToString();

                int id = 0;
                MySqlCommand insertTransaction = new MySqlCommand($"INSERT INTO txn SET txnType = '{txnType}', txnStatus = 'CLOSED', originalLocationID = '{location}', note = '{txtNote.Text}'", dbCon.Connection);
                insertTransaction.ExecuteNonQuery();
                insertTransaction.Dispose();

                MySqlDataReader txnID = new MySqlCommand($"SELECT MAX(txnID) from txn where txnType = '{txnType}'", dbCon.Connection).ExecuteReader();

                if (txnID.Read())
                {
                    id = txnID.GetInt32(0);
                }
                txnID.Close();

                new Audit($"New {txnType} record", user.UserID, "", $"{txnType} record ({id}) was created");

                MySqlCommand losstxnsUpdate = new MySqlCommand($"INSERT INTO txnItem SET txnID = { id }, " +
                        $"itemID = {nudItemID.Value}, quantity = {nudQuantity.Value}", dbCon.Connection);
                losstxnsUpdate.ExecuteNonQuery();
                losstxnsUpdate.Dispose();

                new Audit($"Item added for {txnType} record", user.UserID, id.ToString(), $"Item {nudItemID.Value} was added to {txnType} record {id}");

                MySqlCommand updateLocationInventory = new MySqlCommand($"UPDATE inventory SET quantity = (quantity - {nudQuantity.Value}) WHERE (locationInStore = 'Storeroom' OR locationInStore is NULL) AND itemID = {nudItemID.Value} AND locationID = '{cbxLocation.SelectedItem}'", dbCon.Connection);
                updateLocationInventory.ExecuteNonQuery();
                updateLocationInventory.Dispose();

                new Audit($"Updated Inventory item for {txnType} record", user.UserID, id.ToString(), $"Item {nudItemID.Value} was update in {location} for {txnType} record ({id})");
            }
            else if (version == "Return")
            {
                string condition = cbxOptions.SelectedItem.ToString();
                string location = cbxLocation.SelectedItem.ToString();

                string txnType = condition == "GOOD" ? "RETURN" : "LOSS";

                int id = 0;
                MySqlCommand insertTransaction = new MySqlCommand($"INSERT INTO txn SET txnType = '{txnType}', txnStatus = 'CLOSED', originalLocationID = '{location}', note = '{txtNote.Text}'", dbCon.Connection);
                insertTransaction.ExecuteNonQuery();
                insertTransaction.Dispose();

                MySqlDataReader txnID = new MySqlCommand($"SELECT MAX(txnID) from txn where txnType = '{txnType}'", dbCon.Connection).ExecuteReader();

                if (txnID.Read())
                {
                    id = txnID.GetInt32(0);
                }
                txnID.Close();

                new Audit($"New {txnType} record", user.UserID, "", $"{txnType} record ({id}) was created");

                MySqlCommand losstxnsUpdate = new MySqlCommand($"INSERT INTO txnItem SET txnID = { id }, " +
                        $"itemID = {nudItemID.Value}, quantity = {nudQuantity.Value}", dbCon.Connection);
                losstxnsUpdate.ExecuteNonQuery();
                losstxnsUpdate.Dispose();

                new Audit($"Item added for {txnType} record", user.UserID, id.ToString(), $"Item {nudItemID.Value} was added to {txnType} record {id}");

                if (condition == "GOOD")
                {
                    MySqlCommand updateLocationInventory = new MySqlCommand($"UPDATE inventory SET quantity = (quantity + {nudQuantity.Value}) WHERE (locationInStore = 'Storeroom' OR locationInStore is NULL) AND itemID = {nudItemID.Value} AND locationID = '{cbxLocation.SelectedItem}'", dbCon.Connection);
                    updateLocationInventory.ExecuteNonQuery();
                    updateLocationInventory.Dispose();

                    new Audit($"Updated Inventory item for {txnType} record", user.UserID, id.ToString(), $"Item {nudItemID.Value} was update in {location} for {txnType} record ({id})");
                }
            }

            this.Close();
        }

        private void PopulateComboBox()
        {
            //populate location combobox
            MySqlDataReader locationsDR = new MySqlCommand(SQLCommands.LOCATIONCOMBOBOX, dbCon.Connection).ExecuteReader();
            while (locationsDR.Read())
            {
                cbxLocation.Items.Add(locationsDR.GetString(0));
            }
            locationsDR.Close();

            if (user.RoleID == "999")
            {
                cbxLocation.Enabled = true;
                cbxLocation.Text = "WARE";
            }
            else
                cbxLocation.Text = user.LocationID;
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            LossReturnViewList lrvl = new LossReturnViewList(version);
            lrvl.ShowDialog();
        }
    }
}
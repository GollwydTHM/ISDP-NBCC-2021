using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ISDP_AlexanderK
{
    public partial class LocationsForm : Form
    {
        private string addOrEdit = "";
        private bool addpermission = false;
        private DBConnection dbCon = new DBConnection();
        private User user = new User();

        public LocationsForm(User userVar)
        {
            user = userVar;
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (addpermission == true)
            {
                addOrEdit = "add";
                grbDetails.Enabled = true;
                dgvLocations.Enabled = false;
                txtID.Enabled = true;
                ClearDetails();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grbDetails.Enabled = false;
            dgvLocations.Enabled = true;
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            int active = 0;

            if (dgvLocations.SelectedRows.Count > 0)
            {
                if (dgvLocations.SelectedRows[0].Cells[11].Value.ToString() == "0")
                {
                    active = 1;
                }

                MySqlCommand editCommand = new MySqlCommand("UPDATE location SET active = " + active + " WHERE locationID = '" + txtID.Text + "'", dbCon.Connection);
                editCommand.ExecuteNonQuery();
                editCommand.Dispose();
                PopulateDGV();

                string action = active == 0 ? "Deactivation" : "Activation";

                new Audit($"Location {action}", user.UserID, "", $"Location ID {txtID.Text} {action}");
            }
            else
            {
                MessageBox.Show("To deactivate a location you must first select one", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (addpermission == true)
            {
                addOrEdit = "edit";
                grbDetails.Enabled = true;
                dgvLocations.Enabled = false;
                txtID.Enabled = false;
            }
            else
            {
                MessageBox.Show("You don't have the permission to add a location", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool duplicated = false;
            //check duplicated entry
            for (int i = 0; i < dgvLocations.Rows.Count - 1; i++)
            {
                if (dgvLocations.Rows[i].Cells[0].Value.ToString() == txtID.Text)
                {
                    duplicated = true;
                }
            }

            if (!duplicated)
            {
                if (addOrEdit == "add")
                {
                    MySqlCommand addCommand = new MySqlCommand("INSERT INTO location (locationID, locationName, province, address, city, postalCode, phone, locationType, defaultDeliveryDay, active) VALUES" +
                        "('" + txtID.Text + "', '" + txtName.Text + "', '" + cbxProvince.Text + "', '" + txtAddress.Text + "', '" + txtCity.Text + "', '" + txtPostalCode.Text + "', '" + txtPhone.Text + "', '" + cbxType.Text + "', '" + txtDelivery.Text + "', 1)", dbCon.Connection);
                    addCommand.ExecuteNonQuery();
                    addCommand.Dispose();

                    new Audit($"Location Add", user.UserID, "", $"Location ID {txtID.Text} was added");
                }
                else
                {
                    MySqlCommand editCommand = new MySqlCommand("UPDATE location SET locationName = '" + txtName.Text + "', province = '" + cbxProvince.Text + "', address =  '"
                        + txtAddress.Text + "', city = '" + txtCity.Text + "', postalCode = '" + txtPostalCode.Text + "', phone = '"
                        + txtPhone.Text + "', locationType =  '" + cbxType.Text + "', defaultDeliveryDay = '" + txtDelivery.Text + "', active = 1 WHERE locationID = '" + txtID.Text + "'", dbCon.Connection);
                    editCommand.ExecuteNonQuery();
                    editCommand.Dispose();

                    new Audit($"Location Updated", user.UserID, "", $"Location ID {txtID.Text} was Updated");
                }

                PopulateDGV();
                grbDetails.Enabled = false;
                dgvLocations.Enabled = true;
            }
            else
            {
                MessageBox.Show("There is already a record with the ID: '" + txtID.Text + "'. Please add a unique ID.", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CheckActive()
        {
            for (int i = 0; i < dgvLocations.Rows.Count; i++)
            {
                if (dgvLocations.Rows[i].Cells[11].Value.ToString() == "0")
                {
                    dgvLocations.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    dgvLocations.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void ClearDetails()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            cbxProvince.SelectedItem = cbxProvince.Items[3];
            txtPostalCode.Text = "";
            txtCountry.Text = "";
            txtPhone.Text = "";
            cbxType.SelectedItem = cbxType.Items[0];
            txtDelivery.Text = "";
        }

        private void dgvLocations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLocations.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLocations.SelectedRows[0];

                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtAddress.Text = row.Cells[2].Value.ToString();
                txtCity.Text = row.Cells[3].Value.ToString();
                cbxProvince.Text = row.Cells[4].Value.ToString();
                txtPostalCode.Text = row.Cells[5].Value.ToString();
                txtCountry.Text = row.Cells[6].Value.ToString();
                txtPhone.Text = row.Cells[7].Value.ToString();
                cbxType.Text = row.Cells[8].Value.ToString();
                txtDelivery.Text = row.Cells[9].Value.ToString();
            }
        }

        private void dgvLocations_Sorted(object sender, EventArgs e)
        {
            CheckActive();
        }

        private void locations_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                PopulateDGV();
                PopulateComboBoxes();
            }

            for (int i = 0; i < user.Permissions.Count; i++)
            {
                if ((String)user.Permissions[i] == "ADDLOCATION")
                {
                    addpermission = true;
                    break;
                }
            }

            if (addpermission == true)
            {
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDeactivate.Enabled = true;
            }
        }

        private void LocationsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbCon.Close();
        }

        private void PopulateComboBoxes()
        {
            MySqlDataReader provinceSDR = new MySqlCommand("select provinceID from province", dbCon.Connection).ExecuteReader();
            while (provinceSDR.Read())
            {
                cbxProvince.Items.Add(provinceSDR.GetString(0));
            }
            provinceSDR.Close();

            MySqlDataReader typeSDR = new MySqlCommand("select locationTypeID from locationType", dbCon.Connection).ExecuteReader();
            while (typeSDR.Read())
            {
                cbxType.Items.Add(typeSDR.GetString(0));
            }
            typeSDR.Close();
        }

        private void PopulateDGV()
        {
            //populate
            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.Connection = dbCon.Connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = SQLCommands.LOCATION;
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dgvLocations.DataSource = dtRecord;
            dgvLocations.ReadOnly = true;

            //hide unwanted collums and change header names
            for (int i = 0; i < dgvLocations.Columns.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvLocations.Columns[i].HeaderText = "Location ID";
                        break;

                    case 1:
                        dgvLocations.Columns[i].HeaderText = "Location Name";
                        break;

                    case 2:
                        dgvLocations.Columns[i].HeaderText = "Address";
                        break;

                    case 4:
                        dgvLocations.Columns[i].HeaderText = "Province";
                        break;

                    case 8:
                        dgvLocations.Columns[i].HeaderText = "Location Type";
                        break;

                    default:
                        dgvLocations.Columns[i].Visible = false;
                        break;
                }
            }

            CheckActive();
        }
    }
}
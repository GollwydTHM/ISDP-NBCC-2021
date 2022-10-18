using ISDP_AlexanderK.db;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ISDP_AlexanderK.forms
{
    public partial class UserListMessageForm : Form
    {
        private DBConnection dbCon = new DBConnection();
        public string[] userArray = { };

        public UserListMessageForm()
        {
            InitializeComponent();
        }

        private void UserListMessageForm_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
                PopulateDGV();
        }

        private void PopulateDGV()
        {
            //populate
            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.Connection = dbCon.Connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = SQLCommands.MESSAGEUSERLIST;
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dgvUsers.DataSource = dtRecord;
            dgvUsers.ReadOnly = true;

            //hide unwanted collums and change header names
            for (int i = 0; i < dgvUsers.Columns.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvUsers.Columns[i].HeaderText = "ID";
                        break;

                    case 1:
                        dgvUsers.Columns[i].HeaderText = "Username";
                        break;

                    case 2:
                        dgvUsers.Columns[i].HeaderText = "First Name";
                        break;

                    case 3:
                        dgvUsers.Columns[i].HeaderText = "Last Name";
                        break;

                    case 4:
                        dgvUsers.Columns[i].HeaderText = "Location";
                        break;

                    case 5:
                        dgvUsers.Columns[i].HeaderText = "Email";
                        break;

                    case 6:
                        dgvUsers.Columns[i].HeaderText = "Role";
                        break;

                    default:
                        dgvUsers.Columns[i].Visible = false;
                        break;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                string id = dgvUsers.SelectedRows[0].Cells[0].Value.ToString();
                string username = dgvUsers.SelectedRows[0].Cells[1].Value.ToString();
                userArray = new string[] { id, username };
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
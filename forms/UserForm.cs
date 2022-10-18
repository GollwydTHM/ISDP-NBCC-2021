using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ISDP_AlexanderK
{
    public partial class UserForm : Form
    {
        public UserForm(User userVar)
        {
            InitializeComponent();
        }

        private DBConnection dbCon = new DBConnection();

        private void user_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                MySqlCommand sqlCmd = new MySqlCommand();
                sqlCmd.Connection = dbCon.Connection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = SQLCommands.USER;
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                dgvUsers.DataSource = dtRecord;
                dgvUsers.ReadOnly = true;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            RegisterForm reg = new RegisterForm();
            reg.ShowDialog();
        }
    }
}
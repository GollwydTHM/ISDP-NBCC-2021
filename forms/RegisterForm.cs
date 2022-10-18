using ISDP_AlexanderK.db;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ISDP_AlexanderK
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private DBConnection dbCon = new DBConnection();

        private void button1_Click(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                MySqlCommand sqlCmd = new MySqlCommand();
            }

            this.Close();
        }
    }
}
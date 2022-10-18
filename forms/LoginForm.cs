using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Windows.Forms;

namespace ISDP_AlexanderK
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private DBConnection dbCon = new DBConnection();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Password = "";
            bool IsExist = false;
            if (dbCon.IsConnect())
            {
                MySqlCommand cmd = new MySqlCommand("select password from user where active = '1' and username='" + txtUsername.Text + "'", dbCon.Connection);
                MySqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    Password = sdr.GetString(0);  //get the user password from db if the user name is exist in that.
                    IsExist = true;
                }
                sdr.Close();

                if (IsExist)  //if record exis in db , it will return true, otherwise it will return false
                {
                    if (Password.Equals(txtPassword.Text))
                    {
                        MessageBox.Show("Login Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        User user = buildUser();

                        new Audit("Login", user.UserID, "", $"{txtUsername.Text} logged in");

                        MainMenuForm menu = new MainMenuForm(user);
                        menu.ShowDialog();
                        //dbCon.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password is wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else  //showing the error message if user credential is wrong
                {
                    MessageBox.Show("Please enter the valid credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private User buildUser()
        {
            User user = new User();

            MySqlDataReader usersdr = new MySqlCommand(SQLCommands.USERCLASS + "'" + txtUsername.Text + "'", dbCon.Connection).ExecuteReader();
            if (usersdr.Read())
            {
                user.UserID = usersdr.GetString(0);
                user.FirstName = usersdr.GetString(1);
                user.LastName = usersdr.GetString(2);
                user.Email = usersdr.GetString(3);
                user.LocationID = usersdr.GetString(4);
                user.RoleID = usersdr.GetString(5);
            }
            usersdr.Close();

            MySqlDataReader permissionsdr = new MySqlCommand($"select permissionID from user_permission where userID = '{user.UserID}'", dbCon.Connection).ExecuteReader();
            ArrayList permission = new ArrayList();
            while (permissionsdr.Read())
            {
                permission.Add(permissionsdr[0]);
            }

            user.Permissions = permission;
            permissionsdr.Close();

            return user;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
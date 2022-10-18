using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Windows.Forms;

namespace ISDP_AlexanderK.forms
{
    public partial class CreateMessageForm : Form
    {
        private DBConnection dbCon = new DBConnection();
        private User user = new User();
        private ArrayList Users = new ArrayList();

        public CreateMessageForm(User userTemp)
        {
            if (dbCon.IsConnect())
            {
                user = userTemp;
                InitializeComponent();
            }
        }

        public CreateMessageForm(User userTemp, string[] reply)
        {
            if (dbCon.IsConnect())
            {
                user = userTemp;
                InitializeComponent();

                txtMessageBody.AppendText($"Reply to message 'N.{reply[0]}' sent by '{reply[1]}' at '{reply[2]}'.");

                if (reply[3] != "")
                {
                    txtMessageBody.AppendText(Environment.NewLine);
                    txtMessageBody.AppendText($"Order ID Attached: {reply[3]}.");
                    lnkOrderLink.Text = reply[3];
                    lnkOrderLink.Visible = true;
                    lblOrderID.Visible = true;
                }

                txtMessageBody.AppendText(Environment.NewLine);
                txtMessageBody.AppendText("---------------------------------------");
                txtMessageBody.AppendText(Environment.NewLine);
                txtMessageBody.AppendText(Environment.NewLine);

                lstUsers.Items.Add(reply[1]);
            }
        }

        private void btnAttachOrder_Click(object sender, System.EventArgs e)
        {
            OrderListMessageForm olmf = new OrderListMessageForm();
            olmf.ShowDialog();

            string orderid = olmf.id;

            if (orderid != "")
            {
                lnkOrderLink.Text = orderid;
                lnkOrderLink.Visible = true;
                lblOrderID.Visible = true;
            }
        }

        private void btnDetachOrder_Click(object sender, System.EventArgs e)
        {
            lnkOrderLink.Text = "";
            lnkOrderLink.Visible = false;
            lblOrderID.Visible = false;
        }

        private void btnAddUser_Click(object sender, System.EventArgs e)
        {
            bool duplicate = false;
            UserListMessageForm ulmf = new UserListMessageForm();
            ulmf.ShowDialog();
            string[] userTemp = ulmf.userArray;
            if (userTemp.Length > 0)
            {
                foreach (string[] user in Users)
                {
                    if (user[0] == userTemp[0]) duplicate = true;
                    break;
                }
                if (!duplicate)
                {
                    Users.Add(userTemp);
                    lstUsers.Items.Add(userTemp[1]);
                }
            }
        }

        private void btnRemoveUser_Click(object sender, System.EventArgs e)
        {
            lstUsers.Items.RemoveAt(lstUsers.SelectedIndex);
        }

        private void btnSend_Click(object sender, System.EventArgs e)
        {
            if (txtMessageBody.TextLength <= 0)
            {
                MessageBox.Show("Message can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (lstUsers.Items.Count <= 0)
            {
                MessageBox.Show("Must select at least one user to send the message!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (string username in lstUsers.Items)
                {
                    string userID = GetUserID(username);
                    string transactionString = lnkOrderLink.Text != "" ? $"transactionID = {lnkOrderLink.Text}," : "";
                    MySqlCommand addCommand = new MySqlCommand($"INSERT INTO message SET senderID = {user.UserID}, receiverID = {userID}, {transactionString} details = \"{txtMessageBody.Text}\"", dbCon.Connection);
                    addCommand.ExecuteNonQuery();
                    addCommand.Dispose();

                    new Audit($"Message Created", user.UserID, "", $"User {user.UserID} sent a message to user {userID}");
                }

                this.Close();
            }
        }

        private void lnkOrderLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AttachedOrderForm aof = new AttachedOrderForm(lnkOrderLink.Text);
            aof.ShowDialog();
        }

        private string GetUserID(string name)
        {
            string userID = "";
            foreach (string[] user in Users)
            {
                string username = user[1];
                if (username == name)
                {
                    userID = user[0];
                    break;
                }
            }

            if (userID == "")
            {
                MySqlDataReader userSDR = new MySqlCommand($"SELECT userID FROM user WHERE username = '{name}'", dbCon.Connection).ExecuteReader();
                if (userSDR.Read())
                    userID = userSDR.GetString(0);
                userSDR.Close();
            }

            return userID;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
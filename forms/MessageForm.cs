using ISDP_AlexanderK.db;
using ISDP_AlexanderK.entity;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ISDP_AlexanderK.forms
{
    public partial class MessageForm : Form
    {
        private DBConnection dbCon = new DBConnection();
        private User user = new User();

        public MessageForm(User userVar)
        {
            user = userVar;
            InitializeComponent();
        }

        private void dgvMessages_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMessages.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvMessages.SelectedRows[0];

                txtMessageBody.Text = row.Cells[7].Value.ToString();
                lnkOrderLink.Text = row.Cells[6].Value.ToString();
                txtSender.Text = row.Cells[2].Value.ToString();
                txtDate.Text = row.Cells[4].Value.ToString();
                btnMark.Enabled = true;
            }
            else
            {
                txtMessageBody.Text = "";
                lnkOrderLink.Text = "";
                txtSender.Text = "";
                txtDate.Text = "";
                btnMark.Enabled = false;
            }

            if (lnkOrderLink.Text != "")
            {
                lnkOrderLink.Visible = true;
                lblOrderID.Visible = true;
            }
            else
            {
                lnkOrderLink.Visible = false;
                lblOrderID.Visible = false;
            }
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                PopulateDGV();
            }
        }

        private void PopulateDGV()
        {
            //populate
            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.Connection = dbCon.Connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = SQLCommands.MESSAGERECEIVERLIST + user.UserID;
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dgvMessages.DataSource = dtRecord;
            dgvMessages.ReadOnly = true;

            //hide unwanted collums and change header names
            for (int i = 0; i < dgvMessages.Columns.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvMessages.Columns[i].HeaderText = "ID";
                        break;

                    case 2:
                        dgvMessages.Columns[i].HeaderText = "Sender";
                        break;

                    case 4:
                        dgvMessages.Columns[i].HeaderText = "Date";
                        break;

                    case 6:
                        dgvMessages.Columns[i].HeaderText = "Order";
                        break;

                    default:
                        dgvMessages.Columns[i].Visible = false;
                        break;
                }
            }

            CheckActive();
        }

        private void CheckActive()
        {
            for (int i = 0; i < dgvMessages.Rows.Count; i++)
            {
                if (dgvMessages.Rows[i].Cells[5].Value.ToString() == "")
                {
                    dgvMessages.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                }
                else
                {
                    dgvMessages.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateMessageForm cmf = new CreateMessageForm(user);
            cmf.ShowDialog();
            PopulateDGV();
        }

        private void lnkOrderLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AttachedOrderForm aof = new AttachedOrderForm(lnkOrderLink.Text);
            aof.ShowDialog();
        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            if (dgvMessages.SelectedRows.Count > 0)
            {
                if (dgvMessages.SelectedRows[0].Cells[5].Value.ToString() == "")
                {
                    MySqlCommand editCommand = new MySqlCommand($"UPDATE message SET endDate = Now() WHERE messageID = '{dgvMessages.SelectedRows[0].Cells[0].Value}'", dbCon.Connection);
                    editCommand.ExecuteNonQuery();
                    editCommand.Dispose();
                    PopulateDGV();
                }
            }
        }

        private void dgvMessages_Sorted(object sender, EventArgs e)
        {
            CheckActive();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            string[] reply = { dgvMessages.SelectedRows[0].Cells[0].Value.ToString(), txtSender.Text, txtDate.Text, lnkOrderLink.Text };
            CreateMessageForm cmf = new CreateMessageForm(user, reply);
            cmf.ShowDialog();
            PopulateDGV();
        }
    }
}
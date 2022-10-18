using ISDP_AlexanderK.db;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ISDP_AlexanderK.forms
{
    public partial class LossReturnViewList : Form
    {
        private DBConnection dbCon = new DBConnection();

        public LossReturnViewList(string version)
        {
            if (dbCon.IsConnect())
            {
                InitializeComponent();
                if (version == "Return")
                {
                    cbxOptions.Items.Add("RETURN");
                    cbxOptions.Items.Add("LOSS");
                }
                else
                {
                    cbxOptions.Items.Add("LOSS");
                    cbxOptions.Items.Add("DAMAGE");
                }
                cbxOptions.SelectedIndex = 0;
            }
        }

        private void cbxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void LossReturnViewList_Load(object sender, EventArgs e)
        {
            PopulateDGV();
        }

        private void PopulateDGV()
        {
            //populate
            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.Connection = dbCon.Connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = SQLCommands.LOSSRETURNVIEW + $"'{cbxOptions.SelectedItem}'";
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dgvOrders.DataSource = dtRecord;
            dgvOrders.ReadOnly = true;

            for (int i = 0; i < dgvOrders.Columns.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvOrders.Columns[i].HeaderText = "Order ID";
                        break;

                    case 1:
                        dgvOrders.Columns[i].HeaderText = "Type";
                        break;

                    case 2:
                        dgvOrders.Columns[i].HeaderText = "Date";
                        break;

                    case 3:
                        dgvOrders.Columns[i].HeaderText = "Location";
                        break;

                    case 4:
                        dgvOrders.Columns[i].HeaderText = "Item ID";
                        break;

                    case 5:
                        dgvOrders.Columns[i].HeaderText = "Quantity";
                        break;

                    case 6:
                        dgvOrders.Columns[i].HeaderText = "Item Name";
                        break;

                    case 7:
                        dgvOrders.Columns[i].HeaderText = "Item Desc.";
                        break;

                    case 8:
                        dgvOrders.Columns[i].HeaderText = "Notes";
                        break;

                    default:
                        dgvOrders.Columns[i].Visible = false;
                        break;
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e) => this.Close();
    }
}
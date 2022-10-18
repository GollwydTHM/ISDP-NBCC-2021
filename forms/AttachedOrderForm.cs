using ISDP_AlexanderK.db;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ISDP_AlexanderK.forms
{
    public partial class AttachedOrderForm : Form
    {
        private DBConnection dbCon = new DBConnection();
        private string orderID = "";

        public AttachedOrderForm(string id)
        {
            orderID = id;
            InitializeComponent();
        }

        private void AttachedOrderForm_Load(object sender, EventArgs e)
        {
            if (dbCon.IsConnect())
            {
                MySqlDataReader orderSDR = new MySqlCommand("SELECT * FROM txn WHERE txnID = " + orderID, dbCon.Connection).ExecuteReader();

                if (orderSDR.Read())
                {
                    txtOrderID.Text = orderSDR.GetString(0);
                    txtOrderType.Text = orderSDR.GetString(1);
                    txtCreationDate.Text = orderSDR.GetString(2);
                    txtArrivalDate.Text = !orderSDR.IsDBNull(3)? orderSDR.GetString(3):"";
                    txtVehicle.Text = !orderSDR.IsDBNull(4)? orderSDR.GetString(4) : "";
                    txtOrigin.Text = !orderSDR.IsDBNull(5) ? orderSDR.GetString(5) : "";
                    txtDestination.Text = !orderSDR.IsDBNull(6)? orderSDR.GetString(6) : "";
                    txtStatus.Text = orderSDR.GetString(7);
                    txtOrderNote.Text = !orderSDR.IsDBNull(8)? orderSDR.GetString(8) : "";
                }
                orderSDR.Close();
                PopulateDGV();
            }
        }

        private void PopulateDGV()
        {
            //populate
            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.Connection = dbCon.Connection;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = SQLCommands.ITEMSLIST + $"'{orderID}'";
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dgvItems.DataSource = dtRecord;
            dgvItems.ReadOnly = true;

            for (int i = 0; i < dgvItems.Columns.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvItems.Columns[i].HeaderText = "Order ID";
                        break;

                    case 1:
                        dgvItems.Columns[i].HeaderText = "Item ID";
                        break;

                    case 2:
                        dgvItems.Columns[i].HeaderText = "Item Name";
                        break;

                    case 3:
                        dgvItems.Columns[i].HeaderText = "Quantity";
                        break;

                    case 4:
                        dgvItems.Columns[i].HeaderText = "Total";
                        break;

                    default:
                        dgvItems.Columns[i].Visible = false;
                        break;
                }
            }
        }
    }
}
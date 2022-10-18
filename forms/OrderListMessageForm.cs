using ISDP_AlexanderK.db;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISDP_AlexanderK.forms
{
    public partial class OrderListMessageForm : Form
    {
        private DBConnection dbCon = new DBConnection();
        public string id = "";

        public OrderListMessageForm()
        {
            InitializeComponent();
        }

        private void OrderListMessageForm_Load(object sender, EventArgs e)
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
            sqlCmd.CommandText = SQLCommands.MESSAGEORDERLIST;
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dgvOrders.DataSource = dtRecord;
            dgvOrders.ReadOnly = true;

            //hide unwanted collums and change header names
            for (int i = 0; i < dgvOrders.Columns.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvOrders.Columns[i].HeaderText = "Order ID";
                        break;

                    case 1:
                        dgvOrders.Columns[i].HeaderText = "Order Type";
                        break;

                    case 2:
                        dgvOrders.Columns[i].HeaderText = "Creation Date";
                        break;

                    case 3:
                        dgvOrders.Columns[i].HeaderText = "Estimated Arrival";
                        break;

                    case 5:
                        dgvOrders.Columns[i].HeaderText = "Origin";
                        break;

                    case 6:
                        dgvOrders.Columns[i].HeaderText = "Destination";
                        break;

                    case 7:
                        dgvOrders.Columns[i].HeaderText = "Status";
                        break;

                    default:
                        dgvOrders.Columns[i].Visible = false;
                        break;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                id = dgvOrders.SelectedRows[0].Cells[0].Value.ToString();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using ISDP_AlexanderK.entity;
using ISDP_AlexanderK.forms;
using System;
using System.Windows.Forms;

namespace ISDP_AlexanderK
{
    public partial class MainMenuForm : Form
    {
        private User user = new User();

        public MainMenuForm(User userVar)
        {
            user = userVar;
            InitializeComponent();
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            DeliveryForm del = new DeliveryForm(user);
            del.ShowDialog();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            InventoryForm inv = new InventoryForm(user);
            inv.ShowDialog();
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            bool permission = false;
            for (int i = 0; i < user.Permissions.Count; i++)
            {
                if (user.Permissions[i].ToString() == "VIEWLOCATION")
                {
                    permission = true;
                    break;
                }
            }

            if (permission)
            {
                LocationsForm loc = new LocationsForm(user);
                loc.ShowDialog();
            }
            else
                MessageBox.Show("You don't have permission to view Location Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnModifyRecords_Click(object sender, EventArgs e)
        {
            ModifyRecordsForm mrf = new ModifyRecordsForm(user);
            mrf.ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            bool permission = false;
            for (int i = 0; i < user.Permissions.Count; i++)
            {
                if (user.Permissions[i].ToString() == "VIEWORDERS")
                {
                    permission = true;
                    break;
                }
            }

            if (permission)
            {
                OrdersForm ord = new OrdersForm(user);
                ord.ShowDialog();
            }
            else
                MessageBox.Show("You don't have permission to view Order Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            bool permission = false;
            for (int i = 0; i < user.Permissions.Count; i++)
            {
                if (user.Permissions[i].ToString() == "READUSER")
                {
                    permission = true;
                    break;
                }
            }

            if (permission)
            {
                UserForm usr = new UserForm(user);
                usr.ShowDialog();
            }
            else
                MessageBox.Show("You don't have permission to view User Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            if (user.RoleID == "999")
            {
                lblName.Text = "Admin";
                btnModifyRecords.Enabled = true;
            }
            else
                lblName.Text = user.FirstName + " " + user.LastName;
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            StoreForm str = new StoreForm(user);
            str.ShowDialog();
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Audit("Log out", user.UserID, "", $"{user.FirstName} logged out");
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductForm pro = new ProductForm(user);
            pro.ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm sup = new SupplierForm(user);
            sup.ShowDialog();
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            MessageForm mes = new MessageForm(user);
            mes.ShowDialog();
        }

        private void btnLoss_Click(object sender, EventArgs e)
        {
            LossReturnForm lrfl = new LossReturnForm(user, "Loss");
            lrfl.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            LossReturnForm lrfr = new LossReturnForm(user, "Return");
            lrfr.ShowDialog();
        }
    }
}
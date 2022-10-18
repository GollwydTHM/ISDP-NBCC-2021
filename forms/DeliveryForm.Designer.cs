
namespace ISDP_AlexanderK.forms
{
    partial class DeliveryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDelivey = new System.Windows.Forms.DataGridView();
            this.grbOrder = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeliver = new System.Windows.Forms.Button();
            this.btnTransport = new System.Windows.Forms.Button();
            this.lstRoutes = new System.Windows.Forms.ListBox();
            this.txtDeliveryDate = new System.Windows.Forms.TextBox();
            this.txtVehicle = new System.Windows.Forms.TextBox();
            this.btnPickup = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeliveryDetails = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDeliveryID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.lnkLogout = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelivey)).BeginInit();
            this.grbOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDelivey
            // 
            this.dgvDelivey.AllowUserToAddRows = false;
            this.dgvDelivey.AllowUserToDeleteRows = false;
            this.dgvDelivey.AllowUserToResizeRows = false;
            this.dgvDelivey.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDelivey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDelivey.Location = new System.Drawing.Point(26, 96);
            this.dgvDelivey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDelivey.MultiSelect = false;
            this.dgvDelivey.Name = "dgvDelivey";
            this.dgvDelivey.ReadOnly = true;
            this.dgvDelivey.RowHeadersVisible = false;
            this.dgvDelivey.RowHeadersWidth = 51;
            this.dgvDelivey.RowTemplate.Height = 24;
            this.dgvDelivey.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDelivey.Size = new System.Drawing.Size(820, 295);
            this.dgvDelivey.TabIndex = 27;
            this.dgvDelivey.SelectionChanged += new System.EventHandler(this.dgvDelivey_SelectionChanged);
            // 
            // grbOrder
            // 
            this.grbOrder.Controls.Add(this.btnRefresh);
            this.grbOrder.Controls.Add(this.btnDeliver);
            this.grbOrder.Controls.Add(this.btnTransport);
            this.grbOrder.Controls.Add(this.lstRoutes);
            this.grbOrder.Controls.Add(this.txtDeliveryDate);
            this.grbOrder.Controls.Add(this.txtVehicle);
            this.grbOrder.Controls.Add(this.btnPickup);
            this.grbOrder.Controls.Add(this.label8);
            this.grbOrder.Controls.Add(this.txtWeight);
            this.grbOrder.Controls.Add(this.label2);
            this.grbOrder.Controls.Add(this.txtDeliveryDetails);
            this.grbOrder.Controls.Add(this.label3);
            this.grbOrder.Controls.Add(this.label11);
            this.grbOrder.Controls.Add(this.txtDeliveryID);
            this.grbOrder.Controls.Add(this.label1);
            this.grbOrder.Location = new System.Drawing.Point(888, 58);
            this.grbOrder.Margin = new System.Windows.Forms.Padding(2);
            this.grbOrder.Name = "grbOrder";
            this.grbOrder.Padding = new System.Windows.Forms.Padding(2);
            this.grbOrder.Size = new System.Drawing.Size(505, 596);
            this.grbOrder.TabIndex = 28;
            this.grbOrder.TabStop = false;
            this.grbOrder.Text = "Delivery";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(190, 495);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(122, 64);
            this.btnRefresh.TabIndex = 44;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeliver
            // 
            this.btnDeliver.BackColor = System.Drawing.Color.White;
            this.btnDeliver.Enabled = false;
            this.btnDeliver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeliver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeliver.Location = new System.Drawing.Point(354, 407);
            this.btnDeliver.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeliver.Name = "btnDeliver";
            this.btnDeliver.Size = new System.Drawing.Size(122, 64);
            this.btnDeliver.TabIndex = 43;
            this.btnDeliver.Text = "Deliver";
            this.btnDeliver.UseVisualStyleBackColor = false;
            this.btnDeliver.Click += new System.EventHandler(this.btnDeliver_Click);
            // 
            // btnTransport
            // 
            this.btnTransport.BackColor = System.Drawing.Color.White;
            this.btnTransport.Enabled = false;
            this.btnTransport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransport.Location = new System.Drawing.Point(190, 407);
            this.btnTransport.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransport.Name = "btnTransport";
            this.btnTransport.Size = new System.Drawing.Size(122, 64);
            this.btnTransport.TabIndex = 42;
            this.btnTransport.Text = "Transport";
            this.btnTransport.UseVisualStyleBackColor = false;
            this.btnTransport.Click += new System.EventHandler(this.btnTransport_Click);
            // 
            // lstRoutes
            // 
            this.lstRoutes.Enabled = false;
            this.lstRoutes.FormattingEnabled = true;
            this.lstRoutes.ItemHeight = 20;
            this.lstRoutes.Location = new System.Drawing.Point(322, 52);
            this.lstRoutes.Name = "lstRoutes";
            this.lstRoutes.Size = new System.Drawing.Size(154, 104);
            this.lstRoutes.TabIndex = 41;
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.Enabled = false;
            this.txtDeliveryDate.Location = new System.Drawing.Point(167, 61);
            this.txtDeliveryDate.MaxLength = 4;
            this.txtDeliveryDate.Name = "txtDeliveryDate";
            this.txtDeliveryDate.Size = new System.Drawing.Size(132, 26);
            this.txtDeliveryDate.TabIndex = 40;
            // 
            // txtVehicle
            // 
            this.txtVehicle.Enabled = false;
            this.txtVehicle.Location = new System.Drawing.Point(24, 130);
            this.txtVehicle.MaxLength = 4;
            this.txtVehicle.Name = "txtVehicle";
            this.txtVehicle.Size = new System.Drawing.Size(124, 26);
            this.txtVehicle.TabIndex = 39;
            // 
            // btnPickup
            // 
            this.btnPickup.BackColor = System.Drawing.Color.White;
            this.btnPickup.Enabled = false;
            this.btnPickup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickup.Location = new System.Drawing.Point(26, 407);
            this.btnPickup.Margin = new System.Windows.Forms.Padding(2);
            this.btnPickup.Name = "btnPickup";
            this.btnPickup.Size = new System.Drawing.Size(122, 64);
            this.btnPickup.TabIndex = 29;
            this.btnPickup.Text = "Pickup";
            this.btnPickup.UseVisualStyleBackColor = false;
            this.btnPickup.Click += new System.EventHandler(this.btnPickup_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Vehicle:";
            // 
            // txtWeight
            // 
            this.txtWeight.Enabled = false;
            this.txtWeight.Location = new System.Drawing.Point(167, 130);
            this.txtWeight.MaxLength = 4;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(132, 26);
            this.txtWeight.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Weight:";
            // 
            // txtDeliveryDetails
            // 
            this.txtDeliveryDetails.Enabled = false;
            this.txtDeliveryDetails.Location = new System.Drawing.Point(25, 195);
            this.txtDeliveryDetails.Multiline = true;
            this.txtDeliveryDetails.Name = "txtDeliveryDetails";
            this.txtDeliveryDetails.Size = new System.Drawing.Size(451, 159);
            this.txtDeliveryDetails.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Details:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(163, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Delivery Date:";
            // 
            // txtDeliveryID
            // 
            this.txtDeliveryID.Enabled = false;
            this.txtDeliveryID.Location = new System.Drawing.Point(25, 61);
            this.txtDeliveryID.MaxLength = 4;
            this.txtDeliveryID.Name = "txtDeliveryID";
            this.txtDeliveryID.Size = new System.Drawing.Size(123, 26);
            this.txtDeliveryID.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Delivery ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(21, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 25);
            this.label4.TabIndex = 43;
            this.label4.Text = "Orders:";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(26, 429);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(823, 225);
            this.dgvOrders.TabIndex = 42;
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 69);
            this.label9.TabIndex = 45;
            this.label9.Text = "Bullseye";
            // 
            // lnkLogout
            // 
            this.lnkLogout.AutoSize = true;
            this.lnkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLogout.ForeColor = System.Drawing.Color.Yellow;
            this.lnkLogout.LinkColor = System.Drawing.Color.Yellow;
            this.lnkLogout.Location = new System.Drawing.Point(1306, 22);
            this.lnkLogout.Name = "lnkLogout";
            this.lnkLogout.Size = new System.Drawing.Size(87, 25);
            this.lnkLogout.TabIndex = 46;
            this.lnkLogout.TabStop = true;
            this.lnkLogout.Text = "Go Back";
            this.lnkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogout_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Yellow;
            this.label12.Location = new System.Drawing.Point(339, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 44);
            this.label12.TabIndex = 47;
            this.label12.Text = "Delivery";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Location = new System.Drawing.Point(646, 52);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(200, 26);
            this.dtpDeliveryDate.TabIndex = 48;
            this.dtpDeliveryDate.ValueChanged += new System.EventHandler(this.dtpDeliveryDate_ValueChanged);
            // 
            // DeliveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(171)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(1448, 693);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lnkLogout);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.grbOrder);
            this.Controls.Add(this.dgvDelivey);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DeliveryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliveryForm";
            this.Load += new System.EventHandler(this.DeliveryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelivey)).EndInit();
            this.grbOrder.ResumeLayout(false);
            this.grbOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDelivey;
        private System.Windows.Forms.GroupBox grbOrder;
        private System.Windows.Forms.TextBox txtDeliveryDate;
        private System.Windows.Forms.TextBox txtVehicle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeliveryDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDeliveryID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.ListBox lstRoutes;
        private System.Windows.Forms.Button btnPickup;
        private System.Windows.Forms.Button btnDeliver;
        private System.Windows.Forms.Button btnTransport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel lnkLogout;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
    }
}
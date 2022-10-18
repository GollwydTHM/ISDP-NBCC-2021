
namespace ISDP_AlexanderK.forms
{
    partial class AttachedOrderForm
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
            this.grbOrder = new System.Windows.Forms.GroupBox();
            this.txtOrderType = new System.Windows.Forms.TextBox();
            this.txtVehicle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrigin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtArrivalDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCreationDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.grbOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // grbOrder
            // 
            this.grbOrder.Controls.Add(this.txtOrderType);
            this.grbOrder.Controls.Add(this.txtVehicle);
            this.grbOrder.Controls.Add(this.label8);
            this.grbOrder.Controls.Add(this.txtDestination);
            this.grbOrder.Controls.Add(this.label6);
            this.grbOrder.Controls.Add(this.txtOrigin);
            this.grbOrder.Controls.Add(this.label7);
            this.grbOrder.Controls.Add(this.txtArrivalDate);
            this.grbOrder.Controls.Add(this.label5);
            this.grbOrder.Controls.Add(this.txtCreationDate);
            this.grbOrder.Controls.Add(this.label4);
            this.grbOrder.Controls.Add(this.txtStatus);
            this.grbOrder.Controls.Add(this.label2);
            this.grbOrder.Controls.Add(this.txtOrderNote);
            this.grbOrder.Controls.Add(this.label3);
            this.grbOrder.Controls.Add(this.label11);
            this.grbOrder.Controls.Add(this.txtOrderID);
            this.grbOrder.Controls.Add(this.label1);
            this.grbOrder.Location = new System.Drawing.Point(14, 11);
            this.grbOrder.Margin = new System.Windows.Forms.Padding(2);
            this.grbOrder.Name = "grbOrder";
            this.grbOrder.Padding = new System.Windows.Forms.Padding(2);
            this.grbOrder.Size = new System.Drawing.Size(997, 288);
            this.grbOrder.TabIndex = 22;
            this.grbOrder.TabStop = false;
            this.grbOrder.Text = "Order";
            // 
            // txtOrderType
            // 
            this.txtOrderType.Location = new System.Drawing.Point(168, 61);
            this.txtOrderType.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderType.MaxLength = 4;
            this.txtOrderType.Name = "txtOrderType";
            this.txtOrderType.ReadOnly = true;
            this.txtOrderType.Size = new System.Drawing.Size(156, 27);
            this.txtOrderType.TabIndex = 40;
            // 
            // txtVehicle
            // 
            this.txtVehicle.Location = new System.Drawing.Point(343, 227);
            this.txtVehicle.Margin = new System.Windows.Forms.Padding(4);
            this.txtVehicle.MaxLength = 4;
            this.txtVehicle.Name = "txtVehicle";
            this.txtVehicle.ReadOnly = true;
            this.txtVehicle.Size = new System.Drawing.Size(138, 27);
            this.txtVehicle.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(338, 196);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Vehicle:";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(183, 227);
            this.txtDestination.Margin = new System.Windows.Forms.Padding(4);
            this.txtDestination.MaxLength = 4;
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.ReadOnly = true;
            this.txtDestination.Size = new System.Drawing.Size(145, 27);
            this.txtDestination.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 197);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Destination:";
            // 
            // txtOrigin
            // 
            this.txtOrigin.Location = new System.Drawing.Point(23, 227);
            this.txtOrigin.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrigin.MaxLength = 4;
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.ReadOnly = true;
            this.txtOrigin.Size = new System.Drawing.Size(145, 27);
            this.txtOrigin.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 196);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 34;
            this.label7.Text = "Origin:";
            // 
            // txtArrivalDate
            // 
            this.txtArrivalDate.Location = new System.Drawing.Point(260, 146);
            this.txtArrivalDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtArrivalDate.MaxLength = 4;
            this.txtArrivalDate.Name = "txtArrivalDate";
            this.txtArrivalDate.ReadOnly = true;
            this.txtArrivalDate.Size = new System.Drawing.Size(223, 27);
            this.txtArrivalDate.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Estimated Arrival:";
            // 
            // txtCreationDate
            // 
            this.txtCreationDate.Location = new System.Drawing.Point(23, 146);
            this.txtCreationDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtCreationDate.MaxLength = 4;
            this.txtCreationDate.Name = "txtCreationDate";
            this.txtCreationDate.ReadOnly = true;
            this.txtCreationDate.Size = new System.Drawing.Size(223, 27);
            this.txtCreationDate.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Creation Date:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(344, 61);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatus.MaxLength = 4;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(138, 27);
            this.txtStatus.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Status:";
            // 
            // txtOrderNote
            // 
            this.txtOrderNote.Location = new System.Drawing.Point(504, 61);
            this.txtOrderNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderNote.Multiline = true;
            this.txtOrderNote.Name = "txtOrderNote";
            this.txtOrderNote.ReadOnly = true;
            this.txtOrderNote.Size = new System.Drawing.Size(465, 193);
            this.txtOrderNote.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Note:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(166, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Order Type:";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(23, 61);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderID.MaxLength = 4;
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(125, 27);
            this.txtOrderID.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order ID:";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(14, 336);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(4);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(997, 326);
            this.dgvItems.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Items:";
            // 
            // AttachedOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(171)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(1031, 684);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.grbOrder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AttachedOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttachedOrderForm";
            this.Load += new System.EventHandler(this.AttachedOrderForm_Load);
            this.grbOrder.ResumeLayout(false);
            this.grbOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbOrder;
        private System.Windows.Forms.TextBox txtOrderType;
        private System.Windows.Forms.TextBox txtVehicle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrigin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtArrivalDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCreationDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label label9;
    }
}

namespace ISDP_AlexanderK.forms
{
    partial class LossReturnForm
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
            this.grbItem = new System.Windows.Forms.GroupBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudItemID = new System.Windows.Forms.NumericUpDown();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtCase = new System.Windows.Forms.TextBox();
            this.txtItemCategory = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.txtRetail = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnViewList = new System.Windows.Forms.Button();
            this.grbRecord = new System.Windows.Forms.GroupBox();
            this.lblPlaceholder = new System.Windows.Forms.Label();
            this.cbxOptions = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grbItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemID)).BeginInit();
            this.grbRecord.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbItem
            // 
            this.grbItem.Controls.Add(this.nudQuantity);
            this.grbItem.Controls.Add(this.label9);
            this.grbItem.Controls.Add(this.nudItemID);
            this.grbItem.Controls.Add(this.txtWeight);
            this.grbItem.Controls.Add(this.txtCase);
            this.grbItem.Controls.Add(this.txtItemCategory);
            this.grbItem.Controls.Add(this.label13);
            this.grbItem.Controls.Add(this.txtDescription);
            this.grbItem.Controls.Add(this.txtSupplier);
            this.grbItem.Controls.Add(this.txtCost);
            this.grbItem.Controls.Add(this.txtSKU);
            this.grbItem.Controls.Add(this.txtRetail);
            this.grbItem.Controls.Add(this.txtItemName);
            this.grbItem.Controls.Add(this.label14);
            this.grbItem.Controls.Add(this.label15);
            this.grbItem.Controls.Add(this.label16);
            this.grbItem.Controls.Add(this.label17);
            this.grbItem.Controls.Add(this.label18);
            this.grbItem.Controls.Add(this.label19);
            this.grbItem.Controls.Add(this.label21);
            this.grbItem.Controls.Add(this.label22);
            this.grbItem.Controls.Add(this.label23);
            this.grbItem.Location = new System.Drawing.Point(28, 91);
            this.grbItem.Margin = new System.Windows.Forms.Padding(2);
            this.grbItem.Name = "grbItem";
            this.grbItem.Padding = new System.Windows.Forms.Padding(2);
            this.grbItem.Size = new System.Drawing.Size(387, 533);
            this.grbItem.TabIndex = 25;
            this.grbItem.TabStop = false;
            this.grbItem.Text = "Item";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(196, 56);
            this.nudQuantity.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 27);
            this.nudQuantity.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 20);
            this.label9.TabIndex = 29;
            this.label9.Text = "Quantity:";
            // 
            // nudItemID
            // 
            this.nudItemID.Location = new System.Drawing.Point(25, 56);
            this.nudItemID.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudItemID.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudItemID.Name = "nudItemID";
            this.nudItemID.Size = new System.Drawing.Size(120, 27);
            this.nudItemID.TabIndex = 24;
            this.nudItemID.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudItemID.ValueChanged += new System.EventHandler(this.nudItemID_ValueChanged);
            // 
            // txtWeight
            // 
            this.txtWeight.Enabled = false;
            this.txtWeight.Location = new System.Drawing.Point(276, 231);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(83, 27);
            this.txtWeight.TabIndex = 23;
            // 
            // txtCase
            // 
            this.txtCase.Enabled = false;
            this.txtCase.Location = new System.Drawing.Point(276, 178);
            this.txtCase.Name = "txtCase";
            this.txtCase.Size = new System.Drawing.Size(83, 27);
            this.txtCase.TabIndex = 22;
            // 
            // txtItemCategory
            // 
            this.txtItemCategory.Enabled = false;
            this.txtItemCategory.Location = new System.Drawing.Point(196, 114);
            this.txtItemCategory.Name = "txtItemCategory";
            this.txtItemCategory.Size = new System.Drawing.Size(163, 27);
            this.txtItemCategory.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(192, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 20);
            this.label13.TabIndex = 20;
            this.label13.Text = "Item Category:";
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(26, 297);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(333, 196);
            this.txtDescription.TabIndex = 19;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Enabled = false;
            this.txtSupplier.Location = new System.Drawing.Point(28, 177);
            this.txtSupplier.MaxLength = 10;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(100, 27);
            this.txtSupplier.TabIndex = 16;
            // 
            // txtCost
            // 
            this.txtCost.Enabled = false;
            this.txtCost.Location = new System.Drawing.Point(27, 231);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(100, 27);
            this.txtCost.TabIndex = 15;
            // 
            // txtSKU
            // 
            this.txtSKU.Enabled = false;
            this.txtSKU.Location = new System.Drawing.Point(147, 177);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(114, 27);
            this.txtSKU.TabIndex = 14;
            // 
            // txtRetail
            // 
            this.txtRetail.Enabled = false;
            this.txtRetail.Location = new System.Drawing.Point(149, 231);
            this.txtRetail.Name = "txtRetail";
            this.txtRetail.Size = new System.Drawing.Size(112, 27);
            this.txtRetail.TabIndex = 13;
            // 
            // txtItemName
            // 
            this.txtItemName.Enabled = false;
            this.txtItemName.Location = new System.Drawing.Point(25, 114);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(155, 27);
            this.txtItemName.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 273);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 20);
            this.label14.TabIndex = 9;
            this.label14.Text = "Description:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 20);
            this.label15.TabIndex = 8;
            this.label15.Text = "Suplier:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 208);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 20);
            this.label16.TabIndex = 7;
            this.label16.Text = "Cost Price:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(145, 154);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 20);
            this.label17.TabIndex = 6;
            this.label17.Text = "SKU:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(272, 208);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 20);
            this.label18.TabIndex = 5;
            this.label18.Text = "Weight:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(144, 208);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "Retail Price:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 91);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 20);
            this.label21.TabIndex = 2;
            this.label21.Text = "Name:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(272, 153);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(91, 20);
            this.label22.TabIndex = 1;
            this.label22.Text = "Case Size:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(21, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "Item ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(192, 345);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 64);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.Black;
            this.btnSubmit.Location = new System.Drawing.Point(26, 345);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(140, 64);
            this.btnSubmit.TabIndex = 25;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(26, 154);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(306, 172);
            this.txtNote.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Note:";
            // 
            // cbxLocation
            // 
            this.cbxLocation.Enabled = false;
            this.cbxLocation.FormattingEnabled = true;
            this.cbxLocation.Location = new System.Drawing.Point(159, 37);
            this.cbxLocation.Name = "cbxLocation";
            this.cbxLocation.Size = new System.Drawing.Size(173, 28);
            this.cbxLocation.TabIndex = 33;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(22, 41);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(78, 20);
            this.lblLocation.TabIndex = 34;
            this.lblLocation.Text = "Location:";
            // 
            // btnViewList
            // 
            this.btnViewList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnViewList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewList.ForeColor = System.Drawing.Color.Black;
            this.btnViewList.Location = new System.Drawing.Point(108, 429);
            this.btnViewList.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewList.Name = "btnViewList";
            this.btnViewList.Size = new System.Drawing.Size(140, 64);
            this.btnViewList.TabIndex = 35;
            this.btnViewList.Text = "&View List";
            this.btnViewList.UseVisualStyleBackColor = false;
            this.btnViewList.Click += new System.EventHandler(this.btnViewList_Click);
            // 
            // grbRecord
            // 
            this.grbRecord.Controls.Add(this.lblPlaceholder);
            this.grbRecord.Controls.Add(this.cbxOptions);
            this.grbRecord.Controls.Add(this.btnViewList);
            this.grbRecord.Controls.Add(this.txtNote);
            this.grbRecord.Controls.Add(this.lblLocation);
            this.grbRecord.Controls.Add(this.btnSubmit);
            this.grbRecord.Controls.Add(this.cbxLocation);
            this.grbRecord.Controls.Add(this.label1);
            this.grbRecord.Controls.Add(this.btnCancel);
            this.grbRecord.Location = new System.Drawing.Point(435, 91);
            this.grbRecord.Name = "grbRecord";
            this.grbRecord.Size = new System.Drawing.Size(359, 533);
            this.grbRecord.TabIndex = 36;
            this.grbRecord.TabStop = false;
            this.grbRecord.Text = "Record";
            // 
            // lblPlaceholder
            // 
            this.lblPlaceholder.AutoSize = true;
            this.lblPlaceholder.Location = new System.Drawing.Point(22, 87);
            this.lblPlaceholder.Name = "lblPlaceholder";
            this.lblPlaceholder.Size = new System.Drawing.Size(102, 20);
            this.lblPlaceholder.TabIndex = 37;
            this.lblPlaceholder.Text = "Placeholder:";
            // 
            // cbxOptions
            // 
            this.cbxOptions.FormattingEnabled = true;
            this.cbxOptions.Location = new System.Drawing.Point(159, 83);
            this.cbxOptions.Name = "cbxOptions";
            this.cbxOptions.Size = new System.Drawing.Size(173, 28);
            this.cbxOptions.TabIndex = 36;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Yellow;
            this.lblTitle.Location = new System.Drawing.Point(492, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(232, 44);
            this.lblTitle.TabIndex = 50;
            this.lblTitle.Text = "Placeholder";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(81, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(263, 69);
            this.label10.TabIndex = 49;
            this.label10.Text = "Bullseye";
            // 
            // LossReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(171)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(823, 667);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grbItem);
            this.Controls.Add(this.grbRecord);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LossReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LossReturnForm";
            this.Load += new System.EventHandler(this.LossReturnForm_Load);
            this.grbItem.ResumeLayout(false);
            this.grbItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemID)).EndInit();
            this.grbRecord.ResumeLayout(false);
            this.grbRecord.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbItem;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.NumericUpDown nudItemID;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtCase;
        private System.Windows.Forms.TextBox txtItemCategory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.TextBox txtRetail;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnViewList;
        private System.Windows.Forms.GroupBox grbRecord;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPlaceholder;
        private System.Windows.Forms.ComboBox cbxOptions;
    }
}
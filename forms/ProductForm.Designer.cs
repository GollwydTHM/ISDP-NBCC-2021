
namespace ISDP_AlexanderK.forms
{
    partial class ProductForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grbItem = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.nudCost = new System.Windows.Forms.NumericUpDown();
            this.nudRetail = new System.Windows.Forms.NumericUpDown();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.cbxSupplier = new System.Windows.Forms.ComboBox();
            this.cbxItemCategory = new System.Windows.Forms.ComboBox();
            this.nudCaseSize = new System.Windows.Forms.NumericUpDown();
            this.nudItemID = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.txtItemNotes = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxSupplierFilter = new System.Windows.Forms.ComboBox();
            this.grbItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(351, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 44);
            this.label4.TabIndex = 58;
            this.label4.Text = "Products";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(27, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(263, 69);
            this.label10.TabIndex = 57;
            this.label10.Text = "Bullseye";
            // 
            // grbItem
            // 
            this.grbItem.Controls.Add(this.btnCancel);
            this.grbItem.Controls.Add(this.btnSave);
            this.grbItem.Controls.Add(this.nudCost);
            this.grbItem.Controls.Add(this.nudRetail);
            this.grbItem.Controls.Add(this.nudWeight);
            this.grbItem.Controls.Add(this.cbxSupplier);
            this.grbItem.Controls.Add(this.cbxItemCategory);
            this.grbItem.Controls.Add(this.nudCaseSize);
            this.grbItem.Controls.Add(this.nudItemID);
            this.grbItem.Controls.Add(this.label13);
            this.grbItem.Controls.Add(this.txtDescription);
            this.grbItem.Controls.Add(this.txtSKU);
            this.grbItem.Controls.Add(this.txtItemNotes);
            this.grbItem.Controls.Add(this.txtItemName);
            this.grbItem.Controls.Add(this.label14);
            this.grbItem.Controls.Add(this.label15);
            this.grbItem.Controls.Add(this.label16);
            this.grbItem.Controls.Add(this.label17);
            this.grbItem.Controls.Add(this.label18);
            this.grbItem.Controls.Add(this.label19);
            this.grbItem.Controls.Add(this.label20);
            this.grbItem.Controls.Add(this.label21);
            this.grbItem.Controls.Add(this.label22);
            this.grbItem.Controls.Add(this.label23);
            this.grbItem.Enabled = false;
            this.grbItem.Location = new System.Drawing.Point(872, 11);
            this.grbItem.Margin = new System.Windows.Forms.Padding(2);
            this.grbItem.Name = "grbItem";
            this.grbItem.Padding = new System.Windows.Forms.Padding(2);
            this.grbItem.Size = new System.Drawing.Size(390, 633);
            this.grbItem.TabIndex = 56;
            this.grbItem.TabStop = false;
            this.grbItem.Text = "Item";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(203, 547);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 63);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(43, 547);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 63);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // nudCost
            // 
            this.nudCost.DecimalPlaces = 2;
            this.nudCost.Location = new System.Drawing.Point(28, 232);
            this.nudCost.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudCost.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudCost.Name = "nudCost";
            this.nudCost.Size = new System.Drawing.Size(99, 27);
            this.nudCost.TabIndex = 30;
            this.nudCost.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // nudRetail
            // 
            this.nudRetail.DecimalPlaces = 2;
            this.nudRetail.Location = new System.Drawing.Point(147, 232);
            this.nudRetail.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRetail.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudRetail.Name = "nudRetail";
            this.nudRetail.Size = new System.Drawing.Size(114, 27);
            this.nudRetail.TabIndex = 29;
            this.nudRetail.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // nudWeight
            // 
            this.nudWeight.DecimalPlaces = 2;
            this.nudWeight.Location = new System.Drawing.Point(276, 232);
            this.nudWeight.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(83, 27);
            this.nudWeight.TabIndex = 28;
            this.nudWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // cbxSupplier
            // 
            this.cbxSupplier.FormattingEnabled = true;
            this.cbxSupplier.Location = new System.Drawing.Point(26, 177);
            this.cbxSupplier.Name = "cbxSupplier";
            this.cbxSupplier.Size = new System.Drawing.Size(100, 28);
            this.cbxSupplier.TabIndex = 27;
            // 
            // cbxItemCategory
            // 
            this.cbxItemCategory.FormattingEnabled = true;
            this.cbxItemCategory.Location = new System.Drawing.Point(175, 56);
            this.cbxItemCategory.Name = "cbxItemCategory";
            this.cbxItemCategory.Size = new System.Drawing.Size(176, 28);
            this.cbxItemCategory.TabIndex = 26;
            // 
            // nudCaseSize
            // 
            this.nudCaseSize.Location = new System.Drawing.Point(276, 178);
            this.nudCaseSize.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudCaseSize.Name = "nudCaseSize";
            this.nudCaseSize.Size = new System.Drawing.Size(83, 27);
            this.nudCaseSize.TabIndex = 25;
            this.nudCaseSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudItemID
            // 
            this.nudItemID.Enabled = false;
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
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(171, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 20);
            this.label13.TabIndex = 20;
            this.label13.Text = "Item Category:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(26, 297);
            this.txtDescription.MaxLength = 20000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(333, 110);
            this.txtDescription.TabIndex = 19;
            // 
            // txtSKU
            // 
            this.txtSKU.Location = new System.Drawing.Point(147, 177);
            this.txtSKU.MaxLength = 20;
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(114, 27);
            this.txtSKU.TabIndex = 14;
            // 
            // txtItemNotes
            // 
            this.txtItemNotes.Location = new System.Drawing.Point(26, 447);
            this.txtItemNotes.Multiline = true;
            this.txtItemNotes.Name = "txtItemNotes";
            this.txtItemNotes.Size = new System.Drawing.Size(333, 79);
            this.txtItemNotes.TabIndex = 12;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(25, 114);
            this.txtItemName.MaxLength = 500;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(326, 27);
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
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(22, 424);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 20);
            this.label20.TabIndex = 3;
            this.label20.Text = "Notes:";
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
            // btnDeactivate
            // 
            this.btnDeactivate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeactivate.Enabled = false;
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeactivate.Location = new System.Drawing.Point(1140, 668);
            this.btnDeactivate.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(122, 64);
            this.btnDeactivate.TabIndex = 53;
            this.btnDeactivate.Text = "&Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(1006, 668);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(122, 64);
            this.btnEdit.TabIndex = 52;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(872, 668);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 64);
            this.btnAdd.TabIndex = 51;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(28, 101);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(817, 631);
            this.dgvProducts.TabIndex = 50;
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(577, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 25);
            this.label12.TabIndex = 60;
            this.label12.Text = "Supplier:";
            // 
            // cbxSupplierFilter
            // 
            this.cbxSupplierFilter.FormattingEnabled = true;
            this.cbxSupplierFilter.Location = new System.Drawing.Point(676, 55);
            this.cbxSupplierFilter.Name = "cbxSupplierFilter";
            this.cbxSupplierFilter.Size = new System.Drawing.Size(149, 28);
            this.cbxSupplierFilter.TabIndex = 59;
            this.cbxSupplierFilter.SelectedIndexChanged += new System.EventHandler(this.cbxSupplierFilter_SelectedIndexChanged);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(171)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(1307, 763);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbxSupplierFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grbItem);
            this.Controls.Add(this.btnDeactivate);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvProducts);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductForm";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.grbItem.ResumeLayout(false);
            this.grbItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grbItem;
        private System.Windows.Forms.NumericUpDown nudCaseSize;
        private System.Windows.Forms.NumericUpDown nudItemID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.TextBox txtItemNotes;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.NumericUpDown nudCost;
        private System.Windows.Forms.NumericUpDown nudRetail;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.ComboBox cbxSupplier;
        private System.Windows.Forms.ComboBox cbxItemCategory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxSupplierFilter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}
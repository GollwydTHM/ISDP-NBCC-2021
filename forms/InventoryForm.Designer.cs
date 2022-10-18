
namespace ISDP_AlexanderK
{
    partial class InventoryForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtInStore = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtInventoryID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbDetails = new System.Windows.Forms.GroupBox();
            this.txtInventoryNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudLevel = new System.Windows.Forms.NumericUpDown();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.cbxLocation = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.grbItem = new System.Windows.Forms.GroupBox();
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
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.grbItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemID)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(203, 432);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 63);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(38, 432);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 63);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtInStore
            // 
            this.txtInStore.Enabled = false;
            this.txtInStore.Location = new System.Drawing.Point(175, 61);
            this.txtInStore.Name = "txtInStore";
            this.txtInStore.Size = new System.Drawing.Size(173, 27);
            this.txtInStore.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "In Store Location:";
            // 
            // txtInventoryID
            // 
            this.txtInventoryID.Enabled = false;
            this.txtInventoryID.Location = new System.Drawing.Point(25, 61);
            this.txtInventoryID.MaxLength = 4;
            this.txtInventoryID.Name = "txtInventoryID";
            this.txtInventoryID.Size = new System.Drawing.Size(131, 27);
            this.txtInventoryID.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Quantity:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Level:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventory ID:";
            // 
            // grbDetails
            // 
            this.grbDetails.Controls.Add(this.txtInventoryNote);
            this.grbDetails.Controls.Add(this.label3);
            this.grbDetails.Controls.Add(this.nudLevel);
            this.grbDetails.Controls.Add(this.nudAmount);
            this.grbDetails.Controls.Add(this.nudQuantity);
            this.grbDetails.Controls.Add(this.btnCancel);
            this.grbDetails.Controls.Add(this.btnSave);
            this.grbDetails.Controls.Add(this.txtInStore);
            this.grbDetails.Controls.Add(this.label11);
            this.grbDetails.Controls.Add(this.txtInventoryID);
            this.grbDetails.Controls.Add(this.label9);
            this.grbDetails.Controls.Add(this.label7);
            this.grbDetails.Controls.Add(this.label2);
            this.grbDetails.Controls.Add(this.label1);
            this.grbDetails.Enabled = false;
            this.grbDetails.Location = new System.Drawing.Point(873, 31);
            this.grbDetails.Margin = new System.Windows.Forms.Padding(2);
            this.grbDetails.Name = "grbDetails";
            this.grbDetails.Padding = new System.Windows.Forms.Padding(2);
            this.grbDetails.Size = new System.Drawing.Size(374, 546);
            this.grbDetails.TabIndex = 13;
            this.grbDetails.TabStop = false;
            this.grbDetails.Text = "Inventory";
            // 
            // txtInventoryNote
            // 
            this.txtInventoryNote.Enabled = false;
            this.txtInventoryNote.Location = new System.Drawing.Point(25, 201);
            this.txtInventoryNote.Multiline = true;
            this.txtInventoryNote.Name = "txtInventoryNote";
            this.txtInventoryNote.Size = new System.Drawing.Size(333, 185);
            this.txtInventoryNote.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Note:";
            // 
            // nudLevel
            // 
            this.nudLevel.Location = new System.Drawing.Point(268, 130);
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.Size = new System.Drawing.Size(80, 27);
            this.nudLevel.TabIndex = 24;
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(145, 131);
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(101, 27);
            this.nudAmount.TabIndex = 23;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(25, 131);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(101, 27);
            this.nudQuantity.TabIndex = 22;
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeactivate.Enabled = false;
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeactivate.Location = new System.Drawing.Point(1141, 612);
            this.btnDeactivate.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(122, 64);
            this.btnDeactivate.TabIndex = 12;
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
            this.btnEdit.Location = new System.Drawing.Point(1007, 612);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(122, 64);
            this.btnEdit.TabIndex = 11;
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
            this.btnAdd.Location = new System.Drawing.Point(873, 612);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 64);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(24, 87);
            this.dgvInventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(817, 591);
            this.dgvInventory.TabIndex = 9;
            this.dgvInventory.SelectionChanged += new System.EventHandler(this.dgvInventory_SelectionChanged);
            this.dgvInventory.Sorted += new System.EventHandler(this.dgvInventory_Sorted);
            // 
            // cbxLocation
            // 
            this.cbxLocation.Enabled = false;
            this.cbxLocation.FormattingEnabled = true;
            this.cbxLocation.Location = new System.Drawing.Point(1434, 633);
            this.cbxLocation.Name = "cbxLocation";
            this.cbxLocation.Size = new System.Drawing.Size(121, 28);
            this.cbxLocation.TabIndex = 14;
            this.cbxLocation.SelectedIndexChanged += new System.EventHandler(this.cbxLocation_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1335, 636);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 25);
            this.label12.TabIndex = 15;
            this.label12.Text = "Location:";
            // 
            // grbItem
            // 
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
            this.grbItem.Location = new System.Drawing.Point(1266, 31);
            this.grbItem.Margin = new System.Windows.Forms.Padding(2);
            this.grbItem.Name = "grbItem";
            this.grbItem.Padding = new System.Windows.Forms.Padding(2);
            this.grbItem.Size = new System.Drawing.Size(374, 546);
            this.grbItem.TabIndex = 16;
            this.grbItem.TabStop = false;
            this.grbItem.Text = "Item";
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
            this.txtItemCategory.Location = new System.Drawing.Point(175, 56);
            this.txtItemCategory.Name = "txtItemCategory";
            this.txtItemCategory.Size = new System.Drawing.Size(173, 27);
            this.txtItemCategory.TabIndex = 21;
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
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(26, 297);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(333, 110);
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
            // txtItemNotes
            // 
            this.txtItemNotes.Enabled = false;
            this.txtItemNotes.Location = new System.Drawing.Point(26, 447);
            this.txtItemNotes.Multiline = true;
            this.txtItemNotes.Name = "txtItemNotes";
            this.txtItemNotes.Size = new System.Drawing.Size(333, 79);
            this.txtItemNotes.TabIndex = 12;
            // 
            // txtItemName
            // 
            this.txtItemName.Enabled = false;
            this.txtItemName.Location = new System.Drawing.Point(25, 114);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(23, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(263, 69);
            this.label10.TabIndex = 47;
            this.label10.Text = "Bullseye";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(400, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 44);
            this.label4.TabIndex = 49;
            this.label4.Text = "Inventory";
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(171)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(1663, 711);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grbItem);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbxLocation);
            this.Controls.Add(this.grbDetails);
            this.Controls.Add(this.btnDeactivate);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvInventory);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InventoryForm";
            this.Text = "InventoryForm";
            this.Load += new System.EventHandler(this.inventory_Load);
            this.grbDetails.ResumeLayout(false);
            this.grbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.grbItem.ResumeLayout(false);
            this.grbItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtInStore;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtInventoryID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbDetails;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.ComboBox cbxLocation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grbItem;
        private System.Windows.Forms.TextBox txtItemCategory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.TextBox txtRetail;
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
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.TextBox txtInventoryNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudLevel;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.TextBox txtCase;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.NumericUpDown nudItemID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
    }
}

namespace ISDP_AlexanderK.forms
{
    partial class SupplierForm
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
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grbOrderButtons = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.cbxSupplierFilter = new System.Windows.Forms.ComboBox();
            this.grbItem = new System.Windows.Forms.GroupBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.grbItemsButtons = new System.Windows.Forms.GroupBox();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnItemEdit = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.lnkLogout = new System.Windows.Forms.LinkLabel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.grbOrderButtons.SuspendLayout();
            this.grbItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemID)).BeginInit();
            this.grbOrder.SuspendLayout();
            this.grbItemsButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Yellow;
            this.label12.Location = new System.Drawing.Point(280, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(302, 44);
            this.label12.TabIndex = 55;
            this.label12.Text = "Supplier Orders";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(11, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(263, 69);
            this.label10.TabIndex = 54;
            this.label10.Text = "Bullseye";
            // 
            // grbOrderButtons
            // 
            this.grbOrderButtons.Controls.Add(this.btnCreate);
            this.grbOrderButtons.Controls.Add(this.btnEdit);
            this.grbOrderButtons.Controls.Add(this.btnNext);
            this.grbOrderButtons.Enabled = false;
            this.grbOrderButtons.Location = new System.Drawing.Point(865, 568);
            this.grbOrderButtons.Name = "grbOrderButtons";
            this.grbOrderButtons.Size = new System.Drawing.Size(422, 142);
            this.grbOrderButtons.TabIndex = 53;
            this.grbOrderButtons.TabStop = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCreate.Enabled = false;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.Black;
            this.btnCreate.Location = new System.Drawing.Point(17, 48);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(122, 64);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "&Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(148, 48);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(122, 64);
            this.btnEdit.TabIndex = 19;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNext.Enabled = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Location = new System.Drawing.Point(282, 48);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(122, 64);
            this.btnNext.TabIndex = 20;
            this.btnNext.Text = "Next Step";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // cbxSupplierFilter
            // 
            this.cbxSupplierFilter.Enabled = false;
            this.cbxSupplierFilter.FormattingEnabled = true;
            this.cbxSupplierFilter.Items.AddRange(new object[] {
            "All"});
            this.cbxSupplierFilter.Location = new System.Drawing.Point(710, 47);
            this.cbxSupplierFilter.Name = "cbxSupplierFilter";
            this.cbxSupplierFilter.Size = new System.Drawing.Size(122, 28);
            this.cbxSupplierFilter.TabIndex = 22;
            this.cbxSupplierFilter.Text = "All";
            this.cbxSupplierFilter.SelectedIndexChanged += new System.EventHandler(this.cbxSupplierFilter_SelectedIndexChanged);
            // 
            // grbItem
            // 
            this.grbItem.Controls.Add(this.nudQuantity);
            this.grbItem.Controls.Add(this.label9);
            this.grbItem.Controls.Add(this.btnCancel);
            this.grbItem.Controls.Add(this.btnSave);
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
            this.grbItem.Enabled = false;
            this.grbItem.Location = new System.Drawing.Point(889, 31);
            this.grbItem.Margin = new System.Windows.Forms.Padding(2);
            this.grbItem.Name = "grbItem";
            this.grbItem.Padding = new System.Windows.Forms.Padding(2);
            this.grbItem.Size = new System.Drawing.Size(374, 511);
            this.grbItem.TabIndex = 52;
            this.grbItem.TabStop = false;
            this.grbItem.Text = "Item";
            this.grbItem.Visible = false;
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
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(196, 429);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 64);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(28, 429);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 64);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.grbOrder.Location = new System.Drawing.Point(865, 47);
            this.grbOrder.Margin = new System.Windows.Forms.Padding(2);
            this.grbOrder.Name = "grbOrder";
            this.grbOrder.Padding = new System.Windows.Forms.Padding(2);
            this.grbOrder.Size = new System.Drawing.Size(422, 516);
            this.grbOrder.TabIndex = 51;
            this.grbOrder.TabStop = false;
            this.grbOrder.Text = "Order";
            // 
            // txtOrderType
            // 
            this.txtOrderType.Enabled = false;
            this.txtOrderType.Location = new System.Drawing.Point(141, 61);
            this.txtOrderType.MaxLength = 4;
            this.txtOrderType.Name = "txtOrderType";
            this.txtOrderType.Size = new System.Drawing.Size(126, 27);
            this.txtOrderType.TabIndex = 40;
            // 
            // txtVehicle
            // 
            this.txtVehicle.Enabled = false;
            this.txtVehicle.Location = new System.Drawing.Point(281, 194);
            this.txtVehicle.MaxLength = 4;
            this.txtVehicle.Name = "txtVehicle";
            this.txtVehicle.Size = new System.Drawing.Size(112, 27);
            this.txtVehicle.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(277, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Vehicle:";
            // 
            // txtDestination
            // 
            this.txtDestination.Enabled = false;
            this.txtDestination.Location = new System.Drawing.Point(153, 194);
            this.txtDestination.MaxLength = 4;
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(117, 27);
            this.txtDestination.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Destination:";
            // 
            // txtOrigin
            // 
            this.txtOrigin.Enabled = false;
            this.txtOrigin.Location = new System.Drawing.Point(25, 194);
            this.txtOrigin.MaxLength = 4;
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(117, 27);
            this.txtOrigin.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 34;
            this.label7.Text = "Origin:";
            // 
            // txtArrivalDate
            // 
            this.txtArrivalDate.Enabled = false;
            this.txtArrivalDate.Location = new System.Drawing.Point(214, 129);
            this.txtArrivalDate.MaxLength = 4;
            this.txtArrivalDate.Name = "txtArrivalDate";
            this.txtArrivalDate.Size = new System.Drawing.Size(179, 27);
            this.txtArrivalDate.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Estimated Arrival:";
            // 
            // txtCreationDate
            // 
            this.txtCreationDate.Enabled = false;
            this.txtCreationDate.Location = new System.Drawing.Point(25, 129);
            this.txtCreationDate.MaxLength = 4;
            this.txtCreationDate.Name = "txtCreationDate";
            this.txtCreationDate.Size = new System.Drawing.Size(179, 27);
            this.txtCreationDate.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Creation Date:";
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(282, 61);
            this.txtStatus.MaxLength = 4;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(111, 27);
            this.txtStatus.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Status:";
            // 
            // txtOrderNote
            // 
            this.txtOrderNote.Enabled = false;
            this.txtOrderNote.Location = new System.Drawing.Point(25, 265);
            this.txtOrderNote.Multiline = true;
            this.txtOrderNote.Name = "txtOrderNote";
            this.txtOrderNote.Size = new System.Drawing.Size(373, 223);
            this.txtOrderNote.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Note:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(139, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Order Type:";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Enabled = false;
            this.txtOrderID.Location = new System.Drawing.Point(25, 61);
            this.txtOrderID.MaxLength = 4;
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(101, 27);
            this.txtOrderID.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order ID:";
            // 
            // grbItemsButtons
            // 
            this.grbItemsButtons.Controls.Add(this.btnOrders);
            this.grbItemsButtons.Controls.Add(this.btnAdd);
            this.grbItemsButtons.Controls.Add(this.btnItemEdit);
            this.grbItemsButtons.Location = new System.Drawing.Point(889, 548);
            this.grbItemsButtons.Name = "grbItemsButtons";
            this.grbItemsButtons.Size = new System.Drawing.Size(374, 172);
            this.grbItemsButtons.TabIndex = 29;
            this.grbItemsButtons.TabStop = false;
            this.grbItemsButtons.Visible = false;
            // 
            // btnOrders
            // 
            this.btnOrders.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrders.Location = new System.Drawing.Point(112, 106);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(152, 52);
            this.btnOrders.TabIndex = 28;
            this.btnOrders.Text = "&Orders";
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(28, 31);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(152, 52);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnItemEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemEdit.Location = new System.Drawing.Point(196, 31);
            this.btnItemEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.Size = new System.Drawing.Size(152, 52);
            this.btnItemEdit.TabIndex = 26;
            this.btnItemEdit.Text = "&Edit";
            this.btnItemEdit.UseVisualStyleBackColor = false;
            this.btnItemEdit.Click += new System.EventHandler(this.btnItemEdit_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(23, 93);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(818, 614);
            this.dgvOrders.TabIndex = 50;
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // lnkLogout
            // 
            this.lnkLogout.AutoSize = true;
            this.lnkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLogout.ForeColor = System.Drawing.Color.Yellow;
            this.lnkLogout.LinkColor = System.Drawing.Color.Yellow;
            this.lnkLogout.Location = new System.Drawing.Point(1096, -39);
            this.lnkLogout.Name = "lnkLogout";
            this.lnkLogout.Size = new System.Drawing.Size(87, 25);
            this.lnkLogout.TabIndex = 56;
            this.lnkLogout.TabStop = true;
            this.lnkLogout.Text = "Go Back";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(23, 93);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(818, 614);
            this.dgvItems.TabIndex = 57;
            this.dgvItems.Visible = false;
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(605, 48);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(90, 25);
            this.label20.TabIndex = 61;
            this.label20.Text = "Supplier:";
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(171)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(1318, 740);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.grbOrderButtons);
            this.Controls.Add(this.cbxSupplierFilter);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grbOrder);
            this.Controls.Add(this.lnkLogout);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.grbItemsButtons);
            this.Controls.Add(this.grbItem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SupplierForm";
            this.Load += new System.EventHandler(this.SupplierForm_Load);
            this.grbOrderButtons.ResumeLayout(false);
            this.grbItem.ResumeLayout(false);
            this.grbItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemID)).EndInit();
            this.grbOrder.ResumeLayout(false);
            this.grbOrder.PerformLayout();
            this.grbItemsButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grbOrderButtons;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox cbxSupplierFilter;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox grbItem;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
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
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.LinkLabel lnkLogout;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.GroupBox grbItemsButtons;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnItemEdit;
        private System.Windows.Forms.Label label20;
    }
}
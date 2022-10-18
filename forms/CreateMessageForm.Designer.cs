
namespace ISDP_AlexanderK.forms
{
    partial class CreateMessageForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessageBody = new System.Windows.Forms.TextBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.btnAttachOrder = new System.Windows.Forms.Button();
            this.btnDetachOrder = new System.Windows.Forms.Button();
            this.lnkOrderLink = new System.Windows.Forms.LinkLabel();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(200, 655);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 80);
            this.btnCancel.TabIndex = 61;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.White;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(24, 655);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(132, 80);
            this.btnSend.TabIndex = 60;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessageBody
            // 
            this.txtMessageBody.Location = new System.Drawing.Point(24, 22);
            this.txtMessageBody.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessageBody.Multiline = true;
            this.txtMessageBody.Name = "txtMessageBody";
            this.txtMessageBody.Size = new System.Drawing.Size(660, 617);
            this.txtMessageBody.TabIndex = 58;
            // 
            // lstUsers
            // 
            this.lstUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 20;
            this.lstUsers.Location = new System.Drawing.Point(706, 75);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(180, 564);
            this.lstUsers.TabIndex = 62;
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.White;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Location = new System.Drawing.Point(706, 22);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(80, 47);
            this.btnAddUser.TabIndex = 63;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.BackColor = System.Drawing.Color.White;
            this.btnRemoveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveUser.Location = new System.Drawing.Point(796, 22);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(90, 47);
            this.btnRemoveUser.TabIndex = 64;
            this.btnRemoveUser.Text = "Remove";
            this.btnRemoveUser.UseVisualStyleBackColor = false;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // btnAttachOrder
            // 
            this.btnAttachOrder.BackColor = System.Drawing.Color.White;
            this.btnAttachOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttachOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachOrder.Location = new System.Drawing.Point(376, 655);
            this.btnAttachOrder.Name = "btnAttachOrder";
            this.btnAttachOrder.Size = new System.Drawing.Size(132, 80);
            this.btnAttachOrder.TabIndex = 65;
            this.btnAttachOrder.Text = "&Attach Order";
            this.btnAttachOrder.UseVisualStyleBackColor = false;
            this.btnAttachOrder.Click += new System.EventHandler(this.btnAttachOrder_Click);
            // 
            // btnDetachOrder
            // 
            this.btnDetachOrder.BackColor = System.Drawing.Color.White;
            this.btnDetachOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetachOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetachOrder.Location = new System.Drawing.Point(552, 655);
            this.btnDetachOrder.Name = "btnDetachOrder";
            this.btnDetachOrder.Size = new System.Drawing.Size(132, 80);
            this.btnDetachOrder.TabIndex = 66;
            this.btnDetachOrder.Text = "&Detach Order";
            this.btnDetachOrder.UseVisualStyleBackColor = false;
            this.btnDetachOrder.Click += new System.EventHandler(this.btnDetachOrder_Click);
            // 
            // lnkOrderLink
            // 
            this.lnkOrderLink.AutoSize = true;
            this.lnkOrderLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOrderLink.LinkColor = System.Drawing.Color.Yellow;
            this.lnkOrderLink.Location = new System.Drawing.Point(784, 687);
            this.lnkOrderLink.Name = "lnkOrderLink";
            this.lnkOrderLink.Size = new System.Drawing.Size(94, 20);
            this.lnkOrderLink.TabIndex = 68;
            this.lnkOrderLink.TabStop = true;
            this.lnkOrderLink.Text = "linkLabel1";
            this.lnkOrderLink.Visible = false;
            this.lnkOrderLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOrderLink_LinkClicked);
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.Location = new System.Drawing.Point(704, 687);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(82, 20);
            this.lblOrderID.TabIndex = 67;
            this.lblOrderID.Text = "OrderID:";
            this.lblOrderID.Visible = false;
            // 
            // CreateMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(171)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(918, 760);
            this.Controls.Add(this.lnkOrderLink);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.btnDetachOrder);
            this.Controls.Add(this.btnAttachOrder);
            this.Controls.Add(this.btnRemoveUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessageBody);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateMessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Message";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessageBody;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Button btnAttachOrder;
        private System.Windows.Forms.Button btnDetachOrder;
        private System.Windows.Forms.LinkLabel lnkOrderLink;
        private System.Windows.Forms.Label lblOrderID;
    }
}
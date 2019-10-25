namespace QTechManagementSoftware
{
    partial class Clients
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clients));
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dgv_Clients = new ADGV.AdvancedDataGridView();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.txt_ClientCode = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_ClientName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btn_DoneAdd = new System.Windows.Forms.Button();
            this.btn_DoneEdit = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_PrevClient = new System.Windows.Forms.Button();
            this.btn_NextClient = new System.Windows.Forms.Button();
            this.btn_ClientAdd = new System.Windows.Forms.Button();
            this.btn_ClientEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Clients)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(130, 48);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(113, 24);
            this.bunifuCustomLabel2.TabIndex = 24;
            this.bunifuCustomLabel2.Text = "Client Code:";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(125, 109);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(118, 24);
            this.bunifuCustomLabel1.TabIndex = 23;
            this.bunifuCustomLabel1.Text = "Client Name:";
            // 
            // dgv_Clients
            // 
            this.dgv_Clients.AllowUserToAddRows = false;
            this.dgv_Clients.AllowUserToDeleteRows = false;
            this.dgv_Clients.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgv_Clients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Clients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Clients.AutoGenerateContextFilters = true;
            this.dgv_Clients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Clients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Clients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgv_Clients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(77)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Clients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Clients.ColumnHeadersHeight = 25;
            this.dgv_Clients.DateWithTime = false;
            this.dgv_Clients.EnableHeadersVisualStyles = false;
            this.dgv_Clients.Location = new System.Drawing.Point(-2, 240);
            this.dgv_Clients.Name = "dgv_Clients";
            this.dgv_Clients.ReadOnly = true;
            this.dgv_Clients.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_Clients.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.dgv_Clients.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Clients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Clients.Size = new System.Drawing.Size(1043, 346);
            this.dgv_Clients.TabIndex = 19;
            this.dgv_Clients.TimeFilter = false;
            this.dgv_Clients.SortStringChanged += new System.EventHandler(this.DGV_Clients_SortStringChanged);
            this.dgv_Clients.FilterStringChanged += new System.EventHandler(this.DGV_Clients_FilterStringChanged);
            this.dgv_Clients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            this.dgv_Clients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Clients_CellDoubleClick);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(16, 199);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1005, 35);
            this.bunifuSeparator1.TabIndex = 18;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // txt_ClientCode
            // 
            this.txt_ClientCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ClientCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txt_ClientCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.txt_ClientCode.HintForeColor = System.Drawing.Color.Empty;
            this.txt_ClientCode.HintText = "";
            this.txt_ClientCode.isPassword = false;
            this.txt_ClientCode.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.txt_ClientCode.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_ClientCode.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.txt_ClientCode.LineThickness = 1;
            this.txt_ClientCode.Location = new System.Drawing.Point(252, 43);
            this.txt_ClientCode.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ClientCode.Name = "txt_ClientCode";
            this.txt_ClientCode.Size = new System.Drawing.Size(379, 33);
            this.txt_ClientCode.TabIndex = 17;
            this.txt_ClientCode.Text = "bunifuMaterialTextbox2";
            this.txt_ClientCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_ClientCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_ClientCode_KeyDown);
            // 
            // txt_ClientName
            // 
            this.txt_ClientName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txt_ClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.txt_ClientName.HintForeColor = System.Drawing.Color.Empty;
            this.txt_ClientName.HintText = "";
            this.txt_ClientName.isPassword = false;
            this.txt_ClientName.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.txt_ClientName.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_ClientName.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.txt_ClientName.LineThickness = 1;
            this.txt_ClientName.Location = new System.Drawing.Point(250, 104);
            this.txt_ClientName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ClientName.Name = "txt_ClientName";
            this.txt_ClientName.Size = new System.Drawing.Size(379, 33);
            this.txt_ClientName.TabIndex = 16;
            this.txt_ClientName.Text = "bunifuMaterialTextbox1";
            this.txt_ClientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_ClientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_ClientName_KeyDown);
            // 
            // btn_DoneAdd
            // 
            this.btn_DoneAdd.FlatAppearance.BorderSize = 0;
            this.btn_DoneAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_DoneAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_DoneAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoneAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoneAdd.Location = new System.Drawing.Point(129, 162);
            this.btn_DoneAdd.Name = "btn_DoneAdd";
            this.btn_DoneAdd.Size = new System.Drawing.Size(114, 40);
            this.btn_DoneAdd.TabIndex = 15;
            this.btn_DoneAdd.Text = "Done";
            this.btn_DoneAdd.UseVisualStyleBackColor = true;
            this.btn_DoneAdd.Visible = false;
            this.btn_DoneAdd.Click += new System.EventHandler(this.Btn_DoneAdd_Click);
            this.btn_DoneAdd.MouseEnter += new System.EventHandler(this.Btn_DoneAdd_MouseEnter);
            this.btn_DoneAdd.MouseLeave += new System.EventHandler(this.Btn_DoneAdd_MouseLeave);
            // 
            // btn_DoneEdit
            // 
            this.btn_DoneEdit.FlatAppearance.BorderSize = 0;
            this.btn_DoneEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_DoneEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_DoneEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoneEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoneEdit.Location = new System.Drawing.Point(129, 162);
            this.btn_DoneEdit.Name = "btn_DoneEdit";
            this.btn_DoneEdit.Size = new System.Drawing.Size(114, 40);
            this.btn_DoneEdit.TabIndex = 14;
            this.btn_DoneEdit.Text = "Done";
            this.btn_DoneEdit.UseVisualStyleBackColor = true;
            this.btn_DoneEdit.Visible = false;
            this.btn_DoneEdit.Click += new System.EventHandler(this.Btn_DoneEdit_Click);
            this.btn_DoneEdit.MouseEnter += new System.EventHandler(this.Btn_DoneEdit_MouseEnter);
            this.btn_DoneEdit.MouseLeave += new System.EventHandler(this.Btn_DoneEdit_MouseLeave);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(249, 162);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(114, 40);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            this.btn_Cancel.MouseEnter += new System.EventHandler(this.Btn_Cancel_MouseEnter);
            this.btn_Cancel.MouseLeave += new System.EventHandler(this.Btn_Cancel_MouseLeave);
            // 
            // btn_PrevClient
            // 
            this.btn_PrevClient.Enabled = false;
            this.btn_PrevClient.FlatAppearance.BorderSize = 0;
            this.btn_PrevClient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_PrevClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_PrevClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PrevClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PrevClient.ForeColor = System.Drawing.Color.White;
            this.btn_PrevClient.Image = global::QTechManagementSoftware.Properties.Resources.back_black;
            this.btn_PrevClient.Location = new System.Drawing.Point(16, 13);
            this.btn_PrevClient.Name = "btn_PrevClient";
            this.btn_PrevClient.Size = new System.Drawing.Size(49, 149);
            this.btn_PrevClient.TabIndex = 25;
            this.btn_PrevClient.UseVisualStyleBackColor = true;
            this.btn_PrevClient.Click += new System.EventHandler(this.Btn_PrevClient_Click);
            this.btn_PrevClient.MouseEnter += new System.EventHandler(this.Btn_PrevClient_MouseEnter);
            this.btn_PrevClient.MouseLeave += new System.EventHandler(this.Btn_PrevClient_MouseLeave);
            // 
            // btn_NextClient
            // 
            this.btn_NextClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NextClient.FlatAppearance.BorderSize = 0;
            this.btn_NextClient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_NextClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_NextClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NextClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NextClient.ForeColor = System.Drawing.Color.White;
            this.btn_NextClient.Image = global::QTechManagementSoftware.Properties.Resources.forawrd_black;
            this.btn_NextClient.Location = new System.Drawing.Point(972, 13);
            this.btn_NextClient.Name = "btn_NextClient";
            this.btn_NextClient.Size = new System.Drawing.Size(49, 149);
            this.btn_NextClient.TabIndex = 22;
            this.btn_NextClient.UseVisualStyleBackColor = true;
            this.btn_NextClient.Click += new System.EventHandler(this.Btn_NextClient_Click);
            this.btn_NextClient.MouseEnter += new System.EventHandler(this.Btn_NextClient_MouseEnter);
            this.btn_NextClient.MouseLeave += new System.EventHandler(this.Btn_NextClient_MouseLeave);
            // 
            // btn_ClientAdd
            // 
            this.btn_ClientAdd.FlatAppearance.BorderSize = 0;
            this.btn_ClientAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_ClientAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_ClientAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClientAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClientAdd.Image = global::QTechManagementSoftware.Properties.Resources.add_grey;
            this.btn_ClientAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ClientAdd.Location = new System.Drawing.Point(129, 162);
            this.btn_ClientAdd.Name = "btn_ClientAdd";
            this.btn_ClientAdd.Size = new System.Drawing.Size(114, 40);
            this.btn_ClientAdd.TabIndex = 21;
            this.btn_ClientAdd.Text = "Add";
            this.btn_ClientAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ClientAdd.UseVisualStyleBackColor = true;
            this.btn_ClientAdd.Click += new System.EventHandler(this.Btn_ClientAdd_Click);
            this.btn_ClientAdd.MouseEnter += new System.EventHandler(this.Btn_ClientAdd_MouseEnter);
            this.btn_ClientAdd.MouseLeave += new System.EventHandler(this.Btn_ClientAdd_MouseLeave);
            // 
            // btn_ClientEdit
            // 
            this.btn_ClientEdit.FlatAppearance.BorderSize = 0;
            this.btn_ClientEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_ClientEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_ClientEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClientEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClientEdit.Image = global::QTechManagementSoftware.Properties.Resources.edit_grey;
            this.btn_ClientEdit.Location = new System.Drawing.Point(252, 162);
            this.btn_ClientEdit.Name = "btn_ClientEdit";
            this.btn_ClientEdit.Size = new System.Drawing.Size(114, 40);
            this.btn_ClientEdit.TabIndex = 20;
            this.btn_ClientEdit.Text = "Edit";
            this.btn_ClientEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ClientEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ClientEdit.UseVisualStyleBackColor = true;
            this.btn_ClientEdit.Click += new System.EventHandler(this.Btn_ClientEdit_Click);
            this.btn_ClientEdit.MouseEnter += new System.EventHandler(this.Btn_ClientEdit_MouseEnter);
            this.btn_ClientEdit.MouseLeave += new System.EventHandler(this.Btn_ClientEdit_MouseLeave);
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1039, 585);
            this.ControlBox = false;
            this.Controls.Add(this.btn_PrevClient);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.btn_NextClient);
            this.Controls.Add(this.btn_ClientAdd);
            this.Controls.Add(this.btn_ClientEdit);
            this.Controls.Add(this.dgv_Clients);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.txt_ClientCode);
            this.Controls.Add(this.txt_ClientName);
            this.Controls.Add(this.btn_DoneAdd);
            this.Controls.Add(this.btn_DoneEdit);
            this.Controls.Add(this.btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Clients";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clients";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Clients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Clients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PrevClient;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Button btn_NextClient;
        private System.Windows.Forms.Button btn_ClientAdd;
        private System.Windows.Forms.Button btn_ClientEdit;
        private ADGV.AdvancedDataGridView dgv_Clients;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_ClientCode;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_ClientName;
        private System.Windows.Forms.Button btn_DoneAdd;
        private System.Windows.Forms.Button btn_DoneEdit;
        private System.Windows.Forms.Button btn_Cancel;
    }
}
namespace QTechManagementSoftware
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.btn_Local = new System.Windows.Forms.Button();
            this.pnl_Con = new System.Windows.Forms.Panel();
            this.btn_Contractors = new System.Windows.Forms.Button();
            this.btn_C_NoInv = new System.Windows.Forms.Button();
            this.btn_C_NoRem = new System.Windows.Forms.Button();
            this.btn_Int = new System.Windows.Forms.Button();
            this.btn_PettyCash = new System.Windows.Forms.Button();
            this.btn_Projects = new System.Windows.Forms.Button();
            this.btn_Home = new System.Windows.Forms.Button();
            this.pnl_Home = new System.Windows.Forms.Panel();
            this.windowBar = new System.Windows.Forms.Panel();
            this.btn_Home_Close = new System.Windows.Forms.Button();
            this.btn_Home_Nor = new System.Windows.Forms.Button();
            this.btn_Home_Max = new System.Windows.Forms.Button();
            this.btn_Home_Min = new System.Windows.Forms.Button();
            this.tmr_Con = new System.Windows.Forms.Timer(this.components);
            this.pnl_LocalTabs = new System.Windows.Forms.Panel();
            this.pnl_Local = new System.Windows.Forms.Panel();
            this.btn_LInvSend = new System.Windows.Forms.Button();
            this.btn_LQuotes = new System.Windows.Forms.Button();
            this.btn_LOrders = new System.Windows.Forms.Button();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.pnl_IntTabs = new System.Windows.Forms.Panel();
            this.pnl_Int = new System.Windows.Forms.Panel();
            this.btn_IOrders = new System.Windows.Forms.Button();
            this.btn_IInvSend = new System.Windows.Forms.Button();
            this.btn_IQuotes = new System.Windows.Forms.Button();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.QTLogo = new System.Windows.Forms.PictureBox();
            this.pnl_Menu.SuspendLayout();
            this.pnl_Con.SuspendLayout();
            this.windowBar.SuspendLayout();
            this.pnl_LocalTabs.SuspendLayout();
            this.pnl_IntTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QTLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_Menu.Controls.Add(this.btn_Local);
            this.pnl_Menu.Controls.Add(this.pnl_Con);
            this.pnl_Menu.Controls.Add(this.btn_Int);
            this.pnl_Menu.Controls.Add(this.btn_PettyCash);
            this.pnl_Menu.Controls.Add(this.btn_Projects);
            this.pnl_Menu.Controls.Add(this.btn_Home);
            this.pnl_Menu.Location = new System.Drawing.Point(0, -1);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Size = new System.Drawing.Size(230, 556);
            this.pnl_Menu.TabIndex = 0;
            // 
            // btn_Local
            // 
            this.btn_Local.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Local.FlatAppearance.BorderSize = 0;
            this.btn_Local.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Local.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Local.ForeColor = System.Drawing.Color.White;
            this.btn_Local.Image = global::QTechManagementSoftware.Properties.Resources.local_white;
            this.btn_Local.Location = new System.Drawing.Point(0, 48);
            this.btn_Local.Name = "btn_Local";
            this.btn_Local.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btn_Local.Size = new System.Drawing.Size(230, 48);
            this.btn_Local.TabIndex = 4;
            this.btn_Local.Text = "Local";
            this.btn_Local.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Local.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Local.UseVisualStyleBackColor = false;
            this.btn_Local.Click += new System.EventHandler(this.Btn_Local_Click);
            this.btn_Local.MouseEnter += new System.EventHandler(this.Btn_Local_MouseEnter);
            this.btn_Local.MouseLeave += new System.EventHandler(this.Btn_Local_MouseLeave);
            // 
            // pnl_Con
            // 
            this.pnl_Con.Controls.Add(this.btn_Contractors);
            this.pnl_Con.Controls.Add(this.btn_C_NoInv);
            this.pnl_Con.Controls.Add(this.btn_C_NoRem);
            this.pnl_Con.Location = new System.Drawing.Point(0, 144);
            this.pnl_Con.Name = "pnl_Con";
            this.pnl_Con.Size = new System.Drawing.Size(230, 48);
            this.pnl_Con.TabIndex = 16;
            // 
            // btn_Contractors
            // 
            this.btn_Contractors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Contractors.FlatAppearance.BorderSize = 0;
            this.btn_Contractors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Contractors.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Contractors.ForeColor = System.Drawing.Color.White;
            this.btn_Contractors.Image = global::QTechManagementSoftware.Properties.Resources.contr_white;
            this.btn_Contractors.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Contractors.Location = new System.Drawing.Point(0, 0);
            this.btn_Contractors.Name = "btn_Contractors";
            this.btn_Contractors.Padding = new System.Windows.Forms.Padding(0, 0, 22, 0);
            this.btn_Contractors.Size = new System.Drawing.Size(230, 48);
            this.btn_Contractors.TabIndex = 14;
            this.btn_Contractors.Text = "Contractors";
            this.btn_Contractors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Contractors.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Contractors.UseVisualStyleBackColor = false;
            this.btn_Contractors.Click += new System.EventHandler(this.Btn_Contractors_Click);
            this.btn_Contractors.MouseEnter += new System.EventHandler(this.Btn_Contractors_MouseEnter);
            this.btn_Contractors.MouseLeave += new System.EventHandler(this.Btn_Contractors_MouseLeave);
            // 
            // btn_C_NoInv
            // 
            this.btn_C_NoInv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_C_NoInv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_C_NoInv.FlatAppearance.BorderSize = 0;
            this.btn_C_NoInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_C_NoInv.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_C_NoInv.ForeColor = System.Drawing.Color.White;
            this.btn_C_NoInv.Location = new System.Drawing.Point(0, 96);
            this.btn_C_NoInv.Name = "btn_C_NoInv";
            this.btn_C_NoInv.Size = new System.Drawing.Size(230, 48);
            this.btn_C_NoInv.TabIndex = 13;
            this.btn_C_NoInv.Text = "No Invoices";
            this.btn_C_NoInv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_C_NoInv.UseVisualStyleBackColor = false;
            this.btn_C_NoInv.Click += new System.EventHandler(this.btn_C_NoInv_Click);
            this.btn_C_NoInv.MouseEnter += new System.EventHandler(this.Btn_C_NoInv_MouseEnter);
            this.btn_C_NoInv.MouseLeave += new System.EventHandler(this.Btn_C_NoInv_MouseLeave);
            // 
            // btn_C_NoRem
            // 
            this.btn_C_NoRem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_C_NoRem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_C_NoRem.FlatAppearance.BorderSize = 0;
            this.btn_C_NoRem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_C_NoRem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_C_NoRem.ForeColor = System.Drawing.Color.White;
            this.btn_C_NoRem.Location = new System.Drawing.Point(0, 48);
            this.btn_C_NoRem.Name = "btn_C_NoRem";
            this.btn_C_NoRem.Size = new System.Drawing.Size(230, 48);
            this.btn_C_NoRem.TabIndex = 13;
            this.btn_C_NoRem.Text = "No Remittances";
            this.btn_C_NoRem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_C_NoRem.UseVisualStyleBackColor = false;
            this.btn_C_NoRem.Click += new System.EventHandler(this.Btn_C_NoRem_Click);
            this.btn_C_NoRem.MouseEnter += new System.EventHandler(this.Btn_C_NoRem_MouseEnter);
            this.btn_C_NoRem.MouseLeave += new System.EventHandler(this.Btn_C_NoRem_MouseLeave);
            // 
            // btn_Int
            // 
            this.btn_Int.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Int.FlatAppearance.BorderSize = 0;
            this.btn_Int.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Int.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Int.ForeColor = System.Drawing.Color.White;
            this.btn_Int.Image = global::QTechManagementSoftware.Properties.Resources.globe_white;
            this.btn_Int.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Int.Location = new System.Drawing.Point(0, 96);
            this.btn_Int.Name = "btn_Int";
            this.btn_Int.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.btn_Int.Size = new System.Drawing.Size(230, 48);
            this.btn_Int.TabIndex = 9;
            this.btn_Int.Text = "International";
            this.btn_Int.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Int.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Int.UseVisualStyleBackColor = false;
            this.btn_Int.Click += new System.EventHandler(this.Btn_Int_Click);
            this.btn_Int.MouseEnter += new System.EventHandler(this.Btn_Int_MouseEnter);
            this.btn_Int.MouseLeave += new System.EventHandler(this.Btn_Int_MouseLeave);
            // 
            // btn_PettyCash
            // 
            this.btn_PettyCash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PettyCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_PettyCash.FlatAppearance.BorderSize = 0;
            this.btn_PettyCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PettyCash.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PettyCash.ForeColor = System.Drawing.Color.White;
            this.btn_PettyCash.Image = global::QTechManagementSoftware.Properties.Resources.cash_White;
            this.btn_PettyCash.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PettyCash.Location = new System.Drawing.Point(0, 240);
            this.btn_PettyCash.Name = "btn_PettyCash";
            this.btn_PettyCash.Padding = new System.Windows.Forms.Padding(0, 0, 32, 0);
            this.btn_PettyCash.Size = new System.Drawing.Size(230, 48);
            this.btn_PettyCash.TabIndex = 12;
            this.btn_PettyCash.Text = "Petty Cash";
            this.btn_PettyCash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PettyCash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_PettyCash.UseVisualStyleBackColor = false;
            this.btn_PettyCash.Click += new System.EventHandler(this.Btn_PettyCash_Click);
            this.btn_PettyCash.MouseEnter += new System.EventHandler(this.Btn_PettyCash_MouseEnter);
            this.btn_PettyCash.MouseLeave += new System.EventHandler(this.Btn_PettyCash_MouseLeave);
            // 
            // btn_Projects
            // 
            this.btn_Projects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Projects.FlatAppearance.BorderSize = 0;
            this.btn_Projects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Projects.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Projects.ForeColor = System.Drawing.Color.White;
            this.btn_Projects.Image = global::QTechManagementSoftware.Properties.Resources.project_white;
            this.btn_Projects.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Projects.Location = new System.Drawing.Point(0, 192);
            this.btn_Projects.Name = "btn_Projects";
            this.btn_Projects.Padding = new System.Windows.Forms.Padding(0, 0, 48, 0);
            this.btn_Projects.Size = new System.Drawing.Size(230, 48);
            this.btn_Projects.TabIndex = 15;
            this.btn_Projects.Text = "Projects";
            this.btn_Projects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Projects.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Projects.UseVisualStyleBackColor = false;
            this.btn_Projects.Click += new System.EventHandler(this.Btn_Projects_Click);
            this.btn_Projects.MouseEnter += new System.EventHandler(this.Btn_Projects_MouseEnter);
            this.btn_Projects.MouseLeave += new System.EventHandler(this.Btn_Projects_MouseLeave);
            // 
            // btn_Home
            // 
            this.btn_Home.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Home.FlatAppearance.BorderSize = 0;
            this.btn_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Home.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Home.ForeColor = System.Drawing.Color.White;
            this.btn_Home.Image = global::QTechManagementSoftware.Properties.Resources.home_white;
            this.btn_Home.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Home.Location = new System.Drawing.Point(0, 0);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Padding = new System.Windows.Forms.Padding(0, 0, 28, 0);
            this.btn_Home.Size = new System.Drawing.Size(230, 48);
            this.btn_Home.TabIndex = 2;
            this.btn_Home.Text = "Dashboard";
            this.btn_Home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Home.UseVisualStyleBackColor = false;
            this.btn_Home.Click += new System.EventHandler(this.Btn_Home_Click);
            this.btn_Home.MouseEnter += new System.EventHandler(this.Btn_Home_MouseEnter);
            this.btn_Home.MouseLeave += new System.EventHandler(this.Btn_Home_MouseLeave);
            // 
            // pnl_Home
            // 
            this.pnl_Home.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Home.Location = new System.Drawing.Point(236, 47);
            this.pnl_Home.Name = "pnl_Home";
            this.pnl_Home.Size = new System.Drawing.Size(1039, 586);
            this.pnl_Home.TabIndex = 8;
            this.pnl_Home.Visible = false;
            // 
            // windowBar
            // 
            this.windowBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.windowBar.BackColor = System.Drawing.Color.Silver;
            this.windowBar.Controls.Add(this.btn_Home_Close);
            this.windowBar.Controls.Add(this.btn_Home_Nor);
            this.windowBar.Controls.Add(this.btn_Home_Max);
            this.windowBar.Controls.Add(this.btn_Home_Min);
            this.windowBar.Location = new System.Drawing.Point(230, 0);
            this.windowBar.Name = "windowBar";
            this.windowBar.Size = new System.Drawing.Size(1056, 29);
            this.windowBar.TabIndex = 22;
            this.windowBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.windowBar_MouseDown);
            this.windowBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.windowBar_MouseMove);
            this.windowBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.windowBar_MouseUp);
            // 
            // btn_Home_Close
            // 
            this.btn_Home_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Home_Close.FlatAppearance.BorderSize = 0;
            this.btn_Home_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Home_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Home_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Home_Close.Image = global::QTechManagementSoftware.Properties.Resources.close_black;
            this.btn_Home_Close.Location = new System.Drawing.Point(1025, 0);
            this.btn_Home_Close.Name = "btn_Home_Close";
            this.btn_Home_Close.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btn_Home_Close.Size = new System.Drawing.Size(31, 29);
            this.btn_Home_Close.TabIndex = 20;
            this.btn_Home_Close.UseVisualStyleBackColor = false;
            this.btn_Home_Close.Click += new System.EventHandler(this.Btn_Home_Close_Click);
            this.btn_Home_Close.MouseEnter += new System.EventHandler(this.Btn_Home_Close_MouseEnter);
            this.btn_Home_Close.MouseLeave += new System.EventHandler(this.Btn_Home_Close_MouseLeave);
            // 
            // btn_Home_Nor
            // 
            this.btn_Home_Nor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Home_Nor.FlatAppearance.BorderSize = 0;
            this.btn_Home_Nor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_Home_Nor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_Home_Nor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Home_Nor.Image = global::QTechManagementSoftware.Properties.Resources.restore_black2;
            this.btn_Home_Nor.Location = new System.Drawing.Point(995, 0);
            this.btn_Home_Nor.Name = "btn_Home_Nor";
            this.btn_Home_Nor.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btn_Home_Nor.Size = new System.Drawing.Size(31, 29);
            this.btn_Home_Nor.TabIndex = 18;
            this.btn_Home_Nor.UseVisualStyleBackColor = false;
            this.btn_Home_Nor.Visible = false;
            this.btn_Home_Nor.Click += new System.EventHandler(this.Btn_Home_Nor_Click);
            this.btn_Home_Nor.MouseEnter += new System.EventHandler(this.Btn_Home_Nor_MouseEnter);
            this.btn_Home_Nor.MouseLeave += new System.EventHandler(this.Btn_Home_Nor_MouseLeave);
            // 
            // btn_Home_Max
            // 
            this.btn_Home_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Home_Max.FlatAppearance.BorderSize = 0;
            this.btn_Home_Max.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_Home_Max.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_Home_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Home_Max.Image = global::QTechManagementSoftware.Properties.Resources.maximize_black;
            this.btn_Home_Max.Location = new System.Drawing.Point(995, 0);
            this.btn_Home_Max.Name = "btn_Home_Max";
            this.btn_Home_Max.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btn_Home_Max.Size = new System.Drawing.Size(31, 29);
            this.btn_Home_Max.TabIndex = 19;
            this.btn_Home_Max.UseVisualStyleBackColor = false;
            this.btn_Home_Max.Click += new System.EventHandler(this.Btn_Home_Max_Click);
            this.btn_Home_Max.MouseEnter += new System.EventHandler(this.Btn_Home_Max_MouseEnter);
            this.btn_Home_Max.MouseLeave += new System.EventHandler(this.Btn_Home_Max_MouseLeave);
            // 
            // btn_Home_Min
            // 
            this.btn_Home_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Home_Min.FlatAppearance.BorderSize = 0;
            this.btn_Home_Min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_Home_Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_Home_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Home_Min.Image = global::QTechManagementSoftware.Properties.Resources.minimize_grey;
            this.btn_Home_Min.Location = new System.Drawing.Point(964, 0);
            this.btn_Home_Min.Name = "btn_Home_Min";
            this.btn_Home_Min.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btn_Home_Min.Size = new System.Drawing.Size(31, 29);
            this.btn_Home_Min.TabIndex = 17;
            this.btn_Home_Min.UseVisualStyleBackColor = false;
            this.btn_Home_Min.Click += new System.EventHandler(this.Btn_Home_Min_Click);
            this.btn_Home_Min.MouseEnter += new System.EventHandler(this.Btn_Home_Min_MouseEnter);
            this.btn_Home_Min.MouseLeave += new System.EventHandler(this.Btn_Home_Min_MouseLeave);
            // 
            // tmr_Con
            // 
            this.tmr_Con.Interval = 1;
            this.tmr_Con.Tick += new System.EventHandler(this.Tmr_Con_Tick);
            // 
            // pnl_LocalTabs
            // 
            this.pnl_LocalTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_LocalTabs.Controls.Add(this.pnl_Local);
            this.pnl_LocalTabs.Controls.Add(this.btn_LInvSend);
            this.pnl_LocalTabs.Controls.Add(this.btn_LQuotes);
            this.pnl_LocalTabs.Controls.Add(this.btn_LOrders);
            this.pnl_LocalTabs.Controls.Add(this.bunifuSeparator1);
            this.pnl_LocalTabs.Location = new System.Drawing.Point(236, 47);
            this.pnl_LocalTabs.Name = "pnl_LocalTabs";
            this.pnl_LocalTabs.Size = new System.Drawing.Size(1039, 586);
            this.pnl_LocalTabs.TabIndex = 23;
            this.pnl_LocalTabs.Visible = false;
            // 
            // pnl_Local
            // 
            this.pnl_Local.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Local.Location = new System.Drawing.Point(3, 39);
            this.pnl_Local.Name = "pnl_Local";
            this.pnl_Local.Size = new System.Drawing.Size(1033, 544);
            this.pnl_Local.TabIndex = 2;
            // 
            // btn_LInvSend
            // 
            this.btn_LInvSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_LInvSend.FlatAppearance.BorderSize = 0;
            this.btn_LInvSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LInvSend.ForeColor = System.Drawing.Color.White;
            this.btn_LInvSend.Location = new System.Drawing.Point(198, 0);
            this.btn_LInvSend.Name = "btn_LInvSend";
            this.btn_LInvSend.Size = new System.Drawing.Size(100, 33);
            this.btn_LInvSend.TabIndex = 0;
            this.btn_LInvSend.Text = "Invoices Sent";
            this.btn_LInvSend.UseVisualStyleBackColor = false;
            this.btn_LInvSend.Click += new System.EventHandler(this.btn_LInvSend_Click);
            this.btn_LInvSend.Leave += new System.EventHandler(this.btn_LInvSend_Leave);
            this.btn_LInvSend.MouseEnter += new System.EventHandler(this.btn_LInvSend_MouseEnter);
            // 
            // btn_LQuotes
            // 
            this.btn_LQuotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_LQuotes.FlatAppearance.BorderSize = 0;
            this.btn_LQuotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LQuotes.ForeColor = System.Drawing.Color.White;
            this.btn_LQuotes.Location = new System.Drawing.Point(99, 0);
            this.btn_LQuotes.Name = "btn_LQuotes";
            this.btn_LQuotes.Size = new System.Drawing.Size(100, 33);
            this.btn_LQuotes.TabIndex = 0;
            this.btn_LQuotes.Text = "Quotes";
            this.btn_LQuotes.UseVisualStyleBackColor = false;
            this.btn_LQuotes.Click += new System.EventHandler(this.btn_LQuotes_Click);
            this.btn_LQuotes.MouseEnter += new System.EventHandler(this.btn_LQuotes_MouseEnter);
            this.btn_LQuotes.MouseLeave += new System.EventHandler(this.btn_LQuotes_MouseLeave);
            // 
            // btn_LOrders
            // 
            this.btn_LOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_LOrders.FlatAppearance.BorderSize = 0;
            this.btn_LOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LOrders.ForeColor = System.Drawing.Color.White;
            this.btn_LOrders.Location = new System.Drawing.Point(0, 0);
            this.btn_LOrders.Name = "btn_LOrders";
            this.btn_LOrders.Size = new System.Drawing.Size(100, 33);
            this.btn_LOrders.TabIndex = 0;
            this.btn_LOrders.Text = "Orders";
            this.btn_LOrders.UseVisualStyleBackColor = false;
            this.btn_LOrders.Click += new System.EventHandler(this.btn_LOrders_Click);
            this.btn_LOrders.MouseEnter += new System.EventHandler(this.btn_LOrders_MouseEnter);
            this.btn_LOrders.MouseLeave += new System.EventHandler(this.btn_LOrders_MouseLeave);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 2;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 16);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1039, 35);
            this.bunifuSeparator1.TabIndex = 1;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // pnl_IntTabs
            // 
            this.pnl_IntTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_IntTabs.Controls.Add(this.pnl_Int);
            this.pnl_IntTabs.Controls.Add(this.btn_IOrders);
            this.pnl_IntTabs.Controls.Add(this.btn_IInvSend);
            this.pnl_IntTabs.Controls.Add(this.btn_IQuotes);
            this.pnl_IntTabs.Controls.Add(this.bunifuSeparator2);
            this.pnl_IntTabs.Location = new System.Drawing.Point(236, 47);
            this.pnl_IntTabs.Name = "pnl_IntTabs";
            this.pnl_IntTabs.Size = new System.Drawing.Size(1039, 586);
            this.pnl_IntTabs.TabIndex = 0;
            // 
            // pnl_Int
            // 
            this.pnl_Int.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Int.Location = new System.Drawing.Point(6, 39);
            this.pnl_Int.Name = "pnl_Int";
            this.pnl_Int.Size = new System.Drawing.Size(1027, 541);
            this.pnl_Int.TabIndex = 2;
            // 
            // btn_IOrders
            // 
            this.btn_IOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_IOrders.FlatAppearance.BorderSize = 0;
            this.btn_IOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IOrders.ForeColor = System.Drawing.Color.White;
            this.btn_IOrders.Location = new System.Drawing.Point(0, 0);
            this.btn_IOrders.Name = "btn_IOrders";
            this.btn_IOrders.Size = new System.Drawing.Size(100, 33);
            this.btn_IOrders.TabIndex = 0;
            this.btn_IOrders.Text = "Orders";
            this.btn_IOrders.UseVisualStyleBackColor = false;
            this.btn_IOrders.Click += new System.EventHandler(this.btn_IOrders_Click);
            this.btn_IOrders.MouseEnter += new System.EventHandler(this.btn_IOrders_MouseEnter);
            this.btn_IOrders.MouseLeave += new System.EventHandler(this.btn_IOrders_MouseLeave);
            // 
            // btn_IInvSend
            // 
            this.btn_IInvSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_IInvSend.FlatAppearance.BorderSize = 0;
            this.btn_IInvSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IInvSend.ForeColor = System.Drawing.Color.White;
            this.btn_IInvSend.Location = new System.Drawing.Point(198, 0);
            this.btn_IInvSend.Name = "btn_IInvSend";
            this.btn_IInvSend.Size = new System.Drawing.Size(100, 33);
            this.btn_IInvSend.TabIndex = 0;
            this.btn_IInvSend.Text = "Invoices Sent";
            this.btn_IInvSend.UseVisualStyleBackColor = false;
            this.btn_IInvSend.Click += new System.EventHandler(this.btn_IInvSend_Click);
            this.btn_IInvSend.Leave += new System.EventHandler(this.btn_IInvSend_Leave);
            this.btn_IInvSend.MouseEnter += new System.EventHandler(this.btn_IInvSend_MouseEnter);
            // 
            // btn_IQuotes
            // 
            this.btn_IQuotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_IQuotes.FlatAppearance.BorderSize = 0;
            this.btn_IQuotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IQuotes.ForeColor = System.Drawing.Color.White;
            this.btn_IQuotes.Location = new System.Drawing.Point(99, 0);
            this.btn_IQuotes.Name = "btn_IQuotes";
            this.btn_IQuotes.Size = new System.Drawing.Size(100, 33);
            this.btn_IQuotes.TabIndex = 0;
            this.btn_IQuotes.Text = "Quotes";
            this.btn_IQuotes.UseVisualStyleBackColor = false;
            this.btn_IQuotes.Click += new System.EventHandler(this.btn_IQuotes_Click);
            this.btn_IQuotes.MouseEnter += new System.EventHandler(this.btn_IQuotes_MouseEnter);
            this.btn_IQuotes.MouseLeave += new System.EventHandler(this.btn_IQuotes_MouseLeave);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 2;
            this.bunifuSeparator2.Location = new System.Drawing.Point(0, 16);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(1039, 35);
            this.bunifuSeparator2.TabIndex = 1;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // QTLogo
            // 
            this.QTLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.QTLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.QTLogo.Image = global::QTechManagementSoftware.Properties.Resources.QTech_Logo;
            this.QTLogo.Location = new System.Drawing.Point(0, 556);
            this.QTLogo.Name = "QTLogo";
            this.QTLogo.Size = new System.Drawing.Size(230, 89);
            this.QTLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QTLogo.TabIndex = 1;
            this.QTLogo.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1286, 644);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_IntTabs);
            this.Controls.Add(this.pnl_LocalTabs);
            this.Controls.Add(this.windowBar);
            this.Controls.Add(this.pnl_Home);
            this.Controls.Add(this.QTLogo);
            this.Controls.Add(this.pnl_Menu);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(980, 580);
            this.Name = "Home";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.pnl_Menu.ResumeLayout(false);
            this.pnl_Con.ResumeLayout(false);
            this.windowBar.ResumeLayout(false);
            this.pnl_LocalTabs.ResumeLayout(false);
            this.pnl_IntTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QTLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.PictureBox QTLogo;
        private System.Windows.Forms.Button btn_Home;
        private System.Windows.Forms.Button btn_Local;
        private System.Windows.Forms.Button btn_Int;
        private System.Windows.Forms.Button btn_Contractors;
        private System.Windows.Forms.Button btn_Projects;
        private System.Windows.Forms.Button btn_C_NoInv;
        private System.Windows.Forms.Button btn_C_NoRem;
        private System.Windows.Forms.Panel pnl_Home;
        private System.Windows.Forms.Button btn_Home_Min;
        private System.Windows.Forms.Button btn_Home_Nor;
        private System.Windows.Forms.Button btn_Home_Max;
        private System.Windows.Forms.Button btn_Home_Close;
        private System.Windows.Forms.Button btn_PettyCash;
        private System.Windows.Forms.Panel windowBar;
        private System.Windows.Forms.Panel pnl_Con;
        private System.Windows.Forms.Timer tmr_Con;
        private System.Windows.Forms.Panel pnl_LocalTabs;
        private System.Windows.Forms.Panel pnl_IntTabs;
        private System.Windows.Forms.Panel pnl_Local;
        private System.Windows.Forms.Button btn_LInvSend;
        private System.Windows.Forms.Button btn_LQuotes;
        private System.Windows.Forms.Button btn_LOrders;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Button btn_IOrders;
        private System.Windows.Forms.Button btn_IInvSend;
        private System.Windows.Forms.Button btn_IQuotes;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.Panel pnl_Int;
    }
}
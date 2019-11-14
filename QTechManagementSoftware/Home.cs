using QTechManagementSoftware.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

//Primary Blue : 19, 118, 188
//Secondary Blue : 13, 77, 119

namespace QTechManagementSoftware
{
    public partial class Home : Form
    {
        #region Variables
        private bool mouseDown, isConOpen = false, isTabPanelVisible = false;
        private string selected = string.Empty, selectedTab = string.Empty, 
            selectedClientName, selectedClientCode, selectedProjectCode;
        private Form curTabForm, curForm = null;
        private int count = 0;
        private Point lastLocation;
        private Bunifu.Framework.UI.BunifuCustomLabel lblComing;

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            SNAP_SIZE = 3,
            _ = 10;

        Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, _); } }
        Rectangle Left { get { return new Rectangle(0, 0, _, this.ClientSize.Height); } }
        Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); } }
        Rectangle Right { get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); } }

        Rectangle TopLeft { get { return new Rectangle(0, 0, _, _); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); } }
        #endregion

        #region Initialize Form
        public Home()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true); // this is to avoid visual artifacts
        }
        #endregion

        #region Load Form
        private void Home_Load(object sender, EventArgs e)
        {
            btn_Home.BackColor = Color.FromArgb(19, 118, 188);
            btn_Home.ForeColor = Color.White;

            selected = "Home";
            HideTabPanels();

            CreateDashboardLabel();
        }
        #endregion


        #region Dashboard
        private void Btn_Home_Click(object sender, EventArgs e)
        {
            ResetButtons(selected);
            SetSelectedButton(sender);

            if (isTabPanelVisible)
                HideTabPanels();

            btn_Home.BackColor = Color.FromArgb(19, 118, 188);
            btn_Home.ForeColor = Color.White;
            btn_Home.Image = Resources.home_white;

            pnl_Home.Controls.Clear();
            CreateDashboardLabel();
        }

        private void Btn_Home_MouseEnter(object sender, EventArgs e)
        {
            if (selected != "Home")
            {
                btn_Home.BackColor = Color.FromArgb(73, 73, 73);
                btn_Home.ForeColor = Color.FromArgb(19, 118, 188);
                btn_Home.Image = Resources.home_blue;
            }
        }

        private void Btn_Home_MouseLeave(object sender, EventArgs e)
        {
            if (selected != "Home")
            {
                btn_Home.BackColor = Color.FromArgb(64, 64, 64);
                btn_Home.ForeColor = Color.White;
                btn_Home.Image = Resources.home_white;
            }
        }

        private void CreateDashboardLabel()
        {
            lblComing = new Bunifu.Framework.UI.BunifuCustomLabel();
            lblComing.Text = "Comming Soon!";
            lblComing.Font = new Font("Microsoft Sans Serif", 15);
            lblComing.AutoSize = true;
            lblComing.ForeColor = Color.DarkGray;
            lblComing.Location = new Point((pnl_Home.Width / 2) - (lblComing.Width / 2), (pnl_Home.Height / 2) - (lblComing.Height / 2));

            pnl_Home.Controls.Add(lblComing);
        }
        #endregion


        #region Local
        private void Btn_Local_Click(object sender, EventArgs e)
        {
            ResetButtons(selected);
            SetSelectedButton(sender);

            btn_Local.BackColor = Color.FromArgb(19, 118, 188);
            btn_Local.ForeColor = Color.White;
            btn_Local.Image = Resources.local_white;

            SetFormInPanel();
        }

        private void Btn_Local_MouseEnter(object sender, EventArgs e)
        {
            if (selected != "Local")
            {
                btn_Local.BackColor = Color.FromArgb(73, 73, 73);
                btn_Local.ForeColor = Color.FromArgb(19, 118, 188);
                btn_Local.Image = Resources.local_blue;
            }
        }

        private void Btn_Local_MouseLeave(object sender, EventArgs e)
        {
            if (selected != "Local")
            {
                btn_Local.BackColor = Color.FromArgb(64, 64, 64);
                btn_Local.ForeColor = Color.White;
                btn_Local.Image = Resources.local_white;
            }
        }

        public void LocalClientDoubleClick(string selectedClientCode, string selectedClientName)
        {
            this.selectedClientCode = selectedClientCode;
            this.selectedClientName = selectedClientName;

            pnl_Home.Visible = false;
            pnl_Home.Controls.Clear();

            pnl_LocalTabs.Visible = true;

            btn_LOrders.PerformClick();

            isTabPanelVisible = true;
        }
        #endregion

        #region Local Orders
        private void btn_LOrders_Click(object sender, EventArgs e)
        {
            ResetTabButtons(selectedTab);
            SetSelectedTabButton(sender);

            btn_LOrders.BackColor = Color.FromArgb(19, 118, 188);
            btn_LOrders.ForeColor = Color.White;

            SetFormInTabPanel();
        }

        private void btn_LOrders_MouseEnter(object sender, EventArgs e)
        {
            if (selectedTab != "lOrders")
            {
                btn_LOrders.BackColor = Color.FromArgb(73, 73, 73);
                btn_LOrders.ForeColor = Color.FromArgb(19, 118, 188);
            }
        }

        private void btn_LOrders_MouseLeave(object sender, EventArgs e)
        {
            if (selectedTab != "lOrders")
            {
                btn_LOrders.BackColor = Color.FromArgb(64, 64, 64);
                btn_LOrders.ForeColor = Color.White;
            }
        }
        #endregion

        #region Local Quotes
        private void btn_LQuotes_Click(object sender, EventArgs e)
        {
            ResetTabButtons(selectedTab);
            SetSelectedTabButton(sender);

            btn_LQuotes.BackColor = Color.FromArgb(19, 118, 188);
            btn_LQuotes.ForeColor = Color.White;

            SetFormInTabPanel();
        }

        private void btn_LQuotes_MouseEnter(object sender, EventArgs e)
        {
            if (selectedTab != "lQuotes")
            {
                btn_LQuotes.BackColor = Color.FromArgb(73, 73, 73);
                btn_LQuotes.ForeColor = Color.FromArgb(19, 118, 188);
            }
        }

        private void btn_LQuotes_MouseLeave(object sender, EventArgs e)
        {
            if (selectedTab != "lQuotes")
            {
                btn_LQuotes.BackColor = Color.FromArgb(64, 64, 64);
                btn_LQuotes.ForeColor = Color.White;
            }
        }
        #endregion

        #region Local Invoices Sent
        private void btn_LInvSend_Click(object sender, EventArgs e)
        {
            ResetTabButtons(selectedTab);
            SetSelectedTabButton(sender);

            btn_LInvSend.BackColor = Color.FromArgb(19, 118, 188);
            btn_LInvSend.ForeColor = Color.White;

            SetFormInTabPanel();
        }

        private void btn_LInvSend_MouseEnter(object sender, EventArgs e)
        {
            if (selectedTab != "lInvSend")
            {
                btn_LInvSend.BackColor = Color.FromArgb(73, 73, 73);
                btn_LInvSend.ForeColor = Color.FromArgb(19, 118, 188);
            }
        }

        private void btn_LInvSend_Leave(object sender, EventArgs e)
        {
            if (selectedTab != "lInvSend")
            {
                btn_LInvSend.BackColor = Color.FromArgb(64, 64, 64);
                btn_LInvSend.ForeColor = Color.White;
            }
        }
        #endregion


        #region International
        private void Btn_Int_Click(object sender, EventArgs e)
        {
            ResetButtons(selected);
            SetSelectedButton(sender);

            btn_Int.BackColor = Color.FromArgb(19, 118, 188);
            btn_Int.ForeColor = Color.White;
            btn_Int.Image = Resources.globe_white;

            SetFormInPanel();
        }

        private void Btn_Int_MouseEnter(object sender, EventArgs e)
        {
            if (selected != "Int")
            {
                btn_Int.BackColor = Color.FromArgb(73, 73, 73);
                btn_Int.ForeColor = Color.FromArgb(19, 118, 188);
                btn_Int.Image = Resources.globe_blue;
            }
        }

        private void Btn_Int_MouseLeave(object sender, EventArgs e)
        {
            if (selected != "Int")
            {
                btn_Int.BackColor = Color.FromArgb(64, 64, 64);
                btn_Int.ForeColor = Color.White;
                btn_Int.Image = (Image)Resources.globe_white;
            }
        }

        public void IntClientDoubleClick(string selectedClientCode, string selectedClientName)
        {
            this.selectedClientCode = selectedClientCode;
            this.selectedClientName = selectedClientName;

            pnl_Home.Visible = false;
            pnl_Home.Controls.Clear();

            pnl_IntTabs.Visible = true;

            btn_IOrders.PerformClick();

            isTabPanelVisible = true;
        }
        #endregion

        #region International Orders
        private void btn_IOrders_Click(object sender, EventArgs e)
        {
            ResetTabButtons(selectedTab);
            SetSelectedTabButton(sender);

            btn_IOrders.BackColor = Color.FromArgb(19, 118, 188);
            btn_IOrders.ForeColor = Color.White;

            SetFormInTabPanel();
        }

        private void btn_IOrders_MouseEnter(object sender, EventArgs e)
        {
            if (selectedTab != "iOrders")
            {
                btn_IOrders.BackColor = Color.FromArgb(73, 73, 73);
                btn_IOrders.ForeColor = Color.FromArgb(19, 118, 188);
            }
        }

        private void btn_IOrders_MouseLeave(object sender, EventArgs e)
        {
            if (selectedTab != "iOrders")
            {
                btn_IOrders.BackColor = Color.FromArgb(64, 64, 64);
                btn_IOrders.ForeColor = Color.White;
            }
        }
        #endregion

        #region International Quotes
        private void btn_IQuotes_Click(object sender, EventArgs e)
        {
            ResetTabButtons(selectedTab);
            SetSelectedTabButton(sender);

            btn_IQuotes.BackColor = Color.FromArgb(19, 118, 188);
            btn_IQuotes.ForeColor = Color.White;

            SetFormInTabPanel();
        }

        private void btn_IQuotes_MouseEnter(object sender, EventArgs e)
        {
            if (selectedTab != "iQuotes")
            {
                btn_IQuotes.BackColor = Color.FromArgb(73, 73, 73);
                btn_IQuotes.ForeColor = Color.FromArgb(19, 118, 188);
            }
        }

        private void btn_IQuotes_MouseLeave(object sender, EventArgs e)
        {
            if (selectedTab != "iQuotes")
            {
                btn_IQuotes.BackColor = Color.FromArgb(64, 64, 64);
                btn_IQuotes.ForeColor = Color.White;
            }
        }
        #endregion

        #region International Invoices Sent
        private void btn_IInvSend_Click(object sender, EventArgs e)
        {
            ResetTabButtons(selectedTab);
            SetSelectedTabButton(sender);

            btn_IInvSend.BackColor = Color.FromArgb(19, 118, 188);
            btn_IInvSend.ForeColor = Color.White;

            SetFormInTabPanel();
        }

        private void btn_IInvSend_Leave(object sender, EventArgs e)
        {
            if (selectedTab != "iInvSend")
            {
                btn_IInvSend.BackColor = Color.FromArgb(73, 73, 73);
                btn_IInvSend.ForeColor = Color.FromArgb(19, 118, 188);
            }
        }

        private void btn_IInvSend_MouseEnter(object sender, EventArgs e)
        {
            if (selectedTab != "iInvSend")
            {
                btn_IInvSend.BackColor = Color.FromArgb(64, 64, 64);
                btn_IInvSend.ForeColor = Color.White;
            }
        }
        #endregion


        #region Contractors
        private void Btn_Contractors_Click(object sender, EventArgs e)
        {
            ResetButtons(selected);
            SetSelectedButton(sender);

            btn_Contractors.BackColor = Color.FromArgb(19, 118, 188);
            btn_Contractors.ForeColor = Color.White;
            btn_Contractors.Image = Resources.contr_white;

            if (!isConOpen)
                tmr_Con.Start();

            SetFormInPanel();
        }

        private void Btn_Contractors_MouseEnter(object sender, EventArgs e)
        {
            if (selected != "Contractors")
            {
                btn_Contractors.BackColor = Color.FromArgb(73, 73, 73);
                btn_Contractors.ForeColor = Color.FromArgb(19, 118, 188);
                btn_Contractors.Image = Resources.contr_blue;
            }
        }

        private void Btn_Contractors_MouseLeave(object sender, EventArgs e)
        {
            if (selected != "Contractors")
            {
                btn_Contractors.BackColor = Color.FromArgb(64, 64, 64);
                btn_Contractors.ForeColor = Color.White;
                btn_Contractors.Image = Resources.contr_white;
            }
        }
        #endregion

        #region Outstanding Remittances
        private void Btn_C_NoRem_Click(object sender, EventArgs e)
        {
            ResetButtons(selected);
            SetSelectedButton(sender);

            btn_C_NoRem.BackColor = Color.FromArgb(15, 91, 142);
            btn_C_NoRem.ForeColor = Color.White;

            SetFormInPanel();
        }

        private void Btn_C_NoRem_MouseEnter(object sender, EventArgs e)
        {
            if (selected != "cNoRem")
            {
                btn_C_NoRem.BackColor = Color.FromArgb(56, 56, 56);
                btn_C_NoRem.ForeColor = Color.FromArgb(15, 91, 142);
            }
        }

        private void Btn_C_NoRem_MouseLeave(object sender, EventArgs e)
        {
            if (selected != "cNoRem")
            {
                btn_C_NoRem.BackColor = Color.FromArgb(50, 50, 50);
                btn_C_NoRem.ForeColor = Color.White;
            }
        }
        #endregion

        #region Outstanding Invoices
        private void btn_C_NoInv_Click(object sender, EventArgs e)
        {
            ResetButtons(selected);
            SetSelectedButton(sender);

            btn_C_NoInv.BackColor = Color.FromArgb(15, 91, 142);
            btn_C_NoInv.ForeColor = Color.White;

            SetFormInPanel();
        }

        private void Btn_C_NoInv_MouseEnter(object sender, EventArgs e)
        {
            if (selected != "cNoInv")
            {
                btn_C_NoInv.BackColor = Color.FromArgb(56, 56, 56);
                btn_C_NoInv.ForeColor = Color.FromArgb(15, 91, 142);
            }
        }

        private void Btn_C_NoInv_MouseLeave(object sender, EventArgs e)
        {
            if (selected != "cNoInv")
            {
                btn_C_NoInv.BackColor = Color.FromArgb(50, 50, 50);
                btn_C_NoInv.ForeColor = Color.White;
            }
        }
        #endregion


        #region Projects
        private void Btn_Projects_Click(object sender, EventArgs e)
        {
            ResetButtons(selected);
            SetSelectedButton(sender);

            btn_Projects.BackColor = Color.FromArgb(19, 118, 188);
            btn_Projects.ForeColor = Color.White;
            btn_Projects.Image = Resources.project_white;

            SetFormInPanel();
        }

        private void Btn_Projects_MouseEnter(object sender, EventArgs e)
        {
            if (selected != "Projects")
            {
                btn_Projects.BackColor = Color.FromArgb(73, 73, 73);
                btn_Projects.ForeColor = Color.FromArgb(19, 118, 188);
                btn_Projects.Image = Resources.project_blue;
            }
        }

        private void Btn_Projects_MouseLeave(object sender, EventArgs e)
        {
            if (selected != "Projects")
            {
                btn_Projects.BackColor = Color.FromArgb(64, 64, 64);
                btn_Projects.ForeColor = Color.White;
                btn_Projects.Image = Resources.project_white;
            }
        }

        public void SetProjExpForm()
        {
            Proj_AddExp frmAE = new Proj_AddExp();
            frmAE.SetProjectCode(selectedProjectCode);
            frmAE.SetHome(this);

            curForm = frmAE;

            pnl_Home.Controls.Clear();
            SetFormInPanel();
        }

        public void AddExpFormClose()
        {
            btn_Projects.PerformClick();
        }

        public void ProjectsDoubleClick(string selectedProjectCode)
        {
            this.selectedProjectCode = selectedProjectCode;

            SetProjExpForm();
        }
        #endregion

        #region Petty Cash
        private void Btn_PettyCash_Click(object sender, EventArgs e)
        {
            ResetButtons(selected);
            SetSelectedButton(sender);

            btn_PettyCash.BackColor = Color.FromArgb(13, 77, 119);
            btn_PettyCash.ForeColor = Color.White;

            SetFormInPanel();
        }

        private void Btn_PettyCash_MouseEnter(object sender, EventArgs e)
        {
            if (selected != "lPettyCash")
            {
                btn_PettyCash.BackColor = Color.FromArgb(73, 73, 73);
                btn_PettyCash.ForeColor = Color.FromArgb(19, 118, 188);
                btn_PettyCash.Image = Resources.cash_blue;
            }
        }

        private void Btn_PettyCash_MouseLeave(object sender, EventArgs e)
        {
            if (selected != "lPettyCash")
            {
                btn_PettyCash.BackColor = Color.FromArgb(64, 64, 64);
                btn_PettyCash.ForeColor = Color.White;
                btn_PettyCash.Image = Resources.cash_White;
            }
        }
        #endregion


        #region Close Clicked
        private void Btn_Home_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Home_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_Home_Close.Image = Resources.close_white;
        }

        private void Btn_Home_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_Home_Close.Image = Resources.close_black;
        }
        #endregion

        #region Maximize Clicked
        private void Btn_Home_Max_MouseEnter(object sender, EventArgs e)
        {
            btn_Home_Max.Image = Resources.maximize_white;
        }

        private void Btn_Home_Max_MouseLeave(object sender, EventArgs e)
        {
            btn_Home_Max.Image = Resources.maximize_black;
        }

        private void Btn_Home_Max_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            if (curForm != null && !isTabPanelVisible)
            {
                pnl_Home.Controls.Clear();
                SetFormInPanel();
            }
            else if (curTabForm != null && isTabPanelVisible)
            {
                pnl_Local.Controls.Clear();
                pnl_Int.Controls.Clear();
                SetFormInTabPanel();
            }

            btn_Home_Max.Visible = false;
            btn_Home_Nor.Visible = true;
            lblComing.Location = new Point((pnl_Home.Width / 2) - (lblComing.Width / 2), (pnl_Home.Height / 2) - (lblComing.Height / 2));
        }
        #endregion

        #region Normalize Clicked
        private void Btn_Home_Nor_MouseEnter(object sender, EventArgs e)
        {
            btn_Home_Nor.Image = Resources.restore_white;
        }

        private void Btn_Home_Nor_MouseLeave(object sender, EventArgs e)
        {
            btn_Home_Nor.Image = Resources.restore_black2;
        }

        private void Btn_Home_Nor_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btn_Home_Nor.Visible = false;
            btn_Home_Max.Visible = true;
            lblComing.Location = new Point((pnl_Home.Width / 2) - (lblComing.Width / 2), (pnl_Home.Height / 2) - (lblComing.Height / 2));
        }
        #endregion

        #region Minimize Clicked
        private void Btn_Home_Min_MouseEnter(object sender, EventArgs e)
        {
            btn_Home_Min.Image = Resources.minimize_white;
        }

        private void Btn_Home_Min_MouseLeave(object sender, EventArgs e)
        {
            btn_Home_Min.Image = Resources.minimize_grey;
        }

        private void Btn_Home_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion


        #region Get & Set Selected Button
        private void SetSelectedButton(object sender)
        {
            Button b = (Button)sender;
            string name = b.Name;

            switch (name)
            {
                case "btn_Home":
                    {
                        selected = "Home";
                        curForm = null;
                        CheckConTabOpen();
                        break;
                    }
                case "btn_Local":
                    {
                        selected = "Local";
                        curForm = new Clients();
                        CheckConTabOpen();
                        break;
                    }
                case "btn_Int":
                    {
                        selected = "Int";
                        curForm = new Clients();
                        CheckConTabOpen();
                        break;
                    }
                case "btn_Contractors":
                    {
                        selected = "Contractors";
                        curForm = new Contractors();
                        break;
                    }
                case "btn_C_NoRem":
                    {
                        selected = "cNoRem";
                        curForm = new NoRemittances();
                        break;
                    }
                case "btn_C_NoInv":
                    {
                        selected = "cNoInv";
                        curForm = new NoInvoices();
                        break;
                    }
                case "btn_Projects":
                    {
                        selected = "Projects";
                        Projects frmProj = new Projects();
                        frmProj.Owner = this;
                        curForm = frmProj;
                        CheckConTabOpen();
                        break;
                    }
                case "btn_PettyCash":
                    {
                        selected = "PettyCash";
                        curForm = new PettyCash();
                        CheckConTabOpen();
                        break;
                    }
            }
        }

        public string GetSelectedButton() { return selected; }

        private void SetSelectedTabButton(object sender)
        {
            Button b = (Button)sender;
            string name = b.Name;

            switch (name)
            {
                case "btn_LOrders":
                    {
                        selectedTab = "lOrders";
                        Orders frmLOrders = new Orders();
                        frmLOrders.SetClient(selectedClientCode, selectedClientName);
                        curTabForm = frmLOrders;
                        break;
                    }
                case "btn_LQuotes":
                    {
                        selectedTab = "lQuotes";
                        Quotes frmLQuotes = new Quotes();
                        frmLQuotes.SetClient(selectedClientCode, selectedClientName);
                        curTabForm = frmLQuotes;
                        break;
                    }
                case "btn_LInvSend":
                    {
                        selectedTab = "lInvSend";
                        Invoices_Send frmInvSend = new Invoices_Send();
                        frmInvSend.SetClient(selectedClientCode, selectedClientName);
                        curTabForm = frmInvSend;
                        break;
                    }
                case "btn_IOrders":
                    {
                        selectedTab = "iOrders";
                        Int_Orders frmIOrders = new Int_Orders();
                        frmIOrders.SetClient(selectedClientCode, selectedClientName);
                        curTabForm = frmIOrders;
                        break;
                    }
                case "btn_IQuotes":
                    {
                        selectedTab = "iQuotes";
                        Int_Quotes frmIQuotes = new Int_Quotes();
                        frmIQuotes.SetClient(selectedClientCode, selectedClientName);
                        curTabForm = frmIQuotes;
                        break;
                    }
                case "btn_IInvSend":
                    {
                        selectedTab = "iInvSend";
                        Int_Invoices_Send frmIInvSend = new Int_Invoices_Send();
                        frmIInvSend.SetClient(selectedClientCode, selectedClientName);
                        curTabForm = frmIInvSend;
                        break;
                    }
            }
        }
        #endregion

        #region Reset Buttons
        private void ResetButtons(string name)
        {
            switch (name)
            {
                case "Home":
                    {
                        btn_Home.BackColor = Color.FromArgb(64, 64, 64);
                        btn_Home.ForeColor = Color.White;
                        lblComing.Visible = false;
                        pnl_Home.Controls.Clear();
                        count = 0;

                        break;
                    }
                case "Local":
                    {
                        btn_Local.BackColor = Color.FromArgb(64, 64, 64);
                        btn_Local.ForeColor = Color.White;
                        pnl_Home.Controls.Clear();
                        count = 0;
                        break;
                    }
                case "Int":
                    {
                        btn_Int.BackColor = Color.FromArgb(64, 64, 64);
                        btn_Int.ForeColor = Color.White;
                        pnl_Home.Controls.Clear();
                        break;
                    }
                case "Contractors":
                    {
                        btn_Contractors.BackColor = Color.FromArgb(64, 64, 64);
                        btn_Contractors.ForeColor = Color.White;
                        pnl_Home.Controls.Clear();
                        break;
                    }
                case "cNoRem":
                    {
                        btn_C_NoRem.BackColor = Color.FromArgb(50, 50, 50);
                        btn_C_NoRem.ForeColor = Color.White;
                        pnl_Home.Controls.Clear();
                        break;
                    }
                case "cNoInv":
                    {
                        btn_C_NoInv.BackColor = Color.FromArgb(50, 50, 50);
                        btn_C_NoInv.ForeColor = Color.White;
                        pnl_Home.Controls.Clear();
                        break;
                    }
                case "Projects":
                    {
                        btn_Projects.BackColor = Color.FromArgb(64, 64, 64);
                        btn_Projects.ForeColor = Color.White;
                        pnl_Home.Controls.Clear();
                        break;
                    }
                case "PettyCash":
                    {
                        btn_PettyCash.BackColor = Color.FromArgb(64, 64, 64);
                        btn_PettyCash.ForeColor = Color.White;
                        pnl_Home.Controls.Clear();
                        break;
                    }
            }
        }

        private void ResetTabButtons(string name)
        {
            switch (name)
            {
                case "lOrders":
                    {
                        btn_LOrders.BackColor = Color.FromArgb(64, 64, 64);
                        btn_LOrders.ForeColor = Color.White;
                        pnl_Local.Controls.Clear();
                        break;
                    }
                case "lQuotes":
                    {
                        btn_LQuotes.BackColor = Color.FromArgb(64, 64, 64);
                        btn_LQuotes.ForeColor = Color.White;
                        pnl_Local.Controls.Clear();
                        break;
                    }
                case "lInvSend":
                    {
                        btn_LInvSend.BackColor = Color.FromArgb(64, 64, 64);
                        btn_LInvSend.ForeColor = Color.White;
                        pnl_Local.Controls.Clear();
                        break;
                    }
                case "iOrders":
                    {
                        btn_IOrders.BackColor = Color.FromArgb(64, 64, 64);
                        btn_IOrders.ForeColor = Color.White;
                        pnl_Int.Controls.Clear();
                        break;
                    }
                case "iQuotes":
                    {
                        btn_IQuotes.BackColor = Color.FromArgb(64, 64, 64);
                        btn_IQuotes.ForeColor = Color.White;
                        pnl_Int.Controls.Clear();
                        break;
                    }
                case "iInvSend":
                    {
                        btn_IInvSend.BackColor = Color.FromArgb(64, 64, 64);
                        btn_IInvSend.ForeColor = Color.White;
                        pnl_Int.Controls.Clear();
                        break;
                    }
            }
        }
        #endregion


        #region Open / Close Contractor Tab
        private void Tmr_Con_Tick(object sender, EventArgs e)
        {
            if (isConOpen)
            {
                if (pnl_Con.Height <= 48)
                {
                    tmr_Con.Stop();
                    isConOpen = false;
                }
                else if (pnl_Con.Height == 54)
                {
                    pnl_Con.Height -= 6;
                    btn_Projects.Location = new Point(btn_Projects.Location.X, btn_Projects.Location.Y - 6);
                    btn_PettyCash.Location = new Point(btn_PettyCash.Location.X, btn_PettyCash.Location.Y - 6);
                }
                else
                {
                    pnl_Con.Height -= 15;
                    btn_Projects.Location = new Point(btn_Projects.Location.X, btn_Projects.Location.Y - 15);
                    btn_PettyCash.Location = new Point(btn_PettyCash.Location.X, btn_PettyCash.Location.Y - 15);
                }
            }
            else if (pnl_Con.Height >= 144)
            {
                tmr_Con.Stop();
                isConOpen = true;
            }
            else if (pnl_Con.Height == 138)
            {
                pnl_Con.Height += 6;
                btn_Projects.Location = new Point(btn_Projects.Location.X, btn_Projects.Location.Y + 6);
                btn_PettyCash.Location = new Point(btn_PettyCash.Location.X, btn_PettyCash.Location.Y + 6);
            }
            else
            {
                pnl_Con.Height += 15;
                btn_Projects.Location = new Point(btn_Projects.Location.X, btn_Projects.Location.Y + 15);
                btn_PettyCash.Location = new Point(btn_PettyCash.Location.X, btn_PettyCash.Location.Y + 15);
            }
        }

        private void CheckConTabOpen()
        {
            if (isConOpen)
                tmr_Con.Start();
        }
        #endregion


        #region Set Forms In Panels
        private void HideTabPanels()
        {
            pnl_LocalTabs.Visible = false;
            pnl_IntTabs.Visible = false;
            pnl_Home.Visible = true;
            isTabPanelVisible = false;
        }

        private void SetFormInPanel()
        {
            if (!isTabPanelVisible)
            {
                curForm.TopLevel = false;
                curForm.TopMost = true;
                curForm.Dock = DockStyle.Fill;

                pnl_Home.Controls.Add(curForm);
                curForm.Show();
            }
            else
            {
                HideTabPanels();

                curForm.TopLevel = false;
                curForm.TopMost = true;
                curForm.Dock = DockStyle.Fill;

                pnl_Home.Controls.Add(curForm);
                curForm.Show();
            }
        }

        private void SetFormInTabPanel()
        {
            curTabForm.TopLevel = false;
            curTabForm.TopMost = true;
            curTabForm.Dock = DockStyle.Fill;

            if (selected == "Local")
                pnl_Local.Controls.Add(curTabForm);
            else if (selected == "Int")
                pnl_Int.Controls.Add(curTabForm);

            curTabForm.Show();
        }
        #endregion


        #region Form Size & Movement
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    var cursor = this.PointToClient(Cursor.Position);

                    if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                    else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                    else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                    else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                    else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                    else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                    else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                    else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
                }
            }
        }

        private void Home_SizeChanged(object sender, EventArgs e)
        {
            if (lblComing != null)
                lblComing.Location = new Point((pnl_Home.Width / 2) - (lblComing.Width / 2), (pnl_Home.Height / 2) - (lblComing.Height / 2));

            if (count != 1)
            {
                if (curForm != null && !isTabPanelVisible)
                {
                    pnl_Home.Controls.Clear();
                    SetFormInPanel();
                }
                else if (curTabForm != null && isTabPanelVisible)
                {
                    pnl_Local.Controls.Clear();
                    pnl_Int.Controls.Clear();
                    SetFormInTabPanel();
                }

                count++;
            }              
        }        

        private void windowBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (this.WindowState == FormWindowState.Maximized)
                    btn_Home_Nor.PerformClick();

                //Moves the form to a new location as long as user has mouse click down
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                //Updates the main form with the new position
                this.Update();
            }
        }

        private void windowBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

            int cursorLoc = Cursor.Position.Y;

            if ((cursorLoc >= 0) && (cursorLoc <= SNAP_SIZE) && (this.WindowState == FormWindowState.Normal)) btn_Home_Max.PerformClick();
        }

        private void windowBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        #endregion
    }
}

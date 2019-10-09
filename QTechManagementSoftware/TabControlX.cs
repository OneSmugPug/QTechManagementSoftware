using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTechManagementSoftware
{
    public partial class TabControlX : UserControl
    {


        public TabControlX()
        {
            InitializeComponent();
        }

        int selected_index = -1;
        public List<ButtonX> buttonlist = new List<ButtonX> { };
        public List<Panel> tabPanelCtrlList = new List<Panel> { };

        void UpdateButtons()
        {
            if (buttonlist.Count > 0)
            {
                for (int i = 0; i < buttonlist.Count; i++)
                {
                    if (i == selected_index)
                    {
                        buttonlist[i].ChangeColorMouseHC = false;
                        buttonlist[i].BXBackColor = Color.FromArgb(15, 91, 142);
                        buttonlist[i].ForeColor = Color.White;
                        buttonlist[i].MouseHoverColor = Color.FromArgb(15, 91, 142);
                        buttonlist[i].MouseClickColor1 = Color.FromArgb(19,118,188);
                    }
                    else
                    {
                        buttonlist[i].ChangeColorMouseHC = true;
                        buttonlist[i].ForeColor = Color.White;
                        buttonlist[i].MouseHoverColor = Color.FromArgb(15, 91, 142);
                        buttonlist[i].BXBackColor = Color.FromArgb(64,64,64);
                        buttonlist[i].MouseClickColor1 = Color.FromArgb(19,118,188) ;
                    }
                }

            }
        }

        void createAndAddButton(string tabtext, Panel tpcontrol, Point loc)
        {
            ButtonX b = new ButtonX();
            
            b.Size = new Size(130, 30);
            b.Location = loc;
            b.ForeColor = Color.White;
            b.BXBackColor = Color.FromArgb(64, 64, 64);
            b.MouseHoverColor = Color.FromArgb(15, 91, 142);
            b.MouseClickColor1 = Color.FromArgb(19,118,188);
            b.ChangeColorMouseHC = false;
            b.TextLocation_X = 10;
            b.TextLocation_Y = 9;
            b.Font = this.Font;
            switch (tabtext)
            {
                case "International Orders":
                    b.Text = "Orders";
                    b.Click += button_ClickInt;
                    break;
                case "International Quotes":
                    b.Text = "Quotes";
                    b.Click += button_ClickInt;
                    break;
                case "International Invoices Sent":
                    b.Text = "Invoices Sent";
                    b.Click += button_ClickInt;
                    break;
                case "Orders":
                    b.Text = tabtext;
                    b.Click += button_ClickLocal;
                    break;
                case "Quotes":
                    b.Text = tabtext;
                    b.Click += button_ClickLocal;
                    break;
                case "Invoices Sent":
                    b.Text = tabtext;
                    b.Click += button_ClickLocal;
                    break;
                case "Invoices Received":
                    b.Text = tabtext;
                    b.Click += button_ClickLocal;
                    break;
                default:
                    break;
            }
            TabButtonPanel.Controls.Add(b);
            buttonlist.Add(b);

            tabPanelCtrlList.Add(tpcontrol);
            TabPanel.Controls.Clear();
            TabPanel.Controls.Add(tpcontrol);
            SetToFirstTab();
            UpdateButtons();
        }

        void button_ClickLocal(object sender, EventArgs e)
        {
            Home homeFrm = (Home)Parent;
            
            string btext = ((ButtonX)sender).Text;
            int index = 0, i;

            for (i = 0; i < buttonlist.Count; i++)
            {
                if (buttonlist[i].Text == btext)
                {
                    index = i;
                }
            }

            switch (btext)
            {
                case "Orders":
                    homeFrm.SetCurForm("Orders");
                    break;
                case "Quotes":
                    homeFrm.SetCurForm("Quotes");
                    break;
                case "Invoices Sent":
                    homeFrm.SetCurForm("Invoices Sent");
                    break;
                case "Invoices Received":
                    homeFrm.SetCurForm("Invoices Received");
                    break;
                default:
                    break;
            }

            TabPanel.Controls.Clear();
            TabPanel.Controls.Add(tabPanelCtrlList[index]);
            selected_index = index;

            //(tabPanelCtrlList[index]).Dock = DockStyle.Fill;

            UpdateButtons();
        }

        void button_ClickInt(object sender, EventArgs e)
        {
            Home homeFrm = (Home)Parent;

            string btext = ((ButtonX)sender).Text;
            int index = 0, i;
            for (i = 0; i < buttonlist.Count; i++)
            {
                if (buttonlist[i].Text == btext)
                {
                    index = i;
                }
            }

            switch (btext)
            {
                case "Orders":
                    homeFrm.SetCurForm("International Orders");
                    break;
                case "Quotes":
                    homeFrm.SetCurForm("International Quotes");
                    break;
                case "Invoices Sent":
                    homeFrm.SetCurForm("International Invoices Sent");
                    break;
                default:
                    break;
            }

            TabPanel.Controls.Clear();
            TabPanel.Controls.Add(tabPanelCtrlList[index]);
            selected_index = ((ButtonX)sender).TabIndex;

            UpdateButtons();
        }


        public void AddTab(string tabtext, Panel tpcontrol)
        {
            if (!buttonlist.Any())
            {
                TabPanel.Controls.Clear();

                createAndAddButton(tabtext, tpcontrol, new Point(0, 0));

                TabPanel.Controls.Add(tpcontrol);
            }
            else
            {
                createAndAddButton(tabtext, tpcontrol, new Point(buttonlist[buttonlist.Count - 1].Size.Width + buttonlist[buttonlist.Count - 1].Location.X, 0));
            }
        }

        public void SetToFirstTab()//***
        {
            selected_index = 0;
            TabPanel.Controls.Clear();
            TabPanel.Controls.Add(tabPanelCtrlList[selected_index]);
        }

        public void ClearTabs() 
        { 
            buttonlist.Clear();
            TabButtonPanel.Controls.Clear();
            tabPanelCtrlList.Clear();
            UpdateButtons();
        }

        public void RefreshPanels()
        {
            TabPanel.Refresh();
        }
    }
}

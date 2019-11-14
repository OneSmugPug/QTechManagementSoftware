using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;
using System.Globalization;

namespace QTechManagementSoftware
{
    public partial class Invoices_Send : Form
    {
        #region Variables
        private BindingSource bs = new BindingSource();
        private bool isFiltered = false;
        private string clientName, clientCode, SELECTED_INVSEND;
        private DataTable dt;
        
        #endregion

        #region Initialize Form
        public Invoices_Send()
        {
            InitializeComponent();
        }
        #endregion

        #region Load Form
        private void Invoices_Send_Load(object sender, EventArgs e)
        {
            dtp_LIS_From.Value = DateTime.Now;
            dtp_LIS_To.Value = DateTime.Now;

            dgv_LInvSent.DataSource = bs;

            LoadInvSend();

            dgv_LInvSent.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_LInvSent.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            txt_LIS_CCode.Text = clientCode;
            txt_LIS_CName.Text = clientName;
        }

        private void LoadInvSend()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Invoices_Send WHERE Client LIKE '" + clientName + "%'", conn);
                dt = new DataTable();
                sqlDataAdapter.Fill(dt);
            }

            bs.DataSource = dt;
        }
        #endregion

        #region Getters & Setters
        //================================================================================================================================================//
        // SETTERS                                                                                                                                        //
        //================================================================================================================================================//
        public void SetClient(string selectedClientCode, string selectedClientName)
        {
            clientCode = selectedClientCode;
            clientName = selectedClientName;
        }

        //================================================================================================================================================//
        // GETTERS                                                                                                                                        //
        //================================================================================================================================================//
        public string GetClientCode()
        {
            return clientCode;
        }

        public string GetClientName()
        {
            return clientName;
        }

        public string GetSelectedInvSend()
        {
            return SELECTED_INVSEND;
        }

        public DataTable GetInvoices()
        {
            return dt;
        }
        #endregion

        #region New Invoice Sent Clicked
        private void btn_LIS_NewIS_Click(object sender, EventArgs e)
        {
            if (isFiltered)
                removeFilter();

            using (Inv_Send_Add frmISA = new Inv_Send_Add())
            {
                frmISA.Owner = this;
                frmISA.ShowDialog();
            }

            LoadInvSend();
        }
        #endregion

        #region DGV Cell DoubleClicked
        private void dgv_LInvSent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isFiltered)
                removeFilter();

            SELECTED_INVSEND = dgv_LInvSent[1, e.RowIndex].Value.ToString();

            using (Inv_Send_Edit_Del frmISED = new Inv_Send_Edit_Del())
            {
                frmISED.Owner = this;
                frmISED.ShowDialog();
            }

            LoadInvSend();
        }
        #endregion

        #region DGV Filters
        private void dgv_LInvSent_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgv_LInvSent.FilterString;
        }

        private void dgv_LInvSent_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgv_LInvSent.SortString;
        }

        private void btn_LIS_Filter_Click(object sender, EventArgs e)
        {
            bs.Filter = string.Empty;
            bs.Sort = string.Empty;
            isFiltered = true;

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Invoices_Send WHERE Client LIKE '" + clientName + "%' AND Date BETWEEN '" + dtp_LIS_From.Value + "' AND '" + dtp_LIS_To.Value + "'", conn);
                dt = new DataTable();
                sqlDataAdapter.Fill(dt);
            }

            bs.DataSource = (object)dt;
            btn_LIS_Filter.Visible = false;
            btn_LIS_ClearFilter.Visible = true;
        }

        private void btn_LIS_ClearFilter_Click(object sender, EventArgs e)
        {
            removeFilter();
        }

        private void removeFilter()
        {
            LoadInvSend();
            btn_LIS_Filter.Visible = true;
            btn_LIS_ClearFilter.Visible = false;
        }
        #endregion

        #region Controls Effects
        //================================================================================================================================================//
        // NEW INVOICE SENT BUTTON                                                                                                                        //
        //================================================================================================================================================//
        private void btn_LIS_NewIS_MouseEnter(object sender, EventArgs e)
        {
            btn_LIS_NewIS.Image = Resources.add_white;
            btn_LIS_NewIS.ForeColor = Color.White;
        }

        private void btn_LIS_NewIS_MouseLeave(object sender, EventArgs e)
        {
            btn_LIS_NewIS.Image = Resources.add_grey;
            btn_LIS_NewIS.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // FILTER BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void btn_LIS_Filter_MouseEnter(object sender, EventArgs e)
        {
            btn_LIS_Filter.Image = Resources.filter_white;
            btn_LIS_Filter.ForeColor = Color.White;
        }

        private void btn_LIS_Filter_MouseLeave(object sender, EventArgs e)
        {
            btn_LIS_Filter.Image = Resources.filter_grey;
            btn_LIS_Filter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLEAR FILTER BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void btn_LIS_ClearFilter_MouseEnter(object sender, EventArgs e)
        {
            btn_LIS_ClearFilter.ForeColor = Color.White;
        }

        private void btn_LIS_ClearFilter_MouseLeave(object sender, EventArgs e)
        {
            btn_LIS_ClearFilter.ForeColor = Color.FromArgb(64, 64, 64);
        }
        #endregion

        #region ReadOnly Controls
        private void txt_LIS_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txt_LIS_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        #endregion
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;

namespace QTechManagementSoftware
{
    public partial class Int_Invoices_Send : Form
    {
        private int CUR_CLIENT = 0;
        private BindingSource bs = new BindingSource();
        private bool isFiltered = false;
        private object send = null;
        private int NUM_OF_CLIENTS;
        private int SELECTED_INVSEND;
        private string CNAME;
        private string NEW_INVOICE;
        private DataTable clientsDT;
        private DataTable dt;

        public Int_Invoices_Send()
        {
            InitializeComponent();
        }


        //================================================================================================================================================//
        // LOAD INVOICES SEND FORM                                                                                                                        //
        //================================================================================================================================================//
        private void Invoices_Send_Load(object sender, EventArgs e)
        {
            dgv_IInvSent.DataSource = bs;

            LoadClients();
            LoadInvSend();

            dgv_IInvSent.Columns[4].DefaultCellStyle.Format = "c";
            dgv_IInvSent.Columns[4].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dgv_IInvSent.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_IInvSent.Columns[5].DefaultCellStyle.Format = "c";
            dgv_IInvSent.Columns[5].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dgv_IInvSent.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        //================================================================================================================================================//
        // LOAD CLIENT DETAILS                                                                                                                            //
        //================================================================================================================================================//
        private void LoadClients()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Int_Clients", conn);
                clientsDT = new DataTable();
                sqlDataAdapter.Fill(clientsDT);
            }

            if (clientsDT.Rows.Count > 0)
            {
                if (!dgv_IInvSent.Enabled)
                    dgv_IInvSent.Enabled = true;

                if (!btn_IIS_NewIS.Enabled)
                    btn_IIS_NewIS.Enabled = true;

                NUM_OF_CLIENTS = clientsDT.Rows.Count - 1;
                txt_IIS_CCode.Text = clientsDT.Rows[CUR_CLIENT]["Code"].ToString().Trim();
                CNAME = clientsDT.Rows[CUR_CLIENT]["Name"].ToString().Trim();
                txt_IIS_CName.Text = CNAME;
            }
            else
            {
                dgv_IInvSent.Enabled = false;
                btn_IIS_NewIS.Enabled = false;
            }
        }


        //================================================================================================================================================//
        // LOAD INVOICES SEND DETAILS                                                                                                                     //
        //================================================================================================================================================//
        private void LoadInvSend()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Invoices_Send WHERE Client LIKE '" + CNAME + "%'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }
            bs.DataSource = dt;
        }


        
        //================================================================================================================================================//
        // SET NEW CLIENT                                                                                                                                 //
        //================================================================================================================================================//
        public void SetNewClient(int rowIdx)
        {
            CUR_CLIENT = rowIdx;
            LoadClients();
            LoadInvSend();
        }


        //================================================================================================================================================//
        // NEW INVOICE SEND CLICK                                                                                                                         //
        //================================================================================================================================================//
        private void Btn_IIS_NewIS_Click(object sender, EventArgs e)
        {
            if (isFiltered)
                RemoveFilter();

            using (Inv_Send_Add frmISA = new Inv_Send_Add())
                frmISA.ShowDialog(this);

            LoadInvSend();

            if (send == null)
            {
                foreach (DataGridViewRow row in dgv_IInvSent.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(NEW_INVOICE))
                    {
                        SELECTED_INVSEND = row.Index;
                        break;
                    }
                }
                using (Inv_Send_Edit_Del frmISED = new Inv_Send_Edit_Del())
                {
                    frmISED.ShowDialog(this);
                }
                LoadInvSend();
            }
            else send = null;
        }


        //================================================================================================================================================//
        // GETTERS                                                                                                                                        //
        //================================================================================================================================================//
        public string GetCCode()
        {
            return txt_IIS_CCode.Text;
        }

        public string GetCName()
        {
            return CNAME;
        }

        public int GetSelectedInvSend()
        {
            return SELECTED_INVSEND;
        }

        public DataTable GetInvoices()
        {
            return dt;
        }


        //================================================================================================================================================//
        // SETTERS                                                                                                                                        //
        //================================================================================================================================================//
        public void SetNewInvoice(string invNum)
        {
            NEW_INVOICE = invNum;
        }

        public void SetSender(object sender)
        {
            send = sender;
        }


        //================================================================================================================================================//
        // DATAGRIDVIEW CELL DOUBLECLICK                                                                                                                  //
        //================================================================================================================================================//
        private void Dgv_IInvSent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isFiltered)
                RemoveFilter();

            SELECTED_INVSEND = e.RowIndex;

            using (Inv_Send_Edit_Del frmISED = new Inv_Send_Edit_Del())
                frmISED.ShowDialog(this);

            LoadInvSend();
        }


        //================================================================================================================================================//
        // FILTERS                                                                                                                                        //
        //================================================================================================================================================//
        private void Dgv_IInvSent_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgv_IInvSent.FilterString;
        }

        private void Dgv_IInvSent_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgv_IInvSent.SortString;
        }

        private void Btn_IIS_Filter_Click(object sender, EventArgs e)
        {
            bs.Filter = string.Empty;
            bs.Sort = string.Empty;
            isFiltered = true;

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Invoices_Send WHERE Client LIKE '" + CNAME + "%' AND Date BETWEEN '" + dtp_IIS_From.Value + "' AND '" + dtp_IIS_To.Value + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }

            bs.DataSource = dt;
            btn_IIS_Filter.Visible = false;
            btn_IIS_ClearFilter.Visible = true;
        }

        private void Btn_IIS_ClearFilter_Click(object sender, EventArgs e)
        {
            RemoveFilter();
        }

        private void RemoveFilter()
        {
            LoadInvSend();
            btn_IIS_Filter.Visible = true;
            btn_IIS_ClearFilter.Visible = false;
        }

        //================================================================================================================================================//
        // NEW INVOICE SEND BUTTON                                                                                                                        //
        //================================================================================================================================================//
        private void Btn_IIS_NewIS_MouseEnter(object sender, EventArgs e)
        {
            btn_IIS_NewIS.Image = Resources.add_white;
            btn_IIS_NewIS.ForeColor = Color.White;
        }

        private void Btn_IIS_NewIS_MouseLeave(object sender, EventArgs e)
        {
            btn_IIS_NewIS.Image = Resources.add_grey;
            btn_IIS_NewIS.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // FILTER BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_IIS_Filter_MouseEnter(object sender, EventArgs e)
        {
            btn_IIS_Filter.Image = Resources.filter_white;
            btn_IIS_Filter.ForeColor = Color.White;
        }

        private void Btn_IIS_Filter_MouseLeave(object sender, EventArgs e)
        {
            btn_IIS_Filter.Image = Resources.filter_grey;
            btn_IIS_Filter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLEAR FILTER BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_IIS_ClearFilter_MouseEnter(object sender, EventArgs e)
        {
            btn_IIS_ClearFilter.ForeColor = Color.White;
        }

        private void Btn_IIS_ClearFilter_MouseLeave(object sender, EventArgs e)
        {
            btn_IIS_ClearFilter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // ENFORCE READ ONLY                                                                                                                              //
        //================================================================================================================================================//
        private void Txt_IIS_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_IIS_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}

using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;

namespace QTechManagementSoftware
{
    public partial class Quotes : Form
    {
        private int CUR_CLIENT = 0;
        private BindingSource bs = new BindingSource();
        private bool isFiltered = false;
        private int NUM_OF_CLIENTS;
        private int SELECTED_QUOTE;
        private string CNAME;
        private DataTable clientsDT;
        private DataTable dt;

        public Quotes()
        {
            InitializeComponent();
        }

        private void Quotes_Load(object sender, EventArgs e)
        {
            clientsDT = new DataTable();
            dgv_Contractors.DataSource = bs;
            LoadClients();
            LoadQuotes();
        }


        //================================================================================================================================================//
        // LOAD CLIENT DETAILS                                                                                                                            //
        //================================================================================================================================================//
        private void LoadClients()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Clients", conn);
                clientsDT = new DataTable();
                da.Fill(clientsDT);
            }

            if (clientsDT.Rows.Count > 0)
            {

                if (!dgv_Contractors.Enabled)
                    dgv_Contractors.Enabled = true;

                if (!btn_C_NewWW.Enabled)
                    btn_C_NewWW.Enabled = true;

                if (!btn_LQ_Filter.Enabled)
                    btn_LQ_Filter.Enabled = true;

                NUM_OF_CLIENTS = clientsDT.Rows.Count - 1;
                txt_LQ_CCode.Text = clientsDT.Rows[CUR_CLIENT]["Code"].ToString().Trim();
                CNAME = clientsDT.Rows[CUR_CLIENT]["Name"].ToString().Trim();
                txt_LQ_CName.Text = CNAME;
            }
            else
            {
                dgv_Contractors.Enabled = false;
                btn_C_NewWW.Enabled = false;
                btn_LQ_Filter.Enabled = false;
            }
        }


        //================================================================================================================================================//
        // LOAD QUOTE DETAILS                                                                                                                             //
        //================================================================================================================================================//
        private void LoadQuotes()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Quotes_Send WHERE Client = '" + CNAME + "'", conn);
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
            LoadQuotes();
        }


        //================================================================================================================================================//
        // NEW QUOTE CLICKED                                                                                                                              //
        //================================================================================================================================================//
        private void Btn_LQ_NewQuote_Click(object sender, EventArgs e)
        {
            if (isFiltered)
                RemoveFilter();

            using (Q_Add frmQA = new Q_Add())
                frmQA.ShowDialog(this);

            LoadQuotes();
        }


        //================================================================================================================================================//
        // GETTERS                                                                                                                                        //
        //================================================================================================================================================//
        public string GetCCode()
        {
            return txt_LQ_CCode.Text;
        }

        public string GetCName()
        {
            return CNAME;
        }

        public int GetSelectedQuote()
        {
            return SELECTED_QUOTE;
        }

        public DataTable GetQuotes()
        {
            return dt;
        }


        //================================================================================================================================================//
        // FILTERS                                                                                                                                        //
        //================================================================================================================================================//
        private void Dgv_LQuotes_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgv_Contractors.FilterString;
        }

        private void Dgv_LQuotes_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgv_Contractors.SortString;
        }

        private void Btn_LQ_Filter_Click(object sender, EventArgs e)
        {
            btn_LQ_Filter.Visible = false;
            btn_LQ_ClearFilter.Visible = true;
            bs.Filter = string.Empty;
            bs.Sort = string.Empty;
            isFiltered = true;

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Quotes_Send WHERE Client = '" + CNAME + "' AND Date_Send BETWEEN '" + dtp_LQ_From.Value + "' AND '" + dtp_LQ_To.Value + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }
            bs.DataSource = dt;
        }

        private void Btn_LQ_ClearFilter_Click(object sender, EventArgs e)
        {
            RemoveFilter();
        }

        private void RemoveFilter()
        {
            LoadQuotes();
            btn_LQ_Filter.Visible = true;
            btn_LQ_ClearFilter.Visible = false;
        }


        //================================================================================================================================================//
        // DATAGRIDVIEW CELL DOUBLECLICK                                                                                                                  //
        //================================================================================================================================================//
        private void Dgv_LQuotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isFiltered)
                RemoveFilter();

            SELECTED_QUOTE = e.RowIndex;

            using (Q_Edit_Del frmQED = new Q_Edit_Del())
                frmQED.ShowDialog(this);

            LoadQuotes();
        }

        //================================================================================================================================================//
        // NEW QUOTE BUTTON                                                                                                                               //
        //================================================================================================================================================//
        private void Btn_LQ_NewQuote_MouseEnter(object sender, EventArgs e)
        {
            btn_C_NewWW.Image = Resources.add_white;
            btn_C_NewWW.ForeColor = Color.White;
        }

        private void Btn_LQ_NewQuote_MouseLeave(object sender, EventArgs e)
        {
            btn_C_NewWW.Image = Resources.add_grey;
            btn_C_NewWW.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // FILTER BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_LQ_Filter_MouseEnter(object sender, EventArgs e)
        {
            btn_LQ_Filter.Image = Resources.filter_white;
            btn_LQ_Filter.ForeColor = Color.White;
        }

        private void Btn_LQ_Filter_MouseLeave(object sender, EventArgs e)
        {
            btn_LQ_Filter.Image = Resources.filter_grey;
            btn_LQ_Filter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLEAR FILTER BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_LQ_ClearFilter_MouseEnter(object sender, EventArgs e)
        {
            btn_LQ_ClearFilter.ForeColor = Color.White;
        }

        private void Btn_LO_ClearFilter_MouseLeave(object sender, EventArgs e)
        {
            btn_LQ_ClearFilter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // ENFORCE READ ONLY                                                                                                                              //
        //================================================================================================================================================//
        private void Txt_LQ_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_LQ_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}

using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;

namespace QTechManagementSoftware
{
    public partial class Int_Quotes : Form
    {
        private BindingSource bs = new BindingSource();
        private bool isFiltered = false;
        private string clientName, clientCode , SELECTED_QUOTE;
        private DataTable dt;

        public Int_Quotes()
        {
            InitializeComponent();
        }


        //================================================================================================================================================//
        // QUOTES FORM LOAD                                                                                                                               //
        //================================================================================================================================================//
        private void Quotes_Load(object sender, EventArgs e)
        {
            dtp_IQ_From.Value = DateTime.Now;
            dtp_IQ_To.Value = DateTime.Now;

            dgv_IQuotes.DataSource = bs;

            LoadQuotes();

            txt_IQ_CCode.Text = clientCode;
            txt_IQ_CName.Text = clientName;
        }


        //================================================================================================================================================//
        // LOAD QUOTE DETAILS                                                                                                                             //
        //================================================================================================================================================//
        private void LoadQuotes()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Quotes_Send WHERE Client = '" + clientName + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }

            bs.DataSource = dt;
        }

        public void SetClient(string selectedClientCode, string selectedClientName)
        {
            clientCode = selectedClientCode;
            clientName = selectedClientName;
        }


        //================================================================================================================================================//
        // ADD NEW ORDER                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_IQ_NewQuote_Click(object sender, EventArgs e)
        {
            if (isFiltered)
                RemoveFilter();

            using (Q_Add frmQAdd = new Q_Add())
            {
                frmQAdd.Owner = this;
                frmQAdd.ShowDialog();
            }

            LoadQuotes();
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

        public string GetSelectedQuote()
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
        private void Dgv_IQuotes_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgv_IQuotes.FilterString;
        }

        private void Dgv_IQuotes_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgv_IQuotes.SortString;
        }

        private void Btn_IQ_Filter_Click(object sender, EventArgs e)
        {
            bs.Filter = string.Empty;
            bs.Sort = string.Empty;

            isFiltered = true;

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Quotes_Send WHERE Client = '" + clientName + "' AND Date_Send BETWEEN '" + dtp_IQ_From.Value + "' AND '" + dtp_IQ_To.Value + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }

            bs.DataSource = dt;
            btn_IQ_Filter.Visible = false;
            btn_IQ_ClearFilter.Visible = true;
        }

        private void Btn_IQ_ClearFilter_Click(object sender, EventArgs e)
        {
            RemoveFilter();
        }

        private void RemoveFilter()
        {
            LoadQuotes();
            btn_IQ_Filter.Visible = true;
            btn_IQ_ClearFilter.Visible = false;
        }


        //================================================================================================================================================//
        // EDIT/DELETE ORDER                                                                                                                              //
        //================================================================================================================================================//
        private void Dgv_IQuotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SELECTED_QUOTE = dgv_IQuotes[0, e.RowIndex].Value.ToString(); ;

            using (Q_Edit_Del frmQED = new Q_Edit_Del())
            {
                frmQED.Owner = this;
                frmQED.ShowDialog();
            }                

            LoadQuotes();
        }

        //================================================================================================================================================//
        // NEW QUOTE BUTTON                                                                                                                              //
        //================================================================================================================================================//
        private void Btn_IQ_NewQuote_MouseEnter(object sender, EventArgs e)
        {
            btn_IQ_NewQuote.Image = Resources.add_white;
            btn_IQ_NewQuote.ForeColor = Color.White;
        }

        private void Btn_IQ_NewQuote_MouseLeave(object sender, EventArgs e)
        {
            btn_IQ_NewQuote.Image = Resources.add_grey;
            btn_IQ_NewQuote.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // FILTER BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_IQ_Filter_MouseEnter(object sender, EventArgs e)
        {
            btn_IQ_Filter.Image = Resources.filter_white;
            btn_IQ_Filter.ForeColor = Color.White;
        }

        private void Btn_IQ_Filter_MouseLeave(object sender, EventArgs e)
        {
            btn_IQ_Filter.Image = Resources.filter_grey;
            btn_IQ_Filter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLEAR FILTER                                                                                                                              //
        //================================================================================================================================================//
        private void Btn_IQ_ClearFilter_MouseEnter(object sender, EventArgs e)
        {
            btn_IQ_ClearFilter.ForeColor = Color.White;
        }

        private void Btn_IO_ClearFilter_MouseLeave(object sender, EventArgs e)
        {
            btn_IQ_ClearFilter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // ENFORCE READ ONLY                                                                                                                             //
        //================================================================================================================================================//
        private void Txt_IQ_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_IQ_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}

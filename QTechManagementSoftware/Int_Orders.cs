using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;


namespace QTechManagementSoftware
{
    public partial class Int_Orders : Form
    {
        private BindingSource bs = new BindingSource();
        private bool isFiltered = false;
        private int SELECTED_ORDER;
        private string clientName, clientCode;
        private DataTable dt;

        public Int_Orders()
        {
            InitializeComponent();
        }


        //================================================================================================================================================//
        // ORDERS FORM LOAD                                                                                                                               //
        //================================================================================================================================================//
        private void Orders_Load(object sender, EventArgs e)
        {
            dtp_IO_From.Value = DateTime.Now;
            dtp_IO_To.Value = DateTime.Now;

            dgv_IOrders.DataSource = bs;

            LoadOrders();

            dgv_IOrders.Columns[4].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dgv_IOrders.Columns[4].DefaultCellStyle.Format = "c";
            dgv_IOrders.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_IOrders.Columns[5].DefaultCellStyle.Format = "p0";
            dgv_IOrders.Columns[6].DefaultCellStyle.Format = "p0";

            txt_IO_CCode.Text = clientCode;
            txt_IO_CName.Text = clientName;
        }


        //================================================================================================================================================//
        // LOAD ORDER DETAILS                                                                                                                             //
        //================================================================================================================================================//
        private void LoadOrders()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Orders_Received WHERE Client = '" + clientName + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }

            bs.DataSource = dt;
        }


        //================================================================================================================================================//
        // ADD NEW ORDER                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_IO_NewOrder_Click(object sender, EventArgs e)
        {
            if (isFiltered)
                RemoveFilter();

            using (O_Add frmOAdd = new O_Add())
            {
                frmOAdd.Owner = this;
                frmOAdd.ShowDialog();
            }

            LoadOrders();
        }


        //================================================================================================================================================//
        // GETTERS & SETTERS                                                                                                                              //
        //================================================================================================================================================//
        public string GetClientCode() { return clientCode; }

        public string GetClientName() { return clientName; }

        public int GetSelectedOrder() { return SELECTED_ORDER; }

        public DataTable GetOrders() { return dt; }

        public void SetClient(string seelectedClientCode, string selectedClientName)
        {
            clientCode = seelectedClientCode;
            clientName = selectedClientName;
        }


        //================================================================================================================================================//
        // FILTERS                                                                                                                                        //
        //================================================================================================================================================//
        private void Dgv_IOrders_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgv_IOrders.FilterString;
        }

        private void Dgv_IOrders_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgv_IOrders.SortString;
        }

        private void Btn_IO_Filter_Click(object sender, EventArgs e)
        {
            bs.Filter = string.Empty;
            bs.Sort = string.Empty;

            isFiltered = true;

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Orders_Received WHERE Client = '" + clientName + "' AND Date BETWEEN '" + dtp_IO_From.Value + "' AND '" + dtp_IO_To.Value + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }

            bs.DataSource = dt;
            btn_IO_Filter.Visible = false;
            btn_IO_ClearFilter.Visible = true;
        }

        private void Btn_IO_ClearFilter_Click(object sender, EventArgs e)
        {
            RemoveFilter();
        }

        private void RemoveFilter()
        {
            LoadOrders();
            btn_IO_Filter.Visible = true;
            btn_IO_ClearFilter.Visible = false;
        }


        //================================================================================================================================================//
        // ADD NEW ORDER                                                                                                                                  //
        //================================================================================================================================================//
        private void Dgv_IOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isFiltered)
                RemoveFilter();

            SELECTED_ORDER = e.RowIndex;

            using (O_Edit_Del frmOED = new O_Edit_Del())
            {
                frmOED.Owner = this;
                frmOED.ShowDialog();
            }

            LoadOrders();
        }

        //================================================================================================================================================//
        // NEW ORDER BUTTON                                                                                                                               //
        //================================================================================================================================================//
        private void Btn_IO_NewOrder_MouseEnter(object sender, EventArgs e)
        {
            btn_IO_NewOrder.Image = Resources.add_white;
            btn_IO_NewOrder.ForeColor = Color.White;
        }

        private void Btn_IO_NewOrder_MouseLeave(object sender, EventArgs e)
        {
            btn_IO_NewOrder.Image = Resources.add_grey;
            btn_IO_NewOrder.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // FILTER BUTTON                                                                                                                                        //
        //================================================================================================================================================//
        private void Btn_IO_Filter_MouseEnter(object sender, EventArgs e)
        {
            btn_IO_Filter.Image = Resources.filter_white;
            btn_IO_Filter.ForeColor = Color.White;
        }

        private void Btn_IO_Filter_MouseLeave(object sender, EventArgs e)
        {
            btn_IO_Filter.Image = Resources.filter_grey;
            btn_IO_Filter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLEAR FILTER BUTTON                                                                                                                                       //
        //================================================================================================================================================//
        private void Btn_IO_ClearFilter_MouseEnter(object sender, EventArgs e)
        {
            btn_IO_ClearFilter.ForeColor = Color.White;
        }

        private void Btn_IO_ClearFilter_MouseLeave(object sender, EventArgs e)
        {
            btn_IO_ClearFilter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // ENFORCE READ ONLY                                                                                                                                        //
        //================================================================================================================================================//
        private void Txt_IO_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_IO_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace QTechManagementSoftware
{
    public partial class NoInvoices : Form
    {
        BindingSource bs = new BindingSource();

        public NoInvoices()
        {
            InitializeComponent();
        }

        private void NoInvoices_Load(object sender, EventArgs e)
        {
            dgv_NoInv.DataSource = bs;

            LoadNoInvoices();

            dgv_NoInv.Columns[4].DefaultCellStyle.FormatProvider = (IFormatProvider)CultureInfo.GetCultureInfo("en-US");
            dgv_NoInv.Columns[4].DefaultCellStyle.Format = "c";
            dgv_NoInv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_NoInv.Columns[5].DefaultCellStyle.FormatProvider = (IFormatProvider)CultureInfo.GetCultureInfo("en-US");
            dgv_NoInv.Columns[5].DefaultCellStyle.Format = "c";
            dgv_NoInv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_NoInv.Columns[6].DefaultCellStyle.Format = "c";
            dgv_NoInv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_NoInv.Columns[7].DefaultCellStyle.Format = "c";
            dgv_NoInv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_NoInv.Columns[8].DefaultCellStyle.Format = "c";
            dgv_NoInv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_NoInv.Columns[9].DefaultCellStyle.Format = "c";
            dgv_NoInv.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadNoInvoices()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                da = new SqlDataAdapter("SELECT * FROM Contractor_Hours WHERE Invoice_Received = 'No'", conn);
                da.Fill(dt);
            }

            bs.DataSource = dt;
        }
    }
}

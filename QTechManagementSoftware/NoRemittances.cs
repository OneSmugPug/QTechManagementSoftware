using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTechManagementSoftware
{
    public partial class NoRemittances : Form
    {
        BindingSource bs = new BindingSource();

        public NoRemittances()
        {
            InitializeComponent();
        }

        private void NoRemittances_Load(object sender, EventArgs e)
        {
            dgv_NoRem.DataSource = bs;
            LoadNoRemittances();

            dgv_NoRem.Columns[4].DefaultCellStyle.FormatProvider = (IFormatProvider)CultureInfo.GetCultureInfo("en-US");
            dgv_NoRem.Columns[4].DefaultCellStyle.Format = "c";
            dgv_NoRem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_NoRem.Columns[5].DefaultCellStyle.FormatProvider = (IFormatProvider)CultureInfo.GetCultureInfo("en-US");
            dgv_NoRem.Columns[5].DefaultCellStyle.Format = "c";
            dgv_NoRem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_NoRem.Columns[6].DefaultCellStyle.Format = "c";
            dgv_NoRem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_NoRem.Columns[7].DefaultCellStyle.Format = "c";
            dgv_NoRem.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_NoRem.Columns[8].DefaultCellStyle.Format = "c";
            dgv_NoRem.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_NoRem.Columns[9].DefaultCellStyle.Format = "c";
            dgv_NoRem.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadNoRemittances()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                da = new SqlDataAdapter("SELECT * FROM Contractor_Hours WHERE Remittance = 'No'", conn);
                da.Fill(dt);
            }

            bs.DataSource = dt;
        }
    }
}

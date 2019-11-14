using QTechManagementSoftware.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data;

namespace QTechManagementSoftware
{
    public partial class PettyCash : Form
    {
        private Decimal subtotal = 0.00m;

        public PettyCash()
        {
            InitializeComponent();
        }

        //================================================================================================================================================//
        // PETTYCASH FORM LOAD                                                                                                                            //
        //================================================================================================================================================//
        private void PettyCash_Load(object sender, EventArgs e)
        {
            txt_PC_Tot.Text = 0.00m.ToString("c2");

            dgv_PettyCash.Columns[0].ValueType = Type.GetType("System.DateTime");
            dgv_PettyCash.Columns[0].DefaultCellStyle.Format = "d";

            dgv_PettyCash.Columns[3].ValueType = Type.GetType("System.Decimal");
            dgv_PettyCash.Columns[3].DefaultCellStyle.Format = "c2";

            dgv_PettyCash.Columns[4].ValueType = Type.GetType("System.Decimal");
            dgv_PettyCash.Columns[4].DefaultCellStyle.Format = "c2";

            dgv_PettyCash.Columns[5].ValueType = Type.GetType("System.Decimal");
            dgv_PettyCash.Columns[5].DefaultCellStyle.Format = "c2";

            DataGridViewRow row = dgv_PettyCash.Rows[0];
            row.Cells[5].Value = 0.00m;
        }


        //================================================================================================================================================//
        // EXPORT CLICKED                                                                                                                                 //
        //================================================================================================================================================//
        private void Btn_PC_Export_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dgv_PettyCash.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            for (int i = 0; i < dgv_PettyCash.RowCount - 1; i++)
            {
                DataGridViewRow row = dgv_PettyCash.Rows[i];

                dt.Rows.Add();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    else dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = string.Empty;
                }
            }

            string path = "c:\\Petty Cash";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = string.Format("PettyCash_{0}.xlsx", string.Format("{0:yyMMMdd_hh-mm}", DateTime.Now));
            path = Path.Combine(path, fileName);

            XLWorkbook wb = new XLWorkbook();

            try
            {
                wb.Worksheets.Add(dt, fileName);
                wb.SaveAs(path);

                MessageBox.Show("Data successfully exported to " + path, "Export Complete", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //================================================================================================================================================//
        // NEW ROW ENTERED                                                                                                                                //
        //================================================================================================================================================//
        private void Dgv_PettyCash_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgv_PettyCash.Rows[e.RowIndex];

                if (row.Cells[3].Value == null)
                    row.Cells[3].Value = 0.00m;

                if (row.Cells[4].Value == null)
                    row.Cells[4].Value = 0.00m;
            }
        }


        //================================================================================================================================================//
        // EXPORT BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_PC_Export_MouseEnter(object sender, EventArgs e)
        {
            btn_PC_Export.Image = Resources.export_white;
            btn_PC_Export.ForeColor = Color.White;
        }

        private void Btn_PC_Export_MouseLeave(object sender, EventArgs e)
        {
            btn_PC_Export.Image = Resources.export_grey;
            btn_PC_Export.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void dgv_PettyCash_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal runTotal = 0.00m;

            if (e.RowIndex >= 0)
            {
                for (int i = 0; i < dgv_PettyCash.RowCount - 1; i++)
                {
                    if (i == 0)
                    {
                        DataGridViewRow row = dgv_PettyCash.Rows[i];

                        if (row.Cells[3].Value != null && row.Cells[4].Value != null)
                        {
                            decimal credit = Decimal.Parse(row.Cells[3].Value.ToString());
                            decimal debit = Decimal.Parse(row.Cells[4].Value.ToString());

                            runTotal = (runTotal + credit) - debit;

                            row.Cells[5].Value = runTotal;
                        }
                    }
                    else if (i > 0)
                    {
                        DataGridViewRow row = dgv_PettyCash.Rows[i];
                        DataGridViewRow prevRow;

                        prevRow = dgv_PettyCash.Rows[i - 1];

                        decimal credit = Decimal.Parse(row.Cells[3].Value.ToString());
                        decimal debit = Decimal.Parse(row.Cells[4].Value.ToString());
                        runTotal = Decimal.Parse(prevRow.Cells[5].Value.ToString());

                        runTotal = (runTotal + credit) - debit;

                        row.Cells[5].Value = runTotal;
                    }
                }
            }

            txt_PC_Tot.Text = runTotal.ToString("C2");
        }
    }
}

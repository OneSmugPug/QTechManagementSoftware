using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;

namespace QTechManagementSoftware
{
    public partial class Inv_Send_Add : Form
    {
        #region Variables
        private DataTable dt = new DataTable();
        private bool mouseDown = false;
        private Invoices_Send parent = null;
        private Int_Invoices_Send intParent = null;
        private Point lastLocation;
        private NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
        #endregion

        #region Initialize Form
        public Inv_Send_Add()
        {
            InitializeComponent();

            nfi.NumberGroupSeparator = " ";
        }
        #endregion

        #region Load Form
        private void Inv_Send_Add_Load(object sender, EventArgs e)
        {
            if (this.Owner.GetType() == typeof(Invoices_Send))
            {
                parent = (Invoices_Send)this.Owner;

                txt_ISA_CCode.Text = parent.GetClientCode();
                txt_ISA_CName.Text = parent.GetClientName();

                dt = parent.GetInvoices();
            }
            else
            {
                intParent = (Int_Invoices_Send)this.Owner;

                txt_ISA_CCode.Text = intParent.GetClientCode();
                txt_ISA_CName.Text = intParent.GetClientName();

                dt = intParent.GetInvoices();
            }

            int newInvNum = 0;
            foreach (DataRow row in (InternalDataCollectionBase)dt.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                {
                    string curInvNum = row["Invoice_Number", DataRowVersion.Original].ToString().Trim();

                    if (!curInvNum.Contains("."))
                    {
                        int pos = curInvNum.IndexOf("_");
                        int int32 = Convert.ToInt32(curInvNum.Remove(0, pos + 2));
                        if (int32 > newInvNum)
                            newInvNum = int32;
                    }
                    else
                    {
                        int pos = curInvNum.IndexOf("_");
                        curInvNum = curInvNum.Remove(0, pos + 2);

                        pos = curInvNum.IndexOf(".");
                        int int32 = Convert.ToInt32(curInvNum.Remove(pos, curInvNum.Length - 3));
                        if (int32 > newInvNum)
                            newInvNum = int32;
                    }
                }
                else
                {
                    string curInvNum = row["Invoice_Number"].ToString().Trim();

                    if (!curInvNum.Contains("."))
                    {
                        int pos = curInvNum.IndexOf("_");
                        int int32 = Convert.ToInt32(curInvNum.Remove(0, pos + 2));
                        if (int32 > newInvNum)
                            newInvNum = int32;
                    }
                    else
                    {
                        int pos = curInvNum.IndexOf("_");
                        curInvNum = curInvNum.Remove(0, pos + 2);

                        pos = curInvNum.IndexOf(".");
                        int int32 = Convert.ToInt32(curInvNum.Remove(pos, curInvNum.Length - 3));
                        if (int32 > newInvNum)
                            newInvNum = int32;
                    }
                }
            }

            txt_ISA_InvNum.Text = txt_ISA_CCode.Text + "_I" + (newInvNum + 1).ToString("000");


            txt_ISA_Amt.Text = "0.00";
            txt_ISA_Amt.SelectionStart = txt_ISA_Amt.Text.Length;

            txt_ISA_VAT.Text = ddb_InvSendCur.selectedValue + " " + "0.00";
            txt_ISA_VAT.SelectionStart = txt_ISA_VAT.Text.Length;

            dtp_ISA_Date.Value = DateTime.Now;
            dtp_ISA_DatePaid.Value = DateTime.Now;
        }
        #endregion

        #region Amount Value Change
        private void Txt_ISA_Amt_TextChanged(object sender, EventArgs e)
        {
            if (Decimal.TryParse(txt_ISA_Amt.Text.Replace(",", string.Empty).Replace(".", string.Empty).TrimStart('0'), out decimal ul))
            {
                ul /= 100;

                txt_ISA_Amt.TextChanged -= Txt_ISA_Amt_TextChanged;

                txt_ISA_Amt.Text = ul.ToString("N2", nfi);
                txt_ISA_Amt.TextChanged += Txt_ISA_Amt_TextChanged;
                txt_ISA_Amt.Select(txt_ISA_Amt.Text.Length, 0);

                if (ddb_InvSendCur.selectedValue.Equals("R"))
                {
                    decimal temp = decimal.Round(0.15m * ul, 2);
                    txt_ISA_VAT.Text = ddb_InvSendCur.selectedValue + " " + temp.ToString("N2", nfi);
                }
                else
                {
                    if (!txt_ISA_VAT.Text.Remove(0, 1).Trim().Equals("0.00"))
                        txt_ISA_VAT.Text = ddb_InvSendCur.selectedValue + " " + 0.00m;
                }
            }
        }

        private void txt_ISA_Amt_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) && !(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) && !(e.KeyCode == Keys.Back))
                e.SuppressKeyPress = true;
        }
        #endregion

        #region Done Clicked
        private void Btn_ISA_Done_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add invoice with Invoice Number: " + txt_ISA_InvNum.Text + "?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    conn.Open();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Invoices_Send VALUES (@Date, @InvNum, @Client, @Desc, @Amt, @VAT, @Paid, @DatePaid)", conn))
                        {
                            cmd.Parameters.AddWithValue("@Date", dtp_ISA_Date.Value);
                            cmd.Parameters.AddWithValue("@InvNum", txt_ISA_InvNum.Text.Trim());
                            cmd.Parameters.AddWithValue("@Client", txt_ISA_CName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Desc", txt_ISA_Desc.Text.Trim());
                            cmd.Parameters.AddWithValue("@Amt", ddb_InvSendCur.selectedValue + " " + txt_ISA_Amt.Text);
                            cmd.Parameters.AddWithValue("@VAT", txt_ISA_VAT.Text);

                            if (cb_ISA_Paid.Checked)
                            {
                                cmd.Parameters.AddWithValue("@Paid", "Yes");
                                cmd.Parameters.AddWithValue("@DatePaid", dtp_ISA_DatePaid.Value);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Paid", "No");
                                cmd.Parameters.AddWithValue("@DatePaid", DBNull.Value);
                            }

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("New invoice successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Cancel Clicked
        private void Btn_ISA_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Close Clicked
        //================================================================================================================================================//
        // CLOSE CLICKED                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_ISA_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Controls Effects
        //================================================================================================================================================//
        // INVOICE NUMBER                                                                                                                                 //
        //================================================================================================================================================//
        private void Txt_ISA_InvNum_MouseEnter(object sender, EventArgs e)
        {
            ln_ISA_InvNum.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_ISA_InvNum_Leave(object sender, EventArgs e)
        {
            ln_ISA_InvNum.LineColor = Color.Gray;
        }

        private void Txt_ISA_InvNum_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_ISA_InvNum.Focused)
                ln_ISA_InvNum.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // INVOICE NUMBER INSTANCE                                                                                                                        //
        //================================================================================================================================================//
        private void Txt_ISA_INInst_MouseEnter(object sender, EventArgs e)
        {
            ln_ISA_INInst.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_ISA_INInst_Leave(object sender, EventArgs e)
        {
            ln_ISA_INInst.LineColor = Color.Gray;
        }

        private void Txt_ISA_INInst_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_ISA_INInst.Focused)
                ln_ISA_INInst.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // DESCRIPTION                                                                                                                                    //
        //================================================================================================================================================//
        private void Txt_ISA_Desc_Leave(object sender, EventArgs e)
        {
            ln_ISA_Desc.LineColor = Color.Gray;
        }

        private void Txt_ISA_Desc_MouseEnter(object sender, EventArgs e)
        {
            ln_ISA_Desc.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_ISA_Desc_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_ISA_Desc.Focused)
                ln_ISA_Desc.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // AMOUNT                                                                                                                                         //
        //================================================================================================================================================//
        private void Txt_ISA_Amt_MouseEnter(object sender, EventArgs e)
        {
            ln_ISA_Amt.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_ISA_Amt_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_ISA_Amt.Focused)
                ln_ISA_Amt.LineColor = Color.Gray;
        }

        private void Txt_ISA_Amt_Leave(object sender, EventArgs e)
        {
            ln_ISA_Amt.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // VAT                                                                                                                                            //
        //================================================================================================================================================//
        private void Txt_ISA_VAT_Leave(object sender, EventArgs e)
        {
            ln_ISA_VAT.LineColor = Color.Gray;
        }

        private void Txt_ISA_VAT_MouseEnter(object sender, EventArgs e)
        {
            ln_ISA_VAT.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_ISA_VAT_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_ISA_VAT.Focused)
                ln_ISA_VAT.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // CLOSE BUTTON                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_ISA_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_ISA_Close.Image = (Image)Resources.close_white;
        }

        private void Btn_ISA_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_ISA_Close.Image = (Image)Resources.close_black;
        }


        //================================================================================================================================================//
        // DONE BUTTON                                                                                                                                    //
        //================================================================================================================================================//
        private void Btn_ISA_Done_MouseEnter(object sender, EventArgs e)
        {
            btn_ISA_Done.ForeColor = Color.White;
        }

        private void Btn_ISA_Done_MouseLeave(object sender, EventArgs e)
        {
            btn_ISA_Done.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CANCEL BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_ISA_Cancel_MouseEnter(object sender, EventArgs e)
        {
            btn_ISA_Cancel.ForeColor = Color.White;
        }

        private void Btn_ISA_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_ISA_Cancel.ForeColor = Color.FromArgb(64, 64, 64);
        }
        #endregion

        #region ReadOnly Controls
        //================================================================================================================================================//
        // ENFORCE READONLY                                                                                                                               //
        //================================================================================================================================================//
        private void Txt_ISA_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_ISA_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        #endregion

        #region Form Movement
        //================================================================================================================================================//
        // INVOICES SENT ADD                                                                                                                              //
        //================================================================================================================================================//
        private void Inv_Send_Add_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Inv_Send_Add_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void Inv_Sent_Add_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion

        #region Checkbox Checked/Unchecked
        //================================================================================================================================================//
        // PAID CHECKBOX CHANGE                                                                                                                           //
        //================================================================================================================================================//
        private void Bb_ISA_Paid_OnChange(object sender, EventArgs e)
        {
            if (cb_ISA_Paid.Checked)
                dtp_ISA_DatePaid.Enabled = true;
            else
                dtp_ISA_DatePaid.Enabled = false;
        }
        #endregion

        #region Currency Symbol Change
        //================================================================================================================================================//
        // CURRENCY SYMBOL CHANGED                                                                                                                        //
        //================================================================================================================================================//
        private void ddb_InvSendCur_onItemSelected(object sender, EventArgs e)
        {
            if (!txt_ISA_VAT.Text.Equals(string.Empty))
            {
                if (ddb_InvSendCur.selectedValue.Equals("R"))
                {

                    if (Decimal.TryParse(txt_ISA_Amt.Text.Replace(",", string.Empty).Replace(".", string.Empty).TrimStart('0'), out decimal ul))
                    {
                        ul /= 100;

                        decimal vat = decimal.Round(0.15m * ul, 2);
                        txt_ISA_VAT.Text = ddb_InvSendCur.selectedValue + " " + vat.ToString("N2", nfi);
                    }
                }
                else
                {
                    txt_ISA_VAT.Text = ddb_InvSendCur.selectedValue + " " + 0.00m;
                }
            }
        }
        #endregion
    }
}

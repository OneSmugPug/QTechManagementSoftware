using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;
using System.Globalization;

namespace QTechManagementSoftware
{
    public partial class New_Expense : Form
    {
        private string Proj_ID;
        private bool mouseDown;
        private Point lastLocation;
        private Proj_AddExp parent;
        private NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();

        public New_Expense()
        {
            InitializeComponent();

            nfi.NumberGroupSeparator = " ";
        }


        //================================================================================================================================================//
        // SET PARENT FORM                                                                                                                                //
        //================================================================================================================================================//
        public void SetParent(Proj_AddExp parent)
        {
            this.parent = parent;
        }


        //================================================================================================================================================//
        // NEW EXPENSE FORM LOAD                                                                                                                          //
        //================================================================================================================================================//
        private void New_Expense_Load(object sender, EventArgs e)
        {
            Proj_ID = parent.GetProjectID();

            txt_NE_Tot.Text = "0.00";
        }


        //================================================================================================================================================//
        // DONE CLICKED                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_NE_Done_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(new StringBuilder().Append("Are you sure you want to add new expenses?").ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Project_Expenses VALUES (@ProjID, @Date, @Merc, @Desc, @TotPrice, @Hrs)", conn))
                        {
                            cmd.Parameters.AddWithValue("@ProjID", Proj_ID);
                            cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Merc", txt_NE_Merc.Text.Trim());
                            cmd.Parameters.AddWithValue("@Desc", ddb_NE_Desc.selectedValue);
                            cmd.Parameters.AddWithValue("@TotPrice", ddb_Cur.selectedValue + " " + txt_NE_Tot.Text.Trim());
                            
                            if (!txt_NE_Hours.Text.Equals(string.Empty))
                                cmd.Parameters.AddWithValue("@Hrs", Decimal.Parse(txt_NE_Hours.Text.Trim()));
                            else cmd.Parameters.AddWithValue("@Hrs", DBNull.Value);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("New line successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            

        //================================================================================================================================================//
        // CANCEL CLICKED                                                                                                                                 //
        //================================================================================================================================================//
        private void Btn_NE_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //================================================================================================================================================//
        // DESCRIPTION                                                                                                                                    //
        //================================================================================================================================================//
        private void txt_NE_Merc_MouseEnter(object sender, EventArgs e)
        {
            ln_NE_Merc.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void txt_NE_Merc_Leave(object sender, EventArgs e)
        {
            ln_NE_Merc.LineColor = Color.Gray;
        }

        private void txt_NE_Merc_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_NE_Merc.Focused)
                ln_NE_Merc.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // VALUE                                                                                                                                          //
        //================================================================================================================================================//
        private void txt_NE_Tot_MouseEnter(object sender, EventArgs e)
        {
            ln_NE_Tot.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void txt_NE_Tot_Leave(object sender, EventArgs e)
        {
            ln_NE_Tot.LineColor = Color.Gray;
        }

        private void txt_NE_Tot_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_NE_Tot.Focused)
                ln_NE_Tot.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // USER                                                                                                                                           //
        //================================================================================================================================================//
        private void txt_NE_Hours_MouseEnter(object sender, EventArgs e)
        {
            ln_NE_Hours.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void txt_NE_Hours_Leave(object sender, EventArgs e)
        {
            ln_NE_Hours.LineColor = Color.Gray;
        }

        private void txt_NE_Hours_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_NE_Hours.Focused)
                ln_NE_Hours.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // CLOSE CLICKED                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_NE_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //================================================================================================================================================//
        // CLOSE BUTTON                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_NE_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_NE_Close.Image = Resources.close_white;
        }

        private void Btn_NE_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_NE_Close.Image = Resources.close_black;
        }


        //================================================================================================================================================//
        // DONE BUTTON                                                                                                                                    //
        //================================================================================================================================================//
        private void Btn_NE_Done_MouseEnter(object sender, EventArgs e)
        {
            btn_NE_Done.ForeColor = Color.White;
        }

        private void Btn_NE_Done_MouseLeave(object sender, EventArgs e)
        {
            btn_NE_Done.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CANCEL BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_NE_Cancel_MouseEnter(object sender, EventArgs e)
        {
            btn_NE_Cancel.ForeColor = Color.White;
        }

        private void Btn_NE_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_NE_Cancel.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // NEW EXPENSE                                                                                                                                    //
        //================================================================================================================================================//
        private void New_Expense_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void New_Expense_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void New_Expense_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void txt_NE_Tot_TextChanged(object sender, EventArgs e)
        {
            if (Decimal.TryParse(txt_NE_Tot.Text.Replace(",", string.Empty).Replace(".", string.Empty).TrimStart('0'), out decimal ul))
            {
                ul /= 100;

                txt_NE_Tot.TextChanged -= txt_NE_Tot_TextChanged;

                txt_NE_Tot.Text = ul.ToString("N2", nfi);
                txt_NE_Tot.TextChanged += txt_NE_Tot_TextChanged;
                txt_NE_Tot.Select(txt_NE_Tot.Text.Length, 0);

                decimal temp = decimal.Round(0.15m * ul, 2);
            }
        }

        private void txt_NE_Tot_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) && !(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) && !(e.KeyCode == Keys.Back))
                e.SuppressKeyPress = true;
        }
    }
}

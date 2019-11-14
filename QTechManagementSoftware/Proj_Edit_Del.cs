using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace QTechManagementSoftware
{
    public partial class Proj_Edit_Del : Form
    {
        private bool mouseDown = false;
        private DataTable dt;
        private string SELECTED_PROJECT;
        private Point lastLocation;

        public Proj_Edit_Del()
        {
            InitializeComponent();
        }

        private void Proj_Edit_Del_Load(object sender, EventArgs e)
        {
            Projects curForm = (Projects)this.Owner;
            dt = curForm.GetProjects();
            SELECTED_PROJECT = curForm.GetSelectedProj();
            LoadProject();
        }


        //================================================================================================================================================//
        // PROJECT DETAILS LOAD                                                                                                                           //
        //================================================================================================================================================//
        private void LoadProject()
        {
            int rowIdx = 0;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Project_ID"].ToString().Equals(SELECTED_PROJECT))
                    rowIdx = dt.Rows.IndexOf(dr);
            }

            txt_PED_CCode.Text = dt.Rows[rowIdx]["Client_Code"].ToString().Trim();
            txt_PED_CName.Text = dt.Rows[rowIdx]["Client_Name"].ToString().Trim();
            txt_PED_ProjCode.Text = dt.Rows[rowIdx]["Project_ID"].ToString().Trim();

            dtp_PED_Date.Value = (dt.Rows[rowIdx]["Date"].ToString() == string.Empty) ? DateTime.Now : Convert.ToDateTime(dt.Rows[rowIdx]["Date"].ToString());

            txt_PED_Desc.Text = dt.Rows[rowIdx]["Description"].ToString().Trim();
            txt_PED_QNum.Text = dt.Rows[rowIdx]["Quote_Number"].ToString().Trim();
        }


        //================================================================================================================================================//
        // DONE CLICKED                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_PED_Done_Click(object sender, EventArgs e)
        {
            string projCode = txt_PED_ProjCode.Text;

            if (MessageBox.Show("Are you sure you want to update project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE Projects SET Date = @Date, Description = @Desc WHERE Project_ID = @ProjID", conn))
                        {
                            cmd.Parameters.AddWithValue("@Date", dtp_PED_Date.Value);
                            cmd.Parameters.AddWithValue("@Desc", txt_PED_Desc.Text.Trim());
                            cmd.Parameters.AddWithValue("@ProjID", projCode);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Project successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void Btn_PED_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //================================================================================================================================================//
        // PROJECT CODE                                                                                                                                   //
        //================================================================================================================================================//
        private void Txt_PED_ProjCode_MouseEnter(object sender, EventArgs e)
        {
            ln_PED_ProjCode.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_PED_ProjCode_Leave(object sender, EventArgs e)
        {
            ln_PED_ProjCode.LineColor = Color.Gray;
        }

        private void Txt_PED_ProjCode_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_PED_ProjCode.Focused)
                ln_PED_ProjCode.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // DESCRIPTION                                                                                                                                    //
        //================================================================================================================================================//
        private void Txt_PED_Desc_Leave(object sender, EventArgs e)
        {
            ln_PED_Desc.LineColor = Color.Gray;
        }

        private void Txt_PED_Desc_MouseEnter(object sender, EventArgs e)
        {
            ln_PED_Desc.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_PED_Desc_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_PED_Desc.Focused)
                ln_PED_Desc.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // QUOTE NUMBER                                                                                                                                   //
        //================================================================================================================================================//
        private void Txt_PED_QNum_Leave(object sender, EventArgs e)
        {
            ln_PED_QNum.LineColor = Color.Gray;
        }

        private void Txt_PED_QNum_MouseEnter(object sender, EventArgs e)
        {
            ln_PED_QNum.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_PED_QNum_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_PED_QNum.Focused)
                ln_PED_QNum.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // CLOSE CLICKED                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_PED_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //================================================================================================================================================//
        // CLOSE BUTTON                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_PED_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_PED_Close.Image = Resources.close_white;
        }

        private void Btn_PED_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_PED_Close.Image = Resources.close_black;
        }


        //================================================================================================================================================//
        // DONE BUTTON                                                                                                                                    //
        //================================================================================================================================================//
        private void Btn_PED_Done_MouseEnter(object sender, EventArgs e)
        {
            btn_PED_Done.ForeColor = Color.White;
        }

        private void Btn_PED_Done_MouseLeave(object sender, EventArgs e)
        {
            btn_PED_Done.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CANCEL BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_PED_Cancel_MouseEnter(object sender, EventArgs e)
        {
            btn_PED_Cancel.ForeColor = Color.White;
        }

        private void Btn_PED_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_PED_Cancel.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // ENFORCE READONLY                                                                                                                               //
        //================================================================================================================================================//
        private void Ddb_PED_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_PED_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }


        //================================================================================================================================================//
        // PROJECT EDIT DELETE                                                                                                                            //
        //================================================================================================================================================//
        private void Proj_Edit_Del_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Proj_Edit_Del_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void Proj_Edit_Del_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        //================================================================================================================================================//
        // CREATE PROJECT FOLDERS BUTTON                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_PED_CreateProjFolder_Click(object sender, EventArgs e)
        {
            bool matchFound = false;
            //string Dpath = @"c:\Projects";
            string Dpath = @"\\192.168.8.121\Projects";

            //---------------------------------------------------------------------------------------------------
            NetworkCredential theNetworkCredential = new NetworkCredential("administrator", "P@$$w0rd", "WORKGROUP");
            CredentialCache theNetcache = new CredentialCache();
            theNetcache.Add(new Uri(@"\\192.168.8.121\Projects"), "Basic", theNetworkCredential);

            if (!Directory.Exists(Dpath))
            {
                Directory.CreateDirectory(Dpath);
                Console.WriteLine("Successfully found the directory");
            }
            //---------------------------------------------------------------------------------------------------

            // Populates a data table with folder names and checks if a folder with the current project code exists and updates matchedFound
            DirectoryInfo di = new DirectoryInfo(Dpath);
            DirectoryInfo[] diArr = di.GetDirectories();
            foreach (DirectoryInfo dri in diArr)
            {
                if (dri.Name.Equals(txt_PED_ProjCode.Text)) // Check for exstra conditions **
                {
                    matchFound = true;
                }
            }


            // If a match is not found, create a new folder with a new file name of the form [4-digit code]_[project code]_[project desc]
            if (!matchFound)
            {
                // Obtains the last entry to generate a new 4-digit code prefix folder name
                int FCode = 0;
                foreach (DirectoryInfo dri in diArr)
                {
                    string[] strArray = dri.Name.Trim().Split('_');

                    int x = Convert.ToInt32(strArray[0]);

                    if (x > FCode)
                        FCode = x;
                }

                // Creates the new directory
                Dpath = Path.Combine(Dpath, (FCode + 1).ToString("0000") + "_" + txt_PED_ProjCode.Text + "_" + txt_PED_Desc.Text);
                System.IO.Directory.CreateDirectory(Dpath);
            }
            
        }
        private void Btn_PED_CreateProjFolder_MouseEnter(object sender, EventArgs e)
        {
            btn_PED_Done.ForeColor = Color.White;
        }

        private void Btn_PED_CreateProjFolder_MouseLeave(object sender, EventArgs e)
        {
            btn_PED_Done.ForeColor = Color.FromArgb(64, 64, 64);
        }
    }
}

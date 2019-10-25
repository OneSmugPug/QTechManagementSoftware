﻿using System.Drawing;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;

namespace QTechManagementSoftware
{
    public partial class Proj_Dialog : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        public Proj_Dialog()
        {
            InitializeComponent();
        }


        //================================================================================================================================================//
        // CLOSE CLICKED                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_PD_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //================================================================================================================================================//
        // EDIT PROJECT CLICKED                                                                                                                           //
        //================================================================================================================================================//
        private void Btn_PD_EditProj_Click(object sender, EventArgs e)
        {
            Proj_Edit_Del frmPED = new Proj_Edit_Del();
            frmPED.Show(this.Owner);
            this.Close();
        }


        //================================================================================================================================================//
        // ADD EXPENSE CLICKED                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_PD_AddExp_Click(object sender, EventArgs e)
        {
            Projects owner = (Projects)this.Owner;
            Home frmHome = (Home)owner.Owner;

            Proj_AddExp frmAE = new Proj_AddExp();
            frmAE.Owner = owner;
            frmAE.SetHome(frmHome);
            frmHome.SetProjExpForm(frmAE);
            this.Close();
        }


        //================================================================================================================================================//
        // CLOSE BUTTON                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_PD_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_PD_Close.Image = Resources.close_white;
        }

        private void Btn_PD_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_PD_Close.Image = Resources.close_black;
        }


        //================================================================================================================================================//
        // ADD EXPENSE BUTTON                                                                                                                             //
        //================================================================================================================================================//
        private void Btn_PD_AddExp_MouseEnter(object sender, EventArgs e)
        {
            btn_PD_AddExp.ForeColor = Color.White;
        }

        private void Btn_PD_AddExp_MouseLeave(object sender, EventArgs e)
        {
            btn_PD_AddExp.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // EDIT PROJECT BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_PD_EditProj_MouseEnter(object sender, EventArgs e)
        {
            btn_PD_EditProj.ForeColor = Color.White;
        }

        private void Btn_PD_EditProj_MouseLeave(object sender, EventArgs e)
        {
            btn_PD_EditProj.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // PROJECT DIALOG                                                                                                                                 //
        //================================================================================================================================================//
        private void Proj_Dialog_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Proj_Dialog_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void Proj_Dialog_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}

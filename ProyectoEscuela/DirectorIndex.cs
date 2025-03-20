﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEscuela
{
    public partial class DirectorIndex : Form
    {
        public DirectorIndex()
        {
            InitializeComponent();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DirectorIndex_Load(object sender, EventArgs e)
        {
            pInicio.Visible = true;
            panel2.Controls.Clear();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                login.ShowDialog();
            }
        }
        private void btnGrupos_Click(object sender, EventArgs e)
        {
            abrirGrupos();
        }


        private void btnMaestros_Click(object sender, EventArgs e)
        {
            abrirMaestros();
        }
        private void btnEvaluaciones_Click(object sender, EventArgs e)
        {
            abrirEvaluaciones();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            pInicio.Visible = true;

        }
        public void abrirEvaluaciones()
        {
            panel2.Controls.Clear();
            DirectorEvaluaciones newForm = new DirectorEvaluaciones();
            newForm.TopLevel = false; // This is important to embed the form
            newForm.FormBorderStyle = FormBorderStyle.None; // Optional: Remove borders
            newForm.Dock = DockStyle.Fill; // Optional: Fill the panel
            panel2.Controls.Add(newForm);
            newForm.Show();
        }
        public void abrirGrupos()
        {

            panel2.Controls.Clear();
            DirectorGrupos newForm = new DirectorGrupos();
            newForm.TopLevel = false; // This is important to embed the form
            newForm.FormBorderStyle = FormBorderStyle.None; // Optional: Remove borders
            newForm.Dock = DockStyle.Fill; // Optional: Fill the panel
            panel2.Controls.Add(newForm);
            newForm.Show();
        }
        public void abrirMaestros()
        {
            panel2.Controls.Clear();
            DirectorMaestros newForm = new DirectorMaestros();
            newForm.TopLevel = false; // This is important to embed the form
            newForm.FormBorderStyle = FormBorderStyle.None; // Optional: Remove borders
            newForm.Dock = DockStyle.Fill; // Optional: Fill the panel
            panel2.Controls.Add(newForm);
            newForm.Show();
        }

        private void btnGrupos1_Click(object sender, EventArgs e)
        {
            abrirGrupos();
        }
        private void btnGrupos2_Click(object sender, EventArgs e)
        {
            abrirGrupos();
        }
        private void btnMaestros1_Click(object sender, EventArgs e)
        {
            abrirMaestros();
        }
        private void btnMaestros2_Click(object sender, EventArgs e)
        {
            abrirMaestros();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReglasDeNegocio;

namespace ProyectoEscuela
{
    public partial class DirectorIndex : Form
    {
        MySQLDirector direClass = new MySQLDirector();

        public DirectorIndex()
        {
            InitializeComponent();
        }

        private void DirectorIndex_Load(object sender, EventArgs e)
        {
            pInicio.Visible = true;
            lblNombre.Text = direClass.GetName();
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
            pInicio.Visible = false;
            panel2.Controls.Clear();
            DirectorEvaluaciones newForm = new DirectorEvaluaciones();
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(newForm);
            newForm.Show();
        }
        public void abrirGrupos()
        {
            pInicio.Visible = false;
            panel2.Controls.Clear();
            DirectorGrupos newForm = new DirectorGrupos();
            newForm.TopLevel = false; 
            newForm.FormBorderStyle = FormBorderStyle.None; 
            newForm.Dock = DockStyle.Fill; 
            panel2.Controls.Add(newForm);
            newForm.Show();
        }
        public void abrirMaestros()
        {
            pInicio.Visible = false;
            panel2.Controls.Clear();
            DirectorMaestros newForm = new DirectorMaestros();
            newForm.TopLevel = false; 
            newForm.FormBorderStyle = FormBorderStyle.None; 
            newForm.Dock = DockStyle.Fill;
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

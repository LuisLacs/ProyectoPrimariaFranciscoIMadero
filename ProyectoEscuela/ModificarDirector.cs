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
    public partial class ModificarDirector : Form
    {
        public ModificarDirector()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbUsername.Text) && !string.IsNullOrEmpty(tbPassword.Text))
            {
                MySQLDirector direClass = new MySQLDirector();
                if(direClass.ModifyPrincipal(tbName.Text, tbLastName.Text, tbUsername.Text, tbPassword.Text))
                {
                    MessageBox.Show("Información de director modificada exitosamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error: " + direClass.sError);
                }
            } else
            {
                MessageBox.Show("Favor de llenar todos los campos", "Error", MessageBoxButtons.OK);
            }
        }
    }
}

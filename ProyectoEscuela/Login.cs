using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbUser.Text != string.Empty || tbPass.Text != string.Empty)
                {
                    DirectorIndex director = new DirectorIndex();
                    //Aqui va la conexion
                    director.ShowDialog();
                    this.Close();
                }
                else if (tbUser.Text == string.Empty)
                {
                    MessageBox.Show("Favor ingresar un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (tbPass.Text == string.Empty)
                {
                    MessageBox.Show("Favor ingresar una contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch 
            {
                MessageBox.Show("Contraseña Incorrecta");
            }
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

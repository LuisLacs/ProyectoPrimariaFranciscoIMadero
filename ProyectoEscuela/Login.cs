using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.CodeParser.VB.Preprocessor;
using DevExpress.XtraPrinting.Native;
using ReglasDeNegocio;

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
                    MainClass mainClass = new MainClass();
                    MySQLDirector direClass = new MySQLDirector();
                    if (mainClass.BDIniciarSesion())
                    {
                        if (tbUser.Text == direClass.GetUser())
                        {
                            if (direClass.DireLogin(tbUser.Text, tbPass.Text))
                            {
                                DirectorIndex director = new DirectorIndex();
                                //Aqui va la conexion
                                director.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            Maestro maestro = new Maestro();
                            maestro.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error de conexión a la base de datos: " + mainClass.sError);
                    }
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
                MessageBox.Show("Ocurrió un error");
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                guna2Button1_Click(sender, e);
            }
        }

        private void cbMostrarContra_CheckedChanged(object sender, EventArgs e)
        {
            // Evaluar el estado del comboBox de 'Mostrar contraseña'
            if (cbMostrarContra.Checked)
            {
                // Si se encuentra seleccionada la casilla, no reemplazar la contraseña con un caracter especial
                tbPass.PasswordChar = '\0';
            }
            else
            {
                tbPass.PasswordChar = '*';
            }
        }
    }
}

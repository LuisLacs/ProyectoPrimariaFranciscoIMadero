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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbUser.Text != string.Empty || tbPass.Text != string.Empty)
                {
                    MainClass mainClass = new MainClass();
                    MySQLDirector direClass = new MySQLDirector();
                    MySQLMaestro maestroClass = new MySQLMaestro();
                    if (mainClass.BDIniciarSesion())
                    {
                        if (tbUser.Text == direClass.GetUser())
                        {
                            if (direClass.PrincipalLogin(tbUser.Text, tbPass.Text))
                            {
                                DirectorIndex director = new DirectorIndex();
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
                            DataTable dt = new DataTable();
                            bool found = false;
                            if(maestroClass.TeacherLogin(ref dt, tbUser.Text, tbPass.Text))
                            {
                                foreach(DataRow row in dt.Rows)
                                {
                                    if (row[0].ToString() == tbUser.Text && row[1].ToString() == tbPass.Text)
                                    {
                                        int id = maestroClass.GetID(row[0].ToString(), row[1].ToString());
                                        Maestro maestro = new Maestro(id);
                                        maestro.Show();
                                        this.Hide();
                                        found = true;
                                        break;
                                    }
                                }
                                if (found)
                                {
                                    return;
                                } else
                                {
                                    MessageBox.Show("Usuario o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            } else
                            {
                                MessageBox.Show("Ocurrió un error: " + maestroClass.sError);
                            }
                            
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

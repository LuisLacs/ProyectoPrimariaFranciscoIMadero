﻿using System;
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
    public partial class AgregarMaestro : Form
    {
        int iId;
        public AgregarMaestro(int id)
        {
            InitializeComponent();
            iId = id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text != string.Empty && tbLastName.Text != string.Empty && tbGrade.Text != string.Empty && tbUsername.Text != string.Empty && tbPassword.Text != string.Empty)
            {
                int grade = Convert.ToInt16(tbGrade.Text);
                if (grade > 6)
                {
                    MessageBox.Show("Solamente se permiten grados entre 1-6", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    MySQLDirector direClass = new MySQLDirector();
                    DataTable dt = new DataTable();
                    direClass.GetClasses(ref dt, Convert.ToInt16(tbGrade.Text));
                    if(dt == null)
                    {
                        if (direClass.CountTeachers() <= 6)
                        {
                            if (direClass.AddTeacher(iId, tbName.Text, tbLastName.Text, Convert.ToInt16(tbGrade.Text), tbUsername.Text, tbPassword.Text))
                            {
                                MessageBox.Show("Información de maestro almacenada exitosamente");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un error: " + direClass.sError);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se permiten más de 6 maestros para los 6 grupos", "Error", MessageBoxButtons.OK);
                        }
                    } else
                    {
                        MessageBox.Show("Ya se encuentra un maestro asignado a ese grado", "Error", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos", "Error", MessageBoxButtons.OK);
            }
        }

        private void tbGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != 13 && e.KeyChar != 11)
            {
                // Si no es un número ni la tecla de retroceso, cancela el evento de pulsación de tecla
                e.Handled = true;
            }
        }
    }
}

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
    public partial class ModificarMaestro : Form
    {
        MySQLDirector direClass = new MySQLDirector();
        int iId;

        public ModificarMaestro(int id, string name, string lname, string grade)
        {
            InitializeComponent();
            tbName.Text = name;
            tbLastName.Text = lname;
            tbGrade.Text = grade;
            iId = id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (direClass.ModifyTeacher(iId, tbName.Text, tbLastName.Text, Convert.ToInt16(tbGrade.Text)))
            {
                MessageBox.Show("Información de maestro modificada exitosamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error: " + direClass.sError);
            }
        }

        private void tbGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != 13 && e.KeyChar != 11)
            {
                // Si no es un número ni la tecla de retroceso, cancela el evento de pulsación de tecla
                e.Handled = true;
                //
            }
        }
    }
}

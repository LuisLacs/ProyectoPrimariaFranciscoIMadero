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
            MySQLDirector direClass = new MySQLDirector();
            if(direClass.AddTeacher(iId, tbName.Text, tbLastName.Text, Convert.ToInt16(tbGrade.Text))){
                MessageBox.Show("Información de maestro almacenada exitosamente");
                this.Close();
                DirectorMaestros maestros = new DirectorMaestros();
                maestros.RefreshOptions();
                maestros.LoadOptions();
            }
            else
            {
                MessageBox.Show("Ocurrió un error: " + direClass.sError);
            }
        }
    }
}

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
    public partial class Maestro : Form
    {
        MySQLMaestro maestroClass = new MySQLMaestro();
        int iID;

        public Maestro(int id)
        {
            InitializeComponent();
            iID = id;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            DialogResult result = MessageBox.Show("¿Seguro que desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                login.ShowDialog();
            }
        }

        private void Maestro_Load(object sender, EventArgs e)
        {
            lblNombre.Text = maestroClass.GetName(iID);
        }
    }
}

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
    public partial class Director : Form
    {
        public Director()
        {
            InitializeComponent();
        }

        private void guna2Panel2_Click(object sender, EventArgs e)
        {

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

        private void btnGrupos1_Click(object sender, EventArgs e)
        {
            DirectorIndex newWin = new DirectorIndex();
            
        }
    }
}

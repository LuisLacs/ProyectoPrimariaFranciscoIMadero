using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraTreeList.Painter;
using Google.Protobuf.WellKnownTypes;
using Guna.UI2.WinForms;
using ReglasDeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace ProyectoEscuela
{
    public partial class DirectorMaestros : Form
    {
        MySQLDirector direClass = new MySQLDirector();
        public DirectorMaestros()
        {
            InitializeComponent();
            
        }

        private void DirectorMaestros_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }

        private void LoadOptions()
        {
            DataTable dt = new DataTable();
            pnlAddMaestro.Visible = true;

            direClass.GetTeachers(ref dt);
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                switch (i)
                {
                    case 0:
                        pnlMaestro1.Visible = true;
                        lblId1.Text = row[0].ToString();
                        lblName1.Text = row[1].ToString() + " " + row[2].ToString();
                        string group = CheckGroup(row[3].ToString());
                        lblGroup1.Text = group;
                        pnlAddMaestro.Location = new Point(14, 305);
                        i++;
                        break;
                    case 1:
                        pnlMaestro2.Visible = true;
                        lblId2.Text = row[0].ToString();
                        lblName2.Text = row[1].ToString() + " " + row[2].ToString();
                        string group1 = CheckGroup(row[3].ToString());
                        lblGroup2.Text = group1;
                        pnlAddMaestro.Location = new Point(14, 384);
                        i++;
                        break;
                    case 2:
                        pnlMaestro3.Visible = true;
                        lblId3.Text = row[0].ToString();
                        lblName3.Text = row[1].ToString() + " " + row[2].ToString();
                        string group2 = CheckGroup(row[3].ToString());
                        lblGroup3.Text = group2;
                        pnlAddMaestro.Location = new Point(14, 460);
                        i++;
                        break;
                    case 3:
                        pnlMaestro4.Visible = true;
                        lblId4.Text = row[0].ToString();
                        lblName4.Text = row[1].ToString() + " " + row[2].ToString();
                        string group3 = CheckGroup(row[3].ToString());
                        lblGroup4.Text = group3;
                        pnlAddMaestro.Location = new Point(14, 536);
                        i++;
                        break;
                    case 4:
                        pnlMaestro5.Visible = true;
                        lblId5.Text = row[0].ToString();
                        lblName5.Text = row[1].ToString() + " " + row[2].ToString();
                        string group4 = CheckGroup(row[3].ToString());
                        lblGroup5.Text = group4;
                        pnlAddMaestro.Location = new Point(14, 611);
                        i++;
                        break;
                    case 5:
                        pnlMaestro6.Visible = true;
                        lblId6.Text = row[0].ToString();
                        lblName6.Text = row[1].ToString() + " " + row[2].ToString();
                        string group5 = CheckGroup(row[3].ToString());
                        lblGroup6.Text = group5;
                        pnlAddMaestro.Location = new Point(14, 686);
                        i++;
                        break;
                }
            }
        }

        private string CheckGroup(string num)
        {
            switch (num)
            {
                case "1":
                    num = "Primero";
                    break;
                case "2":
                    num = "Segundo";
                    break;
                case "3":
                    num = "Tercero";
                    break;
                case "4":
                    num = "Cuarto";
                    break;
                case "5":
                    num = "Quinto";
                    break;
                case "6":
                    num = "Sexto";
                    break;
                default:
                    break;
            }
            return num;
        }

        private void btnModify1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(lblId1.Text);
            CallModify(id);
        }

        private void CallModify(int id)
        {
            string name = string.Empty, lname = string.Empty, grade = string.Empty;
            DataTable dt = new DataTable();
            direClass.GetTeacher(ref dt, id);
            foreach (DataRow row in dt.Rows)
            {
                name = row[1].ToString();
                lname = row[2].ToString();
                grade = row[3].ToString();
            }
            ModificarMaestro modify = new ModificarMaestro(id, name, lname, grade);
            var check = modify.ShowDialog();
            if (check == DialogResult.OK || check == DialogResult.Cancel)
            {
                LoadOptions();
            }
        }

        private void btnModify2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(lblId2.Text);
            CallModify(id);
        }

        private void btnModify3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(lblId3.Text);
            CallModify(id);
        }

        private void btnModify4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(lblId4.Text);
            CallModify(id);
        }

        private void btnModify5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(lblId5.Text);
            CallModify(id);
        }

        private void btnModify6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(lblId6.Text);
            CallModify(id);
        }

        private void CallDelete(int id)
        {
            string name = string.Empty, lname = string.Empty;
            DataTable dt = new DataTable();
            direClass.GetTeacher(ref dt, id);
            foreach (DataRow row in dt.Rows)
            {
                name = row[1].ToString();
                lname = row[2].ToString();
            }

            if (direClass.DeleteTeacher(id))
            {
                MessageBox.Show("Se eliminó " + name + " " + lname + " de manera exitosa");
                LoadOptions();
            }
            else
            {
                MessageBox.Show("Ocurrió un error: " + direClass.sError);
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"¿Esta seguro que desea eliminar a {lblName1.Text}?", "Advertencia", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt16(lblId1.Text);
                CallDelete(id);
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"¿Esta seguro que desea eliminar a {lblName2.Text}?", "Advertencia", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt16(lblId2.Text);
                CallDelete(id);
            }
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"¿Esta seguro que desea eliminar a {lblName3.Text}?", "Advertencia", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt16(lblId3.Text);
                CallDelete(id);
            }
        }

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"¿Esta seguro que desea eliminar a {lblName4.Text}?", "Advertencia", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt16(lblId4.Text);
                CallDelete(id);
            }
        }

        private void btnDelete5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"¿Esta seguro que desea eliminar a {lblName5.Text}?", "Advertencia", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt16(lblId5.Text);
                CallDelete(id);
            }
        }

        private void btnDelete6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"¿Esta seguro que desea eliminar a {lblName6.Text}?", "Advertencia", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt16(lblId6.Text);
                CallDelete(id);
            }
        }

        private void AddTeacher()
        {
            int id = direClass.LastID() + 1;
            AgregarMaestro agregar = new AgregarMaestro(id);
            var check = agregar.ShowDialog();
            if (check == DialogResult.OK || check == DialogResult.Cancel)
            {
                LoadOptions();
            }
        }

        private void pnlAddMaestro_Click(object sender, EventArgs e)
        {
            AddTeacher();
        }

        private void btnAddMaestro_Click(object sender, EventArgs e)
        {
            AddTeacher();
        }
        private void lblAddTeacher_Click(object sender, EventArgs e)
        {
            AddTeacher();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != string.Empty)
            {
                int id = direClass.GetIDName(tbSearch.Text);
                if (id == 0)
                {
                    id = direClass.GetIDLastName(tbSearch.Text);
                    if (id == 0)
                    {
                        MessageBox.Show("No se ha podido encontrar una coincidencia", "Error", MessageBoxButtons.OK);
                        return;
                    }
                }

                DataTable dt = new DataTable();
                direClass.GetTeacher(ref dt, id);
                pnlMaestro6.Visible = false;
                pnlMaestro5.Visible = false;
                pnlMaestro4.Visible = false;
                pnlMaestro3.Visible = false;
                pnlMaestro2.Visible = false;
                pnlAddMaestro.Visible = false;

                foreach (DataRow row in dt.Rows)
                {
                    lblId1.Text = row[0].ToString();
                    lblName1.Text = row[1].ToString() + " " + row[2].ToString();
                    string group = CheckGroup(row[3].ToString());
                    lblGroup1.Text = group;
                }
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Text = string.Empty;
            LoadOptions();
        }

        
    }
}

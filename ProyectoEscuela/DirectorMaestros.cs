using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace ProyectoEscuela
{
    public partial class DirectorMaestros : Form
    {
        public DirectorMaestros()
        {
            InitializeComponent();
        }
        int y = 196, conteo = 1;
        //int panel[];

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DirectorMaestros_Load(object sender, EventArgs e)
        {
            int numeroMaestros = 6;
            Guna2Panel panelMaestro = new Guna2Panel();
            Guna2Button iconoMaestro = new Guna2Button();
            Label labelId = new Label();
            Label labelNombre = new Label();
            Label labelGrupo = new Label();
            Guna2Button botonModificar = new Guna2Button();
            Guna2Button botonEliminar = new Guna2Button();


            for (int i = 1; i < numeroMaestros;i++)
            {
                
                panelMaestro.Height = 70;
                panelMaestro.Width = 813;
                panelMaestro.Location = new Point(14, y);
                y += 66;
                panelMaestro.Name = "pMaestro" + i.ToString();
                panelMaestro.BackColor = Color.White;

                
                iconoMaestro.Height = 50;
                iconoMaestro.Width = 50;
                iconoMaestro.Location = new Point(12, 8);
                iconoMaestro.Name = "iconMaestro" + i.ToString();
                iconoMaestro.FillColor = Color.LightGreen;
                iconoMaestro.BorderRadius = 5;
                iconoMaestro.BorderColor = Color.SteelBlue;
                iconoMaestro.BorderThickness = 1;



                labelId.Location = new Point(83, 24);
                labelId.Height = 19;
                labelId.Width = 19;
                labelId.Name = "lblId" + i;
                labelId.Text = conteo.ToString();
                labelId.Font = new Font("Century Gothic", 12, FontStyle.Bold);

                
                labelNombre.Location = new Point(123, 24);
                labelNombre.Name = "lblName" + i;
                labelNombre.Text = "Nombre " + i;
                labelNombre.Font = new Font("Century Gothic", 12, FontStyle.Bold);

                
                labelGrupo.Location = new Point(316, 24);
                labelGrupo.Name = "lblGrupo" + i;
                labelGrupo.Text = "Grupo " + i;
                labelGrupo.Font = new Font("Century Gothic", 12, FontStyle.Bold);

               
                botonModificar.Height = 36;
                botonModificar.Width = 123;
                botonModificar.Location = new Point(460, 18);
                botonModificar.Text = "Modificar";
                botonModificar.Name = "ModificarMaestro" + i.ToString();
                botonModificar.FillColor = Color.LightGreen;
                botonModificar.BorderRadius = 5;
                botonModificar.BorderColor = Color.LawnGreen;
                botonModificar.BorderThickness = 1;

                
                botonEliminar.Height = 36;
                botonEliminar.Width = 123;
                botonEliminar.Location = new Point(617, 18);
                botonEliminar.Text = "Eliminar";
                botonEliminar.Name = "ModificarMaestro" + i.ToString();
                botonEliminar.FillColor = Color.IndianRed;
                botonEliminar.BorderRadius = 5;
                botonEliminar.BorderColor = Color.Red;
                botonEliminar.BorderThickness = 1;
                i++;

                panel1.Controls.Add(panelMaestro);
                panelMaestro.Controls.Add(iconoMaestro);
                panelMaestro.Controls.Add(labelId);
                panelMaestro.Controls.Add(labelNombre);
                panelMaestro.Controls.Add(labelGrupo);
                panelMaestro.Controls.Add(botonModificar);
                panelMaestro.Controls.Add(botonEliminar);
            }
            Guna2Panel panelAgregarMaestro = new Guna2Panel();
            panelAgregarMaestro.Height = 70;
            panelAgregarMaestro.Width = 813;
            panelAgregarMaestro.Location = new Point(14, y);
            y += 66;
            panelAgregarMaestro.Name = "pAgregarMaestro";
            panelAgregarMaestro.BackColor = Color.White;

            Label lblAdd = new Label();
            lblAdd.Location = new Point(83, 24);
            lblAdd.Name = "lblAddMaestro";
            lblAdd.Text = "Agregar Nuevo Maestro";
            lblAdd.Font = new Font("Century Gothic", 12);


            
            panel1.Controls.Add(panelAgregarMaestro);
            panelAgregarMaestro.Controls.Add(lblAdd);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

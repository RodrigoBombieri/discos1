﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominioD;
using negocioD;

namespace discos1
{
    public partial class FormDiscos : Form
    {
        private List<Disco> listaDiscos;
        public FormDiscos()
        {
            InitializeComponent();
        }

        private void FormDiscos_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDiscos.CurrentRow != null)
            {
                Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                CargarImagen(seleccionado.UrlImagenTapa);
            }
            
        }

        private void Cargar()
        {
            DiscoNegocio negocio = new DiscoNegocio();
            try
            {
                listaDiscos = negocio.listar();
                dgvDiscos.DataSource = listaDiscos;
                ocultarColumnas();
                CargarImagen(listaDiscos[0].UrlImagenTapa);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvDiscos.Columns["Id"].Visible = false;
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pibDiscos.Load(imagen);
            }
            catch (Exception ex)
            {

                pibDiscos.Load("https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg");
            }
        }

        private void btnAgregarDisco_Click(object sender, EventArgs e)
        {
            frmAgregarDisco alta = new frmAgregarDisco();
            alta.ShowDialog();
            Cargar();
        }

        private void btnModificarDisco_Click(object sender, EventArgs e)
        {
            Disco seleccionado;
            seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            
            
            frmAgregarDisco modificar = new frmAgregarDisco(seleccionado);
            modificar.ShowDialog();
            Cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            Disco seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if( respuesta == DialogResult.Yes)
                {
                    seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.Id);
                    Cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            List<Disco> listafiltrada;
            string filtro = txtFiltro.Text;

            if(filtro != "")
            {
                listafiltrada = listaDiscos.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listafiltrada = listaDiscos;
            }

            dgvDiscos.DataSource = null;
            dgvDiscos.DataSource = listafiltrada;
            ocultarColumnas();

        }
    }
}

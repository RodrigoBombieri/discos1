using System;
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
    public partial class frmAgregarDisco : Form
    {
        public frmAgregarDisco()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Disco disco = new Disco();
            DiscoNegocio negocio = new DiscoNegocio();

            try
            {
                disco.Id = int.Parse(txtId.Text);
                disco.Titulo = txtTitulo.Text;
                disco.CantidadCanciones = int.Parse(txtCantCanciones.Text);
                disco.Estilo = (Estilo)cboEstilo.SelectedItem;
                disco.Edicion = (Edicion)cboEdicion.SelectedItem;

                negocio.agregar(disco);
                MessageBox.Show("Agregado exitosamente");
                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAgregarDisco_Load(object sender, EventArgs e)
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            EdicionNegocio edicionNegocio = new EdicionNegocio();

            try
            {
                cboEstilo.DataSource = estiloNegocio.listar();
                cboEdicion.DataSource = edicionNegocio.listar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}

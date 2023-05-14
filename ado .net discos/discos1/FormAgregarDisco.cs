using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominioD;
using negocioD;
using System.Configuration;

namespace discos1
{
    public partial class frmAgregarDisco : Form
    {
        private Disco disco = null;

        private OpenFileDialog archivo = null;
        
        public frmAgregarDisco()
        {
            InitializeComponent();
        }

        public frmAgregarDisco(Disco disco)
        {
            InitializeComponent();
            this.disco = disco;
            Text = "Modificar Disco";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();

            try
            {
                if (disco == null)
                {
                    disco = new Disco();
                }
                              
                disco.Titulo = txtTitulo.Text;
                disco.CantidadCanciones = int.Parse(txtCantCanciones.Text);
                disco.UrlImagenTapa = txtUrlImagenTapa.Text;
                disco.Estilo = (Estilo)cboEstilo.SelectedItem;
                disco.Edicion = (Edicion)cboEdicion.SelectedItem;

                if(disco.Id != 0)
                {
                    negocio.modificar(disco);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(disco);
                    MessageBox.Show("Agregado exitosamente");

                }

                // guardo imagen si la levanto localmente
                // si el archivo es distinto de nulo, y NO tiene un http, significa que quiero guardar un archivo local y no un archivo web.
                // haciendo esta validaci{on, la imagen SOLO SE GUARDA EN NUESTRA CARPETA si le damos Agregar.. si cancelamos cuando estamos creando un nuevo disco, la imagen no se guarda.
                if(archivo != null && !(txtUrlImagenTapa.Text.ToUpper().Contains("HTTP")))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["disco-app"] + archivo.SafeFileName);
                }

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
                cboEstilo.ValueMember = "Id";
                cboEstilo.DisplayMember = "Descripcion";
                cboEdicion.ValueMember = "Id";
                cboEdicion.DisplayMember = "Descripcion";

                if (disco != null)
                {
                    txtTitulo.Text = disco.Titulo;
                    txtCantCanciones.Text = disco.CantidadCanciones.ToString();
                    txtUrlImagenTapa.Text = disco.UrlImagenTapa;

                    CargarImagen(disco.UrlImagenTapa);

                    cboEstilo.SelectedValue = disco.Estilo.Id;
                    cboEdicion.SelectedValue = disco.Edicion.Id;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagenTapa_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtUrlImagenTapa.Text);
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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png;|jpeg|*.jpeg";
            
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                txtUrlImagenTapa.Text = archivo.FileName;
                CargarImagen(archivo.FileName);

            }

            //guardar imagen
            //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["disco-app"] + archivo.SafeFileName);
        }
    }
}

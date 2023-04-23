using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using dominioD;
using System.Security.Cryptography.X509Certificates;

namespace negocioD
{
    public class DiscoNegocio
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Titulo, CantidadCanciones, UrlImagenTapa, E.Descripcion Estilo, T.Descripcion Edicion from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo = E.Id and D.IdTipoEdicion = T.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    
                    aux.Titulo = (string)lector["Titulo"];
                    aux.CantidadCanciones = lector.GetInt32(1);
                    if (!(lector["UrlImagenTapa"] is DBNull))
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Descripcion = (string)lector["Estilo"];
                    aux.Edicion = new Edicion();
                    aux.Edicion.Descripcion = (string)lector["Edicion"];
                    

                    lista.Add(aux);

                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into DISCOS (Titulo, CantidadCanciones, IdEstilo, IdTipoEdicion, UrlImagenTapa)values('" + nuevo.Titulo + "' , " + nuevo.CantidadCanciones + ", @idEstilo, @idTipoEdicion, @urlImagenTapa)");
                datos.setearParametro("@idEstilo", nuevo.Estilo.Id);
                datos.setearParametro("@idTipoEdicion", nuevo.Edicion.Id);
                datos.setearParametro("@urlImagenTapa", nuevo.UrlImagenTapa);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }finally
            {
                datos.cerrarConexion();
            }
        }

    }
}

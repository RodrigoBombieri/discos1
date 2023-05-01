using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioD
{
    public class Disco
    {
        
        public int Id { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Cantidad de canciones")]
        public int CantidadCanciones { get; set; }

        [DisplayName("URL Imagen de Tapa")]
        public string UrlImagenTapa { get; set; }
        public Estilo Estilo { get; set; }
        public Edicion Edicion { get; set; }

    }
}

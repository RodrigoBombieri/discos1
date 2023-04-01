using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioD
{
    public class Disco
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public int CantidadCanciones { get; set; }
        public string UrlImagenTapa { get; set; }
        public Estilo Estilo { get; set; }
        public Edicion Edicion { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CContribuyente
    {
        public int codigo { get; set; }
        public string empresa { get; set; }
        public string ruc { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string direccion { get; set; }
        public float igv { get; set; }
        public string impresora { get; set; }
    }
}

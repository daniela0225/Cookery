using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CFactura
    {
        public int codigo { get; set; }
        public int venta { get; set; }
        public string raz_soc { get; set; }
        public string ruc { get; set; }
        public float pretotal { get; set; }
        public float igv { get; set; }
        public float total { get; set; }
    }
}

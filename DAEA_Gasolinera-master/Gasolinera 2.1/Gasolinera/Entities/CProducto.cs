using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CProducto
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public float cantidad { get; set; }
        public string medida { get; set; }
    }
}

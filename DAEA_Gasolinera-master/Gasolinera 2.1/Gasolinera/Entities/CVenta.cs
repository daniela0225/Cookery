using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CVenta
    {
        public int codigo { get; set; }
        public int usuario { get; set; }
        public int producto { get; set; }
        public float cantidad { get; set; }
        public DateTime fecha { get; set; }
        public int contribuyente { get; set; }
        public int cliente { get; set; }
        public string sede { get; set; }
        public string placa { get; set; }
        public string observacion { get; set; }
    }
}

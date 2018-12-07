using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CUsuario
    {
        public int codigo { get; set; }
        public string dni { get; set; }
        public string nom_ape { get; set; }
        public string tipo { get; set; }
        public string nickname { get; set; }
        public string password { get; set; }
    }
}

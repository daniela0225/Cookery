using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Reservacion
    {
        public string id_resv { get; set; }
        public string id_rest { get; set; }
        public string id_per { get; set; }
        public DateTime resv_date { get; set; }
        public string resv_phone { get; set; }
        public string resv_add { get; set; }
        public string resv_mail { get; set; }

    }
}

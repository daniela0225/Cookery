//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menus
    {
        public string id_men { get; set; }
        public string id_mea { get; set; }
        public string id_rest { get; set; }
        public Nullable<System.DateTime> men_avaiFrom { get; set; }
        public Nullable<System.DateTime> men_avaiTo { get; set; }
    
        public virtual Meals Meals { get; set; }
        public virtual Restaurants Restaurants { get; set; }
    }
}

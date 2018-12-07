using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class AccessMiddleware
    {
        public static IDictionary<string, Dictionary<string, bool>> admin = new Dictionary<string, Dictionary<string, bool>>()
            {
                { "Contribuyente", new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", true }, { "eliminar" , true} } },
                { "Producto", new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", true }, { "eliminar" , true} } },
                { "Cliente",  new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", true }, { "eliminar" , true} } },
                { "Venta",  new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", true }, { "eliminar" , true} } },
                { "Boleta",  new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", true }, { "eliminar" , true} } },
                { "Factura",  new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", true }, { "eliminar" , true} } },
                { "Usuario",  new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", true }, { "eliminar" , true} } }
            };

        public static IDictionary<string, Dictionary<string, bool>> employee = new Dictionary<string, Dictionary<string, bool>>()
            {
                { "Contribuyente",  new Dictionary<string, bool>(){ { "listar", true }, { "crear", false }, { "editar", false }, { "eliminar" , false} } },
                { "Producto",  new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", true }, { "eliminar" , false} } },
                { "Cliente",  new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", true }, { "eliminar" , false} } },
                { "Venta",  new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", false }, { "eliminar" , false} } },
                { "Boleta",   new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", false }, { "eliminar" , false} } },
                { "Factura",  new Dictionary<string, bool>(){ { "listar", true }, { "crear", true }, { "editar", false }, { "eliminar" , false} } },
                { "Usuario",  new Dictionary<string, bool>(){ { "listar", false }, { "crear", false }, { "editar", false }, { "eliminar" , false} } }
            };

        public static bool can(string userDNI, string accion, string tabla)
        {
            UsuarioDAL context = new UsuarioDAL();

            CUsuario usuario = context.GetByDNI(userDNI);

            if (usuario.tipo == "ADMIN")
            {
                if (admin[tabla][accion]) return true;
                else return false;
            }
            else if (usuario.tipo == "EMPLOYEE")
            {
                if (employee[tabla][accion]) return true;
                else return false;
            }
            return false;
        }
    }
}

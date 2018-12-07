using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class UsuarioDAL
    {
        GasolineraEntities context = new GasolineraEntities();

        public List<CUsuario> Listar()
        {
            using (context)
            {
                var query = context.Usuario.Select(u => new CUsuario
                {
                    codigo = u.codigo,
                    dni = u.dni,
                    nom_ape = u.nom_ape,
                    tipo = u.tipo,
                    nickname = u.nickname,
                    password = u.password
                });
                return query.ToList();
            }
        }

        public List<CUsuario> ListaModal()
        {
            using (context)
            {
                var query = context.Usuario.Select(u => new CUsuario
                {
                    codigo = u.codigo,
                    dni = u.dni,
                    nom_ape = u.nom_ape
                });
                return query.ToList();
            }
        }

        public CUsuario Get(int codigo)
        {
            var query = context.Usuario.Select(u => new CUsuario
            {
                codigo = u.codigo,
                dni = u.dni,
                nom_ape = u.nom_ape,
                tipo = u.tipo,
                nickname = u.nickname,
                password = u.password
            }).Where(u => u.codigo == codigo);

            return query.First();
        }

        public CUsuario GetByNickname(String nickname)
        {
            var query = context.Usuario.Select(u => new CUsuario
            {
                codigo = u.codigo,
                dni = u.dni,
                nom_ape = u.nom_ape,
                tipo = u.tipo,
                nickname = u.nickname,
                password = u.password
            }).Where(u => u.nickname == nickname);

            return query.First();
        }

        public CUsuario GetByDNI(String dni)
        {
            var query = context.Usuario.Select(u => new CUsuario
            {
                codigo = u.codigo,
                dni = u.dni,
                nom_ape = u.nom_ape,
                tipo = u.tipo,
                nickname = u.nickname,
                password = u.password
            }).Where(u => u.dni == dni);

            return query.First();
        }

        public int Agregar(CUsuario usu)
        {
            context.insertUsuario(
                    usu.dni,
                    usu.nom_ape,
                    usu.tipo,
                    usu.nickname,
                    usu.password
            );
            return context.SaveChanges();
        }

        public int Editar(CUsuario usu)
        {
            context.updateUsuario(
                usu.codigo,
                usu.dni,
                usu.nom_ape,
                usu.tipo,
                usu.nickname,
                usu.password
            );
            return context.SaveChanges();
        }

        public int Eliminar(int codigo)
        {
            context.deleteUsuario(codigo);
            return context.SaveChanges();
        }
    }
}

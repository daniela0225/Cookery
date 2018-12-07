using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Diagnostics;

namespace BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL usu = new UsuarioDAL();

        public List<CUsuario> ListarBLL()
        {
            return usu.Listar();
        }

        public List<CUsuario> ListaModalBLL()
        {
            return usu.ListaModal();
        }

        public CUsuario GetBLL(int codigo)
        {
            return usu.Get(codigo);
        }

        public int AgregarBLL(  String dni, 
                                String nom_ape, 
                                String nickname,
                                String password,
                                String tipo )
        {
            
            CUsuario nuevo = new CUsuario{
                dni = dni,
                nom_ape = nom_ape,
                nickname = nickname,
                password = Encriptador.GetHashString(password),
                tipo = tipo
            };
            
            return usu.Agregar(nuevo);
        }

        public int EditarBLL(   int codigo,
                                String dni,
                                String nom_ape,
                                String nickname,
                                String password,
                                String tipo )
        {
            CUsuario editado = new CUsuario
            {
                codigo = codigo,
                dni = dni,
                nom_ape = nom_ape,
                nickname = nickname,
                password = Encriptador.GetHashString(password),
                tipo = tipo
            };
            
            return usu.Editar(editado);
        }

        public int EliminarBLL(int codigo)
        {
            return usu.Eliminar(codigo);
        }

        /* Session */

        public String LogIn(String nickname, String password)
        {
            CUsuario usuario = usu.GetByNickname(nickname);
            Debug.WriteLine("BLL usuario tipo:" + usuario.tipo);
            Debug.WriteLine("BLL usuario dni:" + usuario.dni);
            Debug.WriteLine("BLL usuario clave: " + usuario.password);
            Debug.WriteLine("BLL usuario clave unhash: " + Encriptador.GetHashString(password)); 

            if (usuario != null && usuario.password == Encriptador.GetHashString(password))
            {
                if (usuario.tipo == "ADMIN")
                    return "2" + usuario.dni;
                if (usuario.tipo == "EMPLOYEE")
                    return "1" + usuario.dni;
            }

            return "0";
        }
        public String LogOut()
        {
            return "0";
        }
        
    }
}

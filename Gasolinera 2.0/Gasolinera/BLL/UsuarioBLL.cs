using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL usu = new UsuarioDAL();

        public List<CUsuario> ListarBLL()
        {
            return usu.Listar();
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
                password = password,
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
                password = password,
                tipo = tipo
            };
            
            return usu.Editar(editado);
        }

        public int EliminarBLL(int codigo)
        {
            return usu.Eliminar(codigo);
        }

        public bool LogIn()
        {
            return false;
        }

        public bool SignIn()
        {
            return false;
        }
    }
}

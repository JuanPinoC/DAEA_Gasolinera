using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entities;
using DAL;
using BLL;

namespace WebInterface.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioBLL BLLinstance = new UsuarioBLL();

        public ActionResult Index()
        {
            return View();
        }

        public List<CUsuario> GetListado()
        {
            List<CUsuario> listado = BLLinstance.ListarBLL();

            return listado;
        }

        public ActionResult Listado()
        {
            return View(GetListado());
        }

        public ActionResult Formulario(int codigo)
        {
            if(codigo == 0)
            {
                return View();
            }
            else
            {
                CUsuario usuario = BLLinstance.GetBLL(codigo);

                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Crear(CUsuario usuario)
        {
            int success = BLLinstance.AgregarBLL(
                usuario.dni, 
                usuario.nom_ape, 
                usuario.nickname, 
                usuario.password, 
                usuario.tipo);

            return View("Listado",GetListado());
        }

        [HttpPost]
        public ActionResult Editar(CUsuario usuario)
        {
            int success = BLLinstance.EditarBLL(
                usuario.codigo,
                usuario.dni,
                usuario.nom_ape,
                usuario.nickname,
                usuario.password,
                usuario.tipo);

            return View("Listado",GetListado());
        }

        public ActionResult Eliminar(int codigo)
        {
            int success = BLLinstance.EliminarBLL(codigo);
            List<CUsuario> listado = BLLinstance.ListarBLL();
            return View("Listado",GetListado());
        }
    }
}
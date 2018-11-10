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

        public ActionResult Listado()
        {
            List<CUsuario> listado = BLLinstance.ListarBLL();

            return View(listado);
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

        public ActionResult Crear()
        {
            //int success = BLLinstance.AgregarBLL("","","","","");
            return Listado();
        }

        public ActionResult Editar()
        {
            //int success = BLLinstance.EditarBLL(1,"", "", "", "", "");
            return Listado();
        }

        public ActionResult Eliminar(int codigo)
        {
            BLLinstance.EliminarBLL(codigo);
            return Listado();
        }
    }
}
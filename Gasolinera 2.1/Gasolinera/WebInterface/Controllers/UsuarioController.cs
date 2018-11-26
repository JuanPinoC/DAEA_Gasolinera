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
            return (can("listar", "Usuario")) ? 
                View(GetListado()):Index();
        }

        public ActionResult Formulario(int codigo)
        {
            if (codigo == 0)
            {
                return View();
            }
            else
            {
                CUsuario usuario = BLLinstance.GetBLL(codigo);

                return (can("listar", "Usuario")) ? 
                    View(usuario):Index();
            }
        }

        [HttpPost]
        public ActionResult Crear(CUsuario usuario)
        {
            if (can("crear", "Usuario"))
            {
                int success = BLLinstance.AgregarBLL(
                usuario.dni,
                usuario.nom_ape,
                usuario.nickname,
                usuario.password,
                usuario.tipo);

                return View("Listado", GetListado());
            }
            else return Index();
            
        }

        [HttpPost]
        public ActionResult Editar(CUsuario usuario)
        {
            if (can("editar", "Usuario"))
            {
                int success = BLLinstance.EditarBLL(
                usuario.codigo,
                usuario.dni,
                usuario.nom_ape,
                usuario.nickname,
                usuario.password,
                usuario.tipo);

                return View("Listado", GetListado());
            }
            else return Index();
            
        }

        public ActionResult Eliminar(int codigo)
        {
            if (can("eliminar", "Usuario"))
            {
                int success = BLLinstance.EliminarBLL(codigo);
                return View("Listado", GetListado());
            }
            else return Index();
        }

        /* Session */

        public ActionResult LogInForm()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(String nickname, String password)
        {
            String success = BLLinstance.LogIn(nickname, password);
            if(success.Substring(0,1) == "2")
            {
                Session["dni"] = success.Substring(1);
                Session["tipo"] = "2";
                return Admin();
                
            }
            if (success.Substring(0, 1) == "1")
            {
                Session["dni"] = success.Substring(1);
                Session["tipo"] = "1";
                return Admin();


                //return EmployeeView();
            }

           // return LogInForm();
            return Admin();
        }

        public bool can(string action, string table)
        {
            return (AccessMiddleware.can(Session["dni"].ToString(), action, table));
        }
    }
}
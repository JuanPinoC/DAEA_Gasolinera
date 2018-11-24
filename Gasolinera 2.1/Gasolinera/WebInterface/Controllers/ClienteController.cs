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
    public class ClienteController : Controller
    {
        ClienteBLL BLLinstance = new ClienteBLL();

        public ActionResult Index()
        {
            return View();
        }

        public List<CCliente> GetListado()
        {
            List<CCliente> listado = BLLinstance.ListarBLL();

            return listado;
        }

        public ActionResult Listado()
        {
            return (can("listar", "Cliente")) ?
                View(GetListado()) : Index();
        }

        public ActionResult Formulario(int codigo)
        {
            if (codigo == 0)
            {
                return View();
            }
            else
            {
                CCliente cliente = BLLinstance.GetBLL(codigo);
                return (can("listar", "Cliente")) ?
                    View(cliente) : Index();
            }
        }

        [HttpPost]
        public ActionResult Crear(CCliente cliente)
        {

            if (can("crear", "Cliente"))
            {
                int success = BLLinstance.AgregarBLL(
                cliente.tipo_doc,
                cliente.documento,
                cliente.nom_ape,
                cliente.direccion);

                return View("Listado", GetListado());
            }
            else return Index();
        }

        [HttpPost]
        public ActionResult Editar(CCliente cliente)
        {
            if (can("editar", "Cliente"))
            {
                int success = BLLinstance.EditarBLL(
                cliente.codigo,
                cliente.tipo_doc,
                cliente.documento,
                cliente.nom_ape,
                cliente.direccion);

                return View("Listado", GetListado());
            }
            else return Index();
        }

        public ActionResult Eliminar(int codigo)
        {
            if (can("eliminar", "Cliente"))
            {
                int success = BLLinstance.EliminarBLL(codigo);
                return View("Listado", GetListado());
            }
            else return Index();
        }

        /* Session */

        public bool can(string action, string table)
        {
            return (AccessMiddleware.can(Session["dni"].ToString(), action, table));
        }
    }
}
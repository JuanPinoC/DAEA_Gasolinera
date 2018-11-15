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
            return View(GetListado());
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

                return View(cliente);
            }
        }

        [HttpPost]
        public ActionResult Crear(CCliente cliente)
        {
            int success = BLLinstance.AgregarBLL(
                cliente.tipo_doc,
                cliente.documento,
                cliente.nom_ape,
                cliente.direccion);

            return View("Listado", GetListado());
        }

        [HttpPost]
        public ActionResult Editar(CCliente cliente)
        {
            int success = BLLinstance.EditarBLL(
                cliente.codigo,
                cliente.tipo_doc,
                cliente.documento,
                cliente.nom_ape,
                cliente.direccion);

            return View("Listado", GetListado());
        }

        public ActionResult Eliminar(int codigo)
        {
            int success = BLLinstance.EliminarBLL(codigo);
            List<CCliente> listado = BLLinstance.ListarBLL();
            return View("Listado", GetListado());
        }
    }
}
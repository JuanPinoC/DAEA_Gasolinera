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
    public class BoletaController : Controller
    {

        BoletaBLL BLLinstance = new BoletaBLL();

        public ActionResult Index()
        {
            return View();
        }

        public List<CBoleta> GetListado()
        {
            List<CBoleta> listado = BLLinstance.ListarBLL();

            return listado;
        }

        public ActionResult Listado()
        {
            return (can("listar", "Boleta")) ?
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
                CBoleta boleta = BLLinstance.GetBLL(codigo);
                return (can("listar", "Boleta")) ?
                    View(boleta) : Index();
            }
        }

        [HttpPost]
        public ActionResult Crear(CBoleta boleta)
        {
            if (can("crear", "Boleta"))
            {
                int success = BLLinstance.AgregarBLL(
                boleta.venta,
                boleta.dni,
                boleta.total);

                return View("Listado", GetListado());
            }
            else return Index();
        }

        [HttpPost]
        public ActionResult Editar(CBoleta boleta)
        {
            if (can("editar", "Boleta"))
            {
                int success = BLLinstance.EditarBLL(
                boleta.codigo,
                boleta.venta,
                boleta.dni,
                boleta.total);

                return View("Listado", GetListado());
            }
            else return Index();
        }

        public ActionResult Eliminar(int codigo)
        {
            if (can("eliminar", "Boleta"))
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
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
    public class FacturaController : Controller
    {
        FacturaBLL BLLinstance = new FacturaBLL();

        public ActionResult Index()
        {
            return View();
        }

        public List<CFactura> GetListado()
        {
            List<CFactura> listado = BLLinstance.ListarBLL();

            return listado;
        }

        public ActionResult Listado()
        {
            return (can("listar", "Factura")) ?
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
                CFactura factura = BLLinstance.GetBLL(codigo);

                return (can("listar", "Factura")) ?
                    View(factura) : Index();
            }
        }

        [HttpPost]
        public ActionResult Crear(CFactura factura)
        {
            if (can("crear", "Factura"))
            {
                int success = BLLinstance.AgregarBLL(
                    factura.venta,
                    factura.raz_soc,
                    factura.ruc,
                    factura.pretotal,
                    factura.igv,
                    factura.total);

                return View("Listado", GetListado());
            }
            else return Index();
        }

        [HttpPost]
        public ActionResult Editar(CFactura factura)
        {
            if (can("editar", "Factura"))
            {
                int success = BLLinstance.EditarBLL(
                    factura.venta,
                    factura.codigo,
                    factura.raz_soc,
                    factura.ruc,
                    factura.pretotal,
                    factura.igv,
                    factura.total);

                return View("Listado", GetListado());
            }
            else return Index();
        }

        public ActionResult Eliminar(int codigo)
        {
            if (can("eliminar", "Factura"))
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
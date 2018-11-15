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
                CFactura factura = BLLinstance.GetBLL(codigo);

                return View(factura);
            }
        }

        [HttpPost]
        public ActionResult Crear(CFactura factura)
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

        [HttpPost]
        public ActionResult Editar(CFactura factura)
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

        public ActionResult Eliminar(int codigo)
        {
            int success = BLLinstance.EliminarBLL(codigo);
            List<CFactura> listado = BLLinstance.ListarBLL();
            return View("Listado", GetListado());
        }
    }
}
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
    public class VentaController : Controller
    {

        VentaBLL BLLinstance = new VentaBLL();

        public ActionResult Index()
        {
            return View();
        }

        public List<CVenta> GetListado()
        {
            List<CVenta> listado = BLLinstance.ListarBLL();

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
                CVenta venta = new CVenta();
                return View(venta);
            }
            else
            {
                CVenta venta = BLLinstance.GetBLL(codigo);
                return View(venta);
            }
        }

        [HttpPost]
        public ActionResult Crear(CVenta venta)
        {
            try
            {
                int success = BLLinstance.AgregarBLL(
                    venta.usuario,
                    venta.producto,
                    venta.cantidad,
                    //venta.fecha.Date,
                    new DateTime(),
                    venta.contribuyente,
                    venta.cliente,
                    venta.sede,
                    venta.placa,
                    venta.observacion
                );
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            return View("Listado", GetListado());
        }

        [HttpPost]
        public ActionResult Editar(CVenta venta)
        {
            int success = BLLinstance.EditarBLL(
                venta.codigo,
                venta.usuario,
                venta.producto,
                venta.cantidad,
                venta.fecha,
                venta.contribuyente,
                venta.cliente,
                venta.sede,
                venta.placa,
                venta.observacion
                );

            return View("Listado", GetListado());
        }

        public ActionResult Eliminar(int codigo)
        {
            int success = BLLinstance.EliminarBLL(codigo);
            List<CVenta> listado = BLLinstance.ListarBLL();
            return View("Listado", GetListado());
        }

        public void UsuarioSeleccionado(int codigo)
        {

        }
    }
}
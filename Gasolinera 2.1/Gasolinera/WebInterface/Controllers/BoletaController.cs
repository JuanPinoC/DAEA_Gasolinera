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
                CBoleta boleta = BLLinstance.GetBLL(codigo);

                return View(boleta);
            }
        }

        [HttpPost]
        public ActionResult Crear(CBoleta boleta)
        {
            int success = BLLinstance.AgregarBLL(
                boleta.venta,
                boleta.dni,
                boleta.total);

            return View("Listado", GetListado());
        }

        [HttpPost]
        public ActionResult Editar(CBoleta boleta)
        {
            int success = BLLinstance.EditarBLL(
                boleta.codigo,
                boleta.venta,
                boleta.dni,
                boleta.total);

            return View("Listado", GetListado());
        }

        public ActionResult Eliminar(int codigo)
        {
            int success = BLLinstance.EliminarBLL(codigo);
            List<CBoleta> listado = BLLinstance.ListarBLL();
            return View("Listado", GetListado());
        }
    }
}
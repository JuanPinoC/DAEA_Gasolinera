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
    public class ContribuyenteController : Controller
    {

        ContribuyenteBLL BLLinstance = new ContribuyenteBLL();

        public ActionResult Index()
        {
            return View();
        }

        public List<CContribuyente> GetListado()
        {
            List<CContribuyente> listado = BLLinstance.ListarBLL();

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
                CContribuyente contribuyente = BLLinstance.GetBLL(codigo);

                return View(contribuyente);
            }
        }

        [HttpPost]
        public ActionResult Crear(CContribuyente contribuyente)
        {
            int success = BLLinstance.AgregarBLL(
                contribuyente.empresa,
                contribuyente.ruc,
                contribuyente.departamento,
                contribuyente.provincia,
                contribuyente.distrito,
                contribuyente.direccion,
                contribuyente.igv,
                contribuyente.impresora
                );

            return View("Listado", GetListado());
        }

        [HttpPost]
        public ActionResult Editar(CContribuyente contribuyente)
        {
            int success = BLLinstance.EditarBLL(
                contribuyente.codigo,
                contribuyente.empresa,
                contribuyente.ruc,
                contribuyente.departamento,
                contribuyente.provincia,
                contribuyente.distrito,
                contribuyente.direccion,
                contribuyente.igv,
                contribuyente.impresora
                );

            return View("Listado", GetListado());
        }

        public ActionResult Eliminar(int codigo)
        {
            int success = BLLinstance.EliminarBLL(codigo);
            List<CContribuyente> listado = BLLinstance.ListarBLL();
            return View("Listado", GetListado());
        }
    }
}
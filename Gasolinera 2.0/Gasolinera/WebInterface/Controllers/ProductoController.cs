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
    public class ProductoController : Controller
    {

        ProductoBLL BLLinstance = new ProductoBLL();

        public ActionResult Index()
        {
            return View();
        }

        public List<CProducto> GetListado()
        {
            List<CProducto> listado = BLLinstance.ListarBLL();

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
                CProducto producto = BLLinstance.GetBLL(codigo);

                return View(producto);
            }
        }

        [HttpPost]
        public ActionResult Crear(CProducto producto)
        {
            int success = BLLinstance.AgregarBLL(
                producto.nombre,
                producto.precio,
                producto.cantidad,
                producto.medida);

            return View("Listado", GetListado());
        }

        [HttpPost]
        public ActionResult Editar(CProducto producto)
        {
            int success = BLLinstance.EditarBLL(
                producto.codigo,
                producto.nombre,
                producto.precio,
                producto.cantidad,
                producto.medida);

            return View("Listado", GetListado());
        }

        public ActionResult Eliminar(int codigo)
        {
            int success = BLLinstance.EliminarBLL(codigo);
            List<CProducto> listado = BLLinstance.ListarBLL();
            return View("Listado", GetListado());
        }
    }
}
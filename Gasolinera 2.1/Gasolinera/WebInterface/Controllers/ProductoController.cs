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
            return (can("listar", "Producto")) ?
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
                CProducto producto = BLLinstance.GetBLL(codigo);
                return (can("listar", "Producto")) ?
                    View(producto) : Index();
            }
        }

        [HttpPost]
        public ActionResult Crear(CProducto producto)
        {
            if (can("crear", "Producto"))
            {
                int success = BLLinstance.AgregarBLL(
                producto.nombre,
                producto.precio,
                producto.cantidad,
                producto.medida);

                return View("Listado", GetListado());
            }
            else return Index();
        }

        [HttpPost]
        public ActionResult Editar(CProducto producto)
        {

            if (can("editar", "Producto"))
            {
                int success = BLLinstance.EditarBLL(
                producto.codigo,
                producto.nombre,
                producto.precio,
                producto.cantidad,
                producto.medida);

                return View("Listado", GetListado());
            }
            else return Index();
        }

        public ActionResult Eliminar(int codigo)
        {
            if (can("eliminar", "Producto"))
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
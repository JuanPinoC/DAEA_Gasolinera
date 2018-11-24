﻿using System;
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
            return (can("listar", "Contribuyente")) ?
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
                CContribuyente contribuyente = BLLinstance.GetBLL(codigo);
                return (can("listar", "Contribuyente")) ?
                    View(contribuyente) : Index();
            }
        }

        [HttpPost]
        public ActionResult Crear(CContribuyente contribuyente)
        {

            if (can("crear", "Contribuyente"))
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
            else return Index();
        }

        [HttpPost]
        public ActionResult Editar(CContribuyente contribuyente)
        {
            
            if (can("editar", "Contribuyente"))
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
            else return Index();
        }

        public ActionResult Eliminar(int codigo)
        {
            if (can("eliminar", "Contribuyente"))
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
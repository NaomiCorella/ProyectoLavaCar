using ProyectoBancoNacional.LN.ModuloBitacora.Listar;
using ProyectoLavacar.Abstracciones.LN.Interfaces.ModuloBitacora.Listar;
using ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloBitacora.Detalles;
using ProyectoLavacar.AccesoADatos.ModuloServicios.Listar;
using ProyectoLavacar.LN.ModuloBitacora.Detalles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLavacar.Controllers
{
    public class BitacoraController : Controller
    {
        // GET: Bitacora
        IListarBitacoraLN listarBitacoraLN;
        IDetallesLN detallesLN;
        public BitacoraController()
        {
            listarBitacoraLN = new ListarBitacoraLN();
            detallesLN = new DetallesLN();
        }
        public ActionResult Index()
        {
            List<BitacoraDto> bitacoraDtos = listarBitacoraLN.ListarBitacora();
            return View(bitacoraDtos);
        }

        // GET: Bitacora/Details/5
        public ActionResult Details(int id)
        {
            BitacoraDto bitacora = detallesLN.Detalle(id);  
            return View(bitacora);
        }

        // GET: Bitacora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bitacora/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bitacora/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bitacora/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bitacora/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bitacora/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

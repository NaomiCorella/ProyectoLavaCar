using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.LN.ModuloServicios.ListarServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLavacar.Controllers
{
    public class HomeController : Controller
    {
        IListarServiciosLN _listarServicios;
        public HomeController()
        {
            _listarServicios = new ListarServiciosLN();
        }
        public ActionResult Index()
        {
            List<ServiciosDto> lalistaDeReservas = _listarServicios.ListarServicios();
            return View(lalistaDeReservas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
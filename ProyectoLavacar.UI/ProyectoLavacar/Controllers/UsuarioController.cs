using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarEncargo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.ModuloEvaluaciones;
using ProyectoLavacar.LN.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.LN.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.LN.ModuloReservas.ListarEncargo;
using ProyectoLavacar.LN.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.LN.ModuloUsuarios.Crear;
using ProyectoLavacar.LN.ModuloUsuarios.Editar;
using ProyectoLavacar.LN.ModuloUsuarios.Listar;
using ProyectoLavacar.Models;

namespace ProyectoLavacar.Controllers
{
    public class UsuarioController : Controller
    {

        IListarUsuarioLN _listarUsuario;
        IEditarUsuarioLN _editarUsuario;
        IBuscarPorIdLN _buscarPorId;
        Contexto _context;
        IListarDisponiblesLN _listarReservasClientes;
        IListarEncargoLN _listarReservasEmpleado;
        IListarUnicoEmpleadoLN _listarNominadelEmpleado;
        IListarEvaluacionesLN _listarEvaluaciones;
        public UsuarioController()
        {
            _listarReservasClientes = new ListarDisponiblesLN();
            _listarUsuario = new ListarUsuarioLN();
            _editarUsuario = new EditarUsuarioLN();
            _buscarPorId = new BuscarPorIdLN();
            _context = new Contexto();
            _listarReservasEmpleado = new ListarEncargoLN();
            _listarNominadelEmpleado = new ListarUnicoEmpleadoLN();
            _listarEvaluaciones = new ListarEvaluacionesLN();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.Title = "La Listas de finanzas";
            List<UsuariosDto> laListaDeFinanzas = _listarUsuario.ListarUsuarios();
            return View(laListaDeFinanzas);
        }


        // GET: Usuario/Details/5
        public ActionResult Details(string id)
        {


            UsuariosDto Finanzas = _buscarPorId.Detalle(id);
            return View(Finanzas);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public async Task<ActionResult> Create(UsuariosDto modeloDeUsuarios)
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

        // GET: Usuario/Edit/5
        public ActionResult Edit(string id)
        {
            UsuariosDto laFinanza = _buscarPorId.Detalle(id);

            return View(laFinanza);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(UsuariosDto elUsuario)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarUsuario.EditarUsuarios(elUsuario);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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

        public ActionResult CambiarEstado(string id)
        {

            try
            {
                var Usuario = _context.UsuariosTabla.Find(id);
                Usuario.estado = !Usuario.estado;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult Perfil()//usuario
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idUsuario = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            UsuariosDto user = _buscarPorId.Detalle(idUsuario);
            List<ReservaCompleta> reservas =  _listarReservasClientes.Listar(idUsuario); ;
            PerfilUsuario usuario = new PerfilUsuario
            {
                nombre = user.nombre,
                primer_apellido = user.primer_apellido,
                segundo_apellido = user.segundo_apellido,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                reservas = reservas
            };
            return View(usuario);
        }
        public ActionResult MiPerfil()//empleado
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idUsuario = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            UsuariosDto user = _buscarPorId.Detalle(idUsuario);
            List<ReservaCompleta> reservas = _listarReservasEmpleado.Listar(idUsuario); 
            List<UnicoEmpleadoDto> nomina = _listarNominadelEmpleado.ListarNomina(idUsuario);
            PerfilEmpleado usuario = new PerfilEmpleado
            {
                nombre = user.nombre,
                primer_apellido = user.primer_apellido,
                segundo_apellido = user.segundo_apellido,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                reservas = reservas,
                nomina = nomina,
                evaluaciones = _listarEvaluaciones.ListarEvaluaciones(idUsuario),
                puesto = user.puesto,
                turno= user.turno

            };
            return View(usuario);
        }
    }
}

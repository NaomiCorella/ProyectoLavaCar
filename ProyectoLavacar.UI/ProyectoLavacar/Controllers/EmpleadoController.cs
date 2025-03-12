
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.BuscarPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones.Detalles;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Editar;
using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.AccesoADatos.ModuloEvaluaciones.Detalles;
using ProyectoLavacar.LN.ModuloEmpleados.BuscarPorId;
using ProyectoLavacar.LN.ModuloEmpleados.Crear;
using ProyectoLavacar.LN.ModuloEmpleados.Editar;
using ProyectoLavacar.LN.ModuloEmpleados.Listar;
using ProyectoLavacar.LN.ModuloEvaluaciones;
using ProyectoLavacar.LN.ModuloEvaluaciones.Crear;
using ProyectoLavacar.LN.ModuloEvaluaciones.Detalles;
using ProyectoLavacar.LN.ModuloUsuarios.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLavacar.Controllers
{
    public class EmpleadoController : Controller
    {

        IDetallesEvaluacionesLN _detallesEvaluaciones;
        IListarEvaluacionesLN _listarEvaluaciones;
        IListarEmpleadoLN _listarEmpleado;
        IEditarEmpleadoLN _editarEmpleado;
        IBuscarPorIdLN _buscarPorId;
        Contexto _context;
        ICrearEvaluacionLN _crearEvaluacionLN;
        IEditarUsuarioLN _editarUsuario;

        public EmpleadoController()
        {
            _detallesEvaluaciones = new DetallesEvaluacionesLN();
            _listarEmpleado = new ListarEmpleadoLN();
            _editarEmpleado = new EditarEmpleadoLN();
            _buscarPorId = new BuscarPorIdLN();
            _context = new Contexto();
            _listarEvaluaciones = new ListarEvaluacionesLN();
            _crearEvaluacionLN = new CrearEvaluacionLN();
            _editarUsuario = new EditarUsuarioLN();
        }

        // GET: Empleado
        public ActionResult Index()
        {
            ViewBag.Title = "La Listas de Empleados";
            List<UsuariosDto> laListaDeFinanzas = _listarEmpleado.ListarEmpleados().Where(p => p.estado == true).ToList(); ;
            return View(laListaDeFinanzas);
        }
        public ActionResult VerEvaluaciones(string id)
        {
            ViewBag.Title = "Lista De Evaluaciones";
            List<EvaluacionesDto> laListaDeFinanzas = _listarEvaluaciones.ListarEvaluaciones(id);
            return View(laListaDeFinanzas);
        }

        public ActionResult MisEvaluaciones(string id)
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.Title = "Lista De Evaluaciones";
            List<EvaluacionesDto> laListaDeFinanzas = _listarEvaluaciones.ListarEvaluaciones(idEmpleado);
            return View(laListaDeFinanzas);
        }

        public ActionResult DetallesEvaluaciones(int id)
        {
            EvaluacionesDto Finanzas = _detallesEvaluaciones.Detalle(id);
            return View(Finanzas);
        }


        // GET: Empleado/Details/5
        public ActionResult Details(string id)
        {
            UsuariosDto Finanzas = _buscarPorId.Detalle(id);
            return View(Finanzas);
        }

        // GET: Empleado/Create
        public ActionResult RegistroDeEvaluaciones()
        {
            return View();
        }

        // POST: Empleado/Create
        [HttpPost]
        public async Task<ActionResult> RegistroDeEvaluaciones(EvaluacionesDto modelo)
        {
            try
            {
                int cantidadDeDatosGuardados = await _crearEvaluacionLN.Crear(modelo);

                return RedirectToAction("VerEvaluaciones");
               

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        [HttpPost]
        public async Task<ActionResult> Create(UsuariosDto modeloDeEmpleado)
        {
            try
            {

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }


        // GET: Empleado/Edit/5
        public ActionResult Edit(string id)
        {
            UsuariosDto laFinanza = _buscarPorId.Detalle(id);

            return View(laFinanza);
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(UsuariosDto elEmpleado)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarEmpleado.EditarEmpleados(elEmpleado);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleado/Delete/5
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

        public async Task<ActionResult> CambiarEstado(string id)
        {

            try
            {
                var Usuario = _context.UsuariosTabla.Find(id);
                Usuario.estado = !Usuario.estado;
                _context.SaveChanges();
                UsuariosDto userEliminado = new UsuariosDto
                {
                    Id = Usuario.Id,
                    nombre = Usuario.nombre,
                    cedula = Usuario.cedula,
                    Email = "userEliminado@gmail.com",
                    estado = false,
                    numeroCuenta = Usuario.numeroCuenta,
                    PhoneNumber = "noValido",
                    primer_apellido = Usuario.primer_apellido,
                    puesto = Usuario.puesto,
                    segundo_apellido = Usuario.segundo_apellido,
                    turno = Usuario.turno
                };
                int cantidadDeDatosEditados = await _editarUsuario.EditarUsuarios(userEliminado);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }
        }
    }
}


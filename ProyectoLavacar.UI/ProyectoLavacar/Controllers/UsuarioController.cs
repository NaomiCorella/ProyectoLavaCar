using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.IngresarHoras;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.ListarDisponibles;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.RegistroHoraEntrada;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.RegistroHoraSalida;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarEncargo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Remover;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.ModuloCompra.ListarDisponible;
using ProyectoLavacar.LN.ModuloEvaluaciones;
using ProyectoLavacar.LN.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.LN.ModuloNomina.RegistroHoraEntrada;
using ProyectoLavacar.LN.ModuloNomina.RegistroHoraSalida;
using ProyectoLavacar.LN.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.LN.ModuloReservas.ListarEncargo;
using ProyectoLavacar.LN.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.LN.ModuloUsuarios.Crear;
using ProyectoLavacar.LN.ModuloUsuarios.Editar;
using ProyectoLavacar.LN.ModuloUsuarios.Listar;
using ProyectoLavacar.LN.ModuloUsuarios.Remover;
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
        IRegistroHoraEntradaLN _registroHoraEntrada;
        IRegistroHoraSalidaLN _registroHoraSalida;
        IRemoverLN _remover;
        IListarDisponibleLN _listarCompraCliente;
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
            _registroHoraEntrada = new RegistrarHoraEntradaLN();
            _registroHoraSalida = new RegistroHoraSalidaLN();
            _remover = new RemoverLN();
            _listarCompraCliente = new ListarDisponibleLN();
        }

        // GET: Usuario
        [Authorize(Roles = "Administrador")]

        public ActionResult Index()
        {
            ViewBag.Title = "La Listas de finanzas";
            List<EmpleadoDto> laListaDeFinanzas = _listarUsuario.ListarUsuarios().Where(p => p.estado == true).ToList();
            return View(laListaDeFinanzas);
        }


        // GET: Usuario/Details/5

        public ActionResult Details(string id)
        {


            EmpleadoDto Finanzas = _buscarPorId.Detalle(id);
            return View(Finanzas);
        }


    

        public ActionResult Edit(string id)
        {
            EmpleadoDto laFinanza = _buscarPorId.Detalle(id);

            return View(laFinanza);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(EmpleadoDto elUsuario)
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

        public async Task<ActionResult> CambiarEstado(string id)
        {

            try
            {
                var Usuario = _context.UsuariosTabla.Find(id);
                Usuario.estado = !Usuario.estado;
                _context.SaveChanges();
                EmpleadoDto userEliminado = new EmpleadoDto
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
                    turno = Usuario.turno,
                    PasswordHash = "novalido"
                };
                int cantidadDeDatosEditados = await _remover.EditarUsuarios(userEliminado); return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }

        }
        [Authorize(Roles = "Usuario")]

        public ActionResult Perfil()//usuario
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idUsuario = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            EmpleadoDto user = _buscarPorId.Detalle(idUsuario);
            List<ReservaCompleta> reservas =  _listarReservasClientes.Listar(idUsuario); 
            List<CompraAdminDto> compras = _listarCompraCliente.Listar(idUsuario);
            PerfilUsuario usuario = new PerfilUsuario
            {
                id = user.Id,
                nombre = user.nombre,
                primer_apellido = user.primer_apellido,
                segundo_apellido = user.segundo_apellido,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                reservas = reservas,
                compras = compras
            };
            return View(usuario);
        }
        [Authorize(Roles = "Empleado,Administrador")]

        public ActionResult MiPerfil()//empleado
        {
        
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idUsuario = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            EmpleadoDto user = _buscarPorId.Detalle(idUsuario);
            List<ReservaCompleta> reservas = _listarReservasEmpleado.Listar(idUsuario); 
            List<UnicoEmpleadoDto> nomina = _listarNominadelEmpleado.ListarNomina(idUsuario);
            var ultimoRegistro = _context.RegistroHorasTabla
                .Where(r => r.idEmpleado == idUsuario)
                .OrderByDescending(r => r.HoraEntrada)
                .FirstOrDefault();

            ViewBag.estadoRegistro = ultimoRegistro?.estado;


            DateTime fecha = DateTime.Now;
  
            if (ultimoRegistro != null && ultimoRegistro.HoraSalida.Day == fecha.Day)
            {
                ViewBag.ValidacionRegistro = true;
            }
            else
            {
                ViewBag.ValidacionRegistro = false;
            }


            PerfilEmpleado usuario = new PerfilEmpleado
            {
                id = user.Id,
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

        public async Task<ActionResult> RegistrarHoraEntrada()
        {

            try
            {
                var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
                string idUsuario = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                RegistroHorasDto hora = new RegistroHorasDto
                {
                    idRegistro=0,
                    HoraSalida = "Hora No Registrada",
                    idEmpleado = idUsuario,
                    HoraEntrada = DateTime.Now.ToString(),
                    estado = false,
                    totalHoras = 0
                };  
                int cantidadDeDatosEditados = await _registroHoraEntrada.RegistrarHoraEntrada(hora);
                return RedirectToAction("MiPerfil");
            }
            catch (Exception ex)
            {

                return RedirectToAction("MiPerfil");
            }
        }


        public async Task<ActionResult> RegistrarHoraSalida()
        {

            try
            {
                var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
                string idUsuario = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                var ultimoRegistro = _context.RegistroHorasTabla
           .Where(r => r.idEmpleado == idUsuario)
           .OrderByDescending(r => r.HoraEntrada)
           .FirstOrDefault();

                RegistroHorasDto hora = new RegistroHorasDto
                {
                    idRegistro = ultimoRegistro.idRegistro,
                    HoraSalida = DateTime.Now.ToString(),
                    idEmpleado = idUsuario,
                    HoraEntrada = ultimoRegistro.HoraEntrada.ToString(),
                    estado = true,
                    totalHoras=0
                };
                int cantidadDeDatosEditados = await _registroHoraSalida.RegistroHoraSalida(hora);
                return RedirectToAction("MiPerfil");
            }
            catch (Exception ex)
            {

                return RedirectToAction("MiPerfil");
            }
        }
    }
}

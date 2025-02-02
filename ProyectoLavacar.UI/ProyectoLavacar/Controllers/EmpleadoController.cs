
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.BuscarPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.ModuloEmpleados.BuscarPorId;
using ProyectoLavacar.LN.ModuloEmpleados.Crear;
using ProyectoLavacar.LN.ModuloEmpleados.Editar;
using ProyectoLavacar.LN.ModuloEmpleados.Listar;
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

        
        
            IListarEmpleadoLN _listarEmpleado;
            IEditarEmpleadoLN _editarEmpleado;
            IBuscarPorIdLN _buscarPorId;
             Contexto _context;

        public EmpleadoController()
            {

                _listarEmpleado = new ListarEmpleadoLN();
                _editarEmpleado = new EditarEmpleadoLN();
                _buscarPorId = new BuscarPorIdLN();
                _context = new Contexto();
        }

            // GET: Empleado
            public ActionResult Index()
            {
                ViewBag.Title = "La Listas de Empleados";
                List<UsuariosDto> laListaDeFinanzas = _listarEmpleado.ListarEmpleados();
                return View(laListaDeFinanzas);
            }

            // GET: Empleado/Details/5
            public ActionResult Details(string id)
            {
                UsuariosDto Finanzas = _buscarPorId.Detalle(id);
                return View(Finanzas);
            }

            // GET: Empleado/Create
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
    }
    }


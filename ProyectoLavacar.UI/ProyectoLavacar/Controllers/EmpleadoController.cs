
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.BuscarPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
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

        
            ICrearEmpleadoLN _crearEmpleado;
            IListarEmpleadoLN _listarEmpleado;
            IEditarEmpleadoLN _editarEmpleado;
            IBuscarPorIdLN _buscarPorId;

            public EmpleadoController()
            {
                _crearEmpleado = new CrearEmpleadoLN();
                _listarEmpleado = new ListarEmpleadoLN();
                _editarEmpleado = new EditarEmpleadoLN();
                _buscarPorId = new BuscarPorIdLN();
            }

            // GET: Empleado
            public ActionResult Index()
            {
                ViewBag.Title = "La Listas de Empleados";
                List<EmpleadosDto> laListaDeFinanzas = _listarEmpleado.ListarEmpleados();
                return View(laListaDeFinanzas);
            }

            // GET: Empleado/Details/5
            public ActionResult Details(int id)
            {
                EmpleadosDto Finanzas = _buscarPorId.Detalle(id);
                return View(Finanzas);
            }

            // GET: Empleado/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Empleado/Create
            [HttpPost]
            public async Task<ActionResult> Create(EmpleadosDto modeloDeEmpleado)
            {
                try
                {
                    // TODO: Add insert logic here
                    int cantidadDeDatosGuardados = await _crearEmpleado.RegistrarEmpleado(modeloDeEmpleado);
                    return RedirectToAction("Index");

                }
                catch
                {
                    return View();
                }
            }

            // GET: Empleado/Edit/5
            public ActionResult Edit(int id)
            {
                EmpleadosDto laFinanza = _buscarPorId.Detalle(id);

                return View(laFinanza);
            }

            // POST: Empleado/Edit/5
            [HttpPost]
            public async Task<ActionResult> Edit(EmpleadosDto elEmpleado)
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
        }
    }


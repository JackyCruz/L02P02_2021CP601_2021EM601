using L02P02_2021CP601_2021EM601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace L02P02_2021CP601_2021EM601.Controllers
{
    public class ClientesController : Controller
    {
        private readonly clientesDbContext _clientesDbContext;

        public ClientesController(clientesDbContext clientesDbContext)
        {
            _clientesDbContext = clientesDbContext;
        }
        public IActionResult Index()
        {
            //Tipo clientes
            var listaTipoDeclientes = (from m in _clientesDbContext.departamentos
                                      select m).ToList(); 
			ViewData["listadoDepartamento"] = new SelectList(listaTipoDeclientes, "id", "departamento");

			//Estado de clientes
			var listaEstadoDeclientes = (from p in _clientesDbContext.puestos
                                        select p).ToList(); 

			ViewData["listadoDePuestos"] = new SelectList(listaEstadoDeclientes, "id", "puesto");

			//Extraer listado de equipos
			var listadoDeclientes = (from e in _clientesDbContext.clientes
                                    join m in _clientesDbContext.departamentos on e.id equals m.id
                                    select new
                                    {
                                        nombre = e.nombre,
                                        descripcion = e.direccion,
                                        marca_id = e.id,
                                        marca_nombre = m.departamento
                                    }).ToList();
            ViewData["ListadoClientes"] = listadoDeclientes;

            return View();
        }

        public IActionResult CrearEquipos(clientes nuevoCliente)
        {
            _clientesDbContext.Add(nuevoCliente);
            _clientesDbContext.SaveChanges();

            return View();
        }
    }
}

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

			//Extraer listado de clientes
			var listadoDeclientes = (from c in _clientesDbContext.clientes
                                    join d in _clientesDbContext.departamentos on c.id_departamento equals d.id
									 join p in _clientesDbContext.puestos on c.id_puesto equals p.id
									 select new
                                    {
                                        Nombre = c.nombre,
										Apellido = c.apellido,
										Email = c.email,
                                        Direccion = c.direccion,
                                        departamentos = d.departamento,
                                        Genero = c.genero,
                                        Puesto = p.puesto

                                    }).ToList();
            ViewData["ListadoClientes"] = listadoDeclientes;

            return View();
        }

        public IActionResult Crearusuarios(clientes nuevoCliente)
        {
            _clientesDbContext.Add(nuevoCliente);
            _clientesDbContext.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}

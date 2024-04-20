using L02P02_2021AR601_2021MM656.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace L02P02_2021AR601_2021MM656.Controllers
{
    public class HomeController : Controller

    {

        private readonly UsuariosDbContext _UsuariosDbContext;

        public HomeController(UsuariosDbContext UsuariosDbContext)
        {
            _UsuariosDbContext = UsuariosDbContext;

        }
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Aquí estamos invocando el listado de puestos de la tabla puestos
            var listaDePuestos = (from m in _UsuariosDbContext.puestos
                                 select m).ToList();
            ViewData["listadoDePuestos"] = new SelectList(listaDePuestos, "id", "puesto", "estado ", "created_at");

            //Aquí estamos invocando el listado de departamentos de la tabla departamentos
            var listaDeDepartamentos = (from m in _UsuariosDbContext.puestos
                                  select m).ToList();
            ViewData["listadoDeDepartamentos"] = new SelectList(listaDeDepartamentos, "id", "departamento", "estado ", "created_at");

            //Aquí estamos solicitando el listado de los Departamentos en la bd
            var listadoDeDeDepartamentos = (from e in _UsuariosDbContext.departamentos
                                    join m in _UsuariosDbContext.clientes on e.id equals m.id
                                    select new
                                    {
                                        departamento = e.departamento,
                                        estado= e.estado,
                                        id= e.id,
                                        nombre = m.nombre
                                    }).ToList();
            ViewData["listadoDeDepartamentos"] = listadoDeDeDepartamentos;

            //Aquí listaremos el listado de tipos de equipos
            var listaDeTipoDeDepartamentos = (from m in _UsuariosDbContext.clientes
                                      select m).ToList();
            ViewData["listadoDeDeDepartamentos"] = new SelectList(listaDeTipoDeDepartamentos, "id_tipo_equipo", "descripcion");

            //Listado de los tipos de estados de equipo
            var listaDeEstados = (from m in _UsuariosDbContext.clientes
                                  select m).ToList();
            ViewData["listadoDeEstados"] = new SelectList(listaDeEstados, "id_estados_equipo", "descripcion");


            return View();
        }

        //Función para guardar nuevos equipos
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //Función para guardar nuevos usuariosDB
        public IActionResult CrearEquipos(usuariosDB nuevoUsuariosDB)
        {
            _UsuariosDbContext.Add(nuevoUsuariosDB);
            _UsuariosDbContext.SaveChanges();

            return RedirectToAction("Index");

        }

    }


}



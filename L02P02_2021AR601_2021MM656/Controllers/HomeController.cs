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
            //Aquí estamos invocando el listado de marcas de la tabla marcas
            var listaDePuestos = (from m in _UsuariosDbContext.
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            //Aquí estamos solicitando el listado de los equipos en la bd
            var listadoDeEquipos = (from e in _equiposDbContext.equipos
                                    join m in _equiposDbContext.marcas on e.id_marca equals m.id_marcas
                                    select new
                                    {
                                        nombre = e.nombre,
                                        descripcion = e.descripcion,
                                        id_marca = e.id_marca,
                                        marca_nombre = m.nombre_marca
                                    }).ToList();
            ViewData["listadoEquipo"] = listadoDeEquipos;

            //Aquí listaremos el listado de tipos de equipos
            var listaDeTipoEquipos = (from m in _equiposDbContext.tipo_equipo
                                      select m).ToList();
            ViewData["listadoDeTipoEquipos"] = new SelectList(listaDeTipoEquipos, "id_tipo_equipo", "descripcion");

            //Listado de los tipos de estados de equipo
            var listaDeEstados = (from m in _equiposDbContext.estados_equipo
                                  select m).ToList();
            ViewData["listadoDeEstados"] = new SelectList(listaDeEstados, "id_estados_equipo", "descripcion");


            return View();
        }

        //Función para guardar nuevos equipos
    }

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

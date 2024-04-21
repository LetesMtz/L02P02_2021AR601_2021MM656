using L02P02_2021AR601_2021MM656.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()

        {
            
            //Aquí estamos invocando el listado de puestos de la tabla puestos
            var listaDePuestos = (from m in _UsuariosDbContext.puestos
                                 select m).ToList();
            ViewData["listadoDePuestos"] = new SelectList(listaDePuestos, "id", "puesto");

            //Aquí estamos invocando el listado de departamentos de la tabla departamentos
            var listaDeDepartamentos = (from m in _UsuariosDbContext.departamentos
                                  select m).ToList();
            ViewData["listadoDeDepartamentos"] = new SelectList(listaDeDepartamentos, "id", "departamento");



            //Aquí estamos solicitando el listado de los Departamentos en la bd
            var listadoDeDeClientes = (from c in _UsuariosDbContext.clientes
                                       join d in _UsuariosDbContext.departamentos on c.id_departamento equals d.id
                                       join p in _UsuariosDbContext.puestos on c.id_puesto equals p.id
                                       select new
                                       {
                                           id = c.id,

                                           nombre = c.nombre,
                                           apellido = c.apellido,
                                           email = c.email,
                                           direccion = c.direccion,
                                           genero = c.genero,
                                           id_departamento = d.departamento,
                                           id_puesto = p.puesto,
                                           estado_registro = c.estado_registro,
                                           created_at = c.created_at,
                                           updated_at = c.updated_at

                                       }).ToList();
            ViewData["listadoDeClientes"] = listadoDeDeClientes;



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

        public IActionResult CreateClientes(clientes nuevoCliente)
        {
            _UsuariosDbContext.Add(nuevoCliente);
            _UsuariosDbContext.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumnos = await _UsuariosDbContext.clientes.FindAsync(id);
            if (alumnos != null)
            {
                _UsuariosDbContext.clientes.Remove(alumnos);
            }

            await _UsuariosDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }


}



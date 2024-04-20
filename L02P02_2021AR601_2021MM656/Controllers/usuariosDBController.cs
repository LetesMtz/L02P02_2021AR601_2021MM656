using L02P02_2021AR601_2021MM656.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace L02P02_2021AR601_2021MM656.Controllers
{


    public class usuariosDBController : Controller
    {
        private readonly UsuariosDbContext _UsuariosDbContext;

        public usuariosDBController(UsuariosDbContext UsuariosDbContext)
        {
            _UsuariosDbContext = UsuariosDbContext;
        }

        public IActionResult Index()
        {
                                 select m).ToList();
                                    }).ToList();
                                      select m).ToList();
            return View();
        }
            return View();
    }   
}
}
}
}
}

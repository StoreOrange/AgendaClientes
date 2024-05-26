using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Clientes.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Clientes.Controllers

{

    public class ClientesController : Controller
    {

        private readonly ClientesContext _context;
        public ClientesController(ClientesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Clientes.ToList());
        }

    }

}

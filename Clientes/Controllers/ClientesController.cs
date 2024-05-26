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


        public IActionResult Crear()
        {
            return View();
        }

  [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Nombres,Apellidos,Correo,Dirección,Compañía,Nota,FechaDeRegistro")] Clientes.Models.Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("ID,Nombres,Apellidos,Correo,Dirección,Compañía,Nota,FechaDeRegistro")] Clientes.Models.Clientes cliente)
        {
            if (id != cliente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.ID == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
{
    var cliente = await _context.Clientes.FindAsync(id);
    if (cliente == null)
    {
        return NotFound();
    }

    _context.Clientes.Remove(cliente);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}


        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.ID == id);
        }
    }
}
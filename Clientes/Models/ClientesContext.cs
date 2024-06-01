using Microsoft.EntityFrameworkCore;

namespace Clientes.Models
{
    public class ClientesContext : DbContext
    {
        public ClientesContext(DbContextOptions<ClientesContext> opciones)
        :  base(opciones)
        {
             
        }

        public DbSet<Clientes> Clientes {get; set;}

        public DbSet<Empleado> Empleados { get; set; } 

         public async Task<List<Empleado>> GetEmpleadosByNombre(string nombre)
         {
            return await Empleados.FromSqlRaw("EXEC FiltrarEmpleados @Nombres={0}", nombre).ToListAsync();
         }
        
    }
}
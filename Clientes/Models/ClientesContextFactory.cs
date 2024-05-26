using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Clientes.Models
{
    public class ClientesContextFactory : IDesignTimeDbContextFactory<ClientesContext>
    {
        public ClientesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClientesContext>();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ClientesContext");
            optionsBuilder.UseSqlServer(connectionString);

            return new ClientesContext(optionsBuilder.Options);
        }
    }
}

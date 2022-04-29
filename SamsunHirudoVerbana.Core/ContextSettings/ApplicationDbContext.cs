using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamsunHirudoVerbana.Data;

namespace SamsunHirudoVerbana.Core.ContextSettings
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var settings = new AppSettings();
            //optionsBuilder.UseSqlServer("Data Source=OĞUZ;Initial Catalog=CoreDb;Integrated Security=True;");
            optionsBuilder.UseSqlServer(settings.sqlConnectionString);
        }
    }
}

using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost; database=LenaDB; trusted_connection=true; trustservercertificate=true; multipleactiveresultsets=true;");
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Form> Forms { get; set; }
    }
}

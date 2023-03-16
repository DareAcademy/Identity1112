
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Session1112Identity.Models;

namespace Session1112Identity.data
{
    public class HRContext:IdentityDbContext<ApplicationUsers>
    {
        private readonly IConfiguration configuration;

        public HRContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public DbSet<Employee> employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("HRConnection"));
            base.OnConfiguring(optionsBuilder);
        }


    }
}

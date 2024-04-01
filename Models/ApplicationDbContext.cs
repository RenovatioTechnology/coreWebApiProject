using Microsoft.EntityFrameworkCore;

namespace coreWebApiProject.Models
{
    public class ApplicationDbContext:DbContext
    {
        // communicate with database entity
        public DbSet<Product> Products {  get; set; }

        // Then create the constructor to inject Dbcontext options, and pass it to the base class itself
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        // So all set, follow by migration with the use of PMC 
        // add-migration InitialCreate
        // update-database

    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebApplicationStore.Models.Metadata;

namespace WebApplicationStore.Models.Contexts
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) 
            :base(dbContextOptions)
        {

        }
        public DbSet<Employee> employees { get; set; }
    } 
}

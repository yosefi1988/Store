﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebApplicationStore.Controllers.Classroom;
using WebApplicationStore.Models.Metadata;
using WebApplicationStore.Models.StoreDbModels;

namespace WebApplicationStore.Models.Contexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions dbContextOptions) 
            :base(dbContextOptions)
        {

        }
        public DbSet<Employee> employees { get; set; }
    } 
}

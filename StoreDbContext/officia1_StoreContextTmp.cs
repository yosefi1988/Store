using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplicationStore.Models.StoreDbModels;

namespace WebApplicationStore.StoreDbContext
{
    public partial class officia1_StoreContextTmp : DbContext
    {
        public officia1_StoreContextTmp()
        {
        }

        public officia1_StoreContextTmp(DbContextOptions<officia1_StoreContextTmp> options)
            : base(options)
        {
        }

    }
}

using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Company { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
    }
}

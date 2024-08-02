using System.ComponentModel.DataAnnotations;

namespace WebApplicationStore.Models.Metadata
{
    public class Employee
    { 
        public Employee() { }   
        public Employee(int id) { }

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Company { get; set; } 
        public string? Email { get; set; }
        public string? Description { get; set; }
         
    }
}



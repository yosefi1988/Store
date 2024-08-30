using System.ComponentModel.DataAnnotations;

namespace WebApplicationStore.Models.ViewModels
{
    public class UserViewModel
    {
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
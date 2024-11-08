using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationStore.Models.StoreDbModels;

namespace WebApplicationStore.Models.ViewModels
{
    public class CreateAddressModelView
    {
        [ValidateNever]
        public IEnumerable<SelectListItem>? countryDropdown { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? stateDropdown { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? cityDropdown { get; set; }

        public int? SelectedCountryId { get; set; }  // یا استفاده از نوع داده مناسب بر اساس ID
        public SdAddress sdAddress { get; set; }
        public String IdentityUserName { get; set; }

        [ValidateNever]
        public int? SelectedStateId { get; set; } 
    }
}

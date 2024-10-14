using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationStore.Models.StoreDbModels;
using WebApplicationStore.Models.ViewModels.CustomModels;

namespace WebApplicationStore.Models.ViewModels
{
    public class PaymentModelView
    {
        public int? UserId { get; set; }
        public int? SelectedBasketId { get; set; }
        //public int? CityId { get; set; }
        public IEnumerable<SelectListItemCustom>? sdAddressDropdown { get; set; }
        public string? DiscountCode { get; set; }

        public List<ViewUserBasketsObject> ListBasketsObjects { get; set; }

        //public IEnumerable<SelectListItem>? countryDropdown { get; set; }
        //public IEnumerable<SelectListItem>? stateDropdown { get; set; }
        //public SdAddress sdAddress { get; set; }

        //public int? SelectedCountryId { get; set; }  // یا استفاده از نوع داده مناسب بر اساس ID
        //public String IdentityUserName { get; set; }
        //public int? SelectedStateId { get; set; } 
        //public IEnumerable<SelectListItem>? addressDropdown { get; set; }

    }
}

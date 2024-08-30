using WebApplicationStore.Models.StoreDbModels;

namespace WebApplicationStore.Models.ViewModels.CustomModels
{
    public class ViewUserBasketCustom : ViewUserBasket
    {
        public ViewUserBasketCustom() { }
        public bool isSelected { get; set; }
    }
}

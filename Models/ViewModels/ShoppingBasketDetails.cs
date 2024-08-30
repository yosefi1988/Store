using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationStore.Models.StoreDbModels;
using WebApplicationStore.Models.ViewModels.CustomModels;

namespace WebApplicationStore.Models.ViewModels
{
    public class ShoppingBasketDetails
    {
        [Key]
        public int Id { get; set; } // Change access modifier to public
        public List<ViewUserBasketCustom>? baskets { get; set; }
        public List<ViewUserBasketsObject>? basketObjects { get; set; }

    }

}

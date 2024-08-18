using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationStore.Models.StoreDbModels;

namespace WebApplicationStore.Models.ViewModels
{
    public class ShopingBasket
    {
        [Key]
        public int Id { get; set; } // Change access modifier to public
        public List<ViewUserBasket>? baskets { get; set; }

    }

}

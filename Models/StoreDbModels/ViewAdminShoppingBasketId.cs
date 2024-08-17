using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewAdminShoppingBasketId
    {
        public int Id { get; set; }
        public int ShoppingBasketId { get; set; }
        public string? BasketType { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
    }
}

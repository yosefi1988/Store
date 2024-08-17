using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewUserBasket
    {
        public int ShoppingBasketId { get; set; }
        public int? UserId { get; set; }
        public int? BasketStatusId { get; set; }
        public string? BasketStatus { get; set; }
    }
}

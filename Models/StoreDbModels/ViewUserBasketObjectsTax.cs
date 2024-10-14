using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewUserBasketObjectsTax
    {
        public int ShoppingBasketId { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        public string? Title { get; set; }
        public int? TaxPercentage { get; set; }
        public int? Price { get; set; }
        public int? Count { get; set; }
        public int? TotalPriceWithTax { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewUserBasketsObject
    {
        public int Id { get; set; }
        public int ShoppingBasketId { get; set; }
        public int? UserId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductCode { get; set; }
        public string? Tax { get; set; }
        public int? TaxPercentage { get; set; }
        public int? PercentInterest { get; set; }
        public int? PercentWages { get; set; }
        public string? Color { get; set; }
        public string? ColorCode { get; set; }
        public int? Discount { get; set; }
        public int? RemainingCount { get; set; }
        public int ProductChargePropertiesId { get; set; }
        public int? ProductChargeId { get; set; }
        public int? ProductId { get; set; }
        public int? Price { get; set; }
        public int? OldPrice { get; set; }
        public int? Count { get; set; }
        public DateTime? AddInToBasketDate { get; set; }
        public int? BasketStatusId { get; set; }
        public string? BasketStatus { get; set; }
    }
}

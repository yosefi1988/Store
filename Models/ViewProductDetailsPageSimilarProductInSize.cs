﻿using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class ViewProductDetailsPageSimilarProductInSize
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? BuyInvoiceNumber { get; set; }
        public int? PercentInterest { get; set; }
        public int? PercentWages { get; set; }
        public int? Discount { get; set; }
        public int? RemainingCount { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
    }
}

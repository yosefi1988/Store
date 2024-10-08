﻿using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewSiteProductDetailsSize
    {
        public int Id { get; set; }
        public int ProductChargePropertiesId { get; set; }
        public string? SizeTitle { get; set; }
        public string? SizeDescription { get; set; }
        public string? SizeValue { get; set; }
        public string? SizeValueDescription { get; set; }
    }
}

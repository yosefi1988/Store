using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationStore.Models.StoreDbModels;

namespace WebApplicationStore.Models.ViewModels
{
    public class ProductDetails
    {
        [Key]
        public int Id { get; set; } // Change access modifier to public
        public ViewSiteProductDetail? product { get; set; }

        public List<ViewSiteProductDetailsColor>? productDetails_Colors { get; set; }
        public List<ViewSiteProductDetailsSize>? productDetailsSize { get; set; }
        public List<ViewSiteProductDetailsSimilarProductInSize>? similarProductInSize { get; set; }
        public List<ViewSiteProductDetailsSendPrice>? productSendPrice { get; set; }
        public List<ViewSiteProductDetailsImage>? productImages { get; set; }

    }

}

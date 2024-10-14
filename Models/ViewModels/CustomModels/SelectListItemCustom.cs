using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplicationStore.Models.ViewModels.CustomModels
{
    public class SelectListItemCustom : SelectListItem
    {
        public string Meta { get; set; }
        public string Meta2 { get; set; }
        // سازنده پیش‌فرض
        public SelectListItemCustom()
        {
        }

        // سازنده با پارامترها
        public SelectListItemCustom(string text, string value, string meta)
            : base()
        {
            Text = text;
            Value = value;
            Meta = meta;
            Meta2 = null;
        }        // سازنده با پارامترها
        public SelectListItemCustom(string text, string value, string meta, string meta2)
            : base()
        {
            Text = text;
            Value = value;
            Meta = meta;
            Meta2 = meta2;
        }
    }
}

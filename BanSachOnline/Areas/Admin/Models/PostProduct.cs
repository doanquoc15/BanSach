using ModelFE.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanSachOnline.Areas.Admin.Models
{
    public class PostProduct
    {
        public PostProduct()
        {
            Image = "~/Assets/admin/images/0001.jpg";
        }
 
        public string IDPro { get; set; }

        public string IDCate { get; set; }
        public string Name { get; set; }

        public decimal? UnitCost { get; set; }

        public int? Quantity { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
        public virtual Category Category { get; set; }
   
        public HttpPostedFileBase UploadImage { get; set; }
    }
}
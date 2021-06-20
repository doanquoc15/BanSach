 

namespace ModelFE.EF
{
    using System;
    using System.Web;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;
    using System.IO;
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Image = "~/Assets/admin/images/0001.jpg";
        }
        [Key]
        [StringLength(10)]
        [DisplayName("Mã sản phẩm")]
        public string IDPro { get; set; }

        [StringLength(10)]
        [DisplayName("Mã thể loại")]
        public string IDCate { get; set; }

        [StringLength(50)]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }
        [DisplayName("Giá bán")]
        public decimal? UnitCost { get; set; }
        [DisplayName("SL hiện còn")]
        public int? Quantity { get; set; }
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [DisplayName("Mô tả")]
        [StringLength(50)]
        public string Description { get; set; }

        [DisplayName("Trạng thái SP")]
        [StringLength(40)]
        public string Status { get; set; }
        public virtual Category Category { get; set; }
    }
}

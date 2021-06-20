using ModelFE.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFE.DAO
{
    public class ProductCategoryDao
    {
        DoanNgocPhuQuocContext db = null;
        public ProductCategoryDao()
        {
            db = new DoanNgocPhuQuocContext();
        }

        public List<Product> ListAll()
        {
            return db.Product.OrderBy(x => x.UnitCost).ToList();
        }
    }
}

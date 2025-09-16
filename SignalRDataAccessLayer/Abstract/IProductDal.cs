using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalREntityLayer.Entities;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();

        decimal ProductPriceAvg();

        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
    }
}

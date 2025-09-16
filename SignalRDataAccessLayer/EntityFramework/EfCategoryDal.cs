using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;

namespace SignalRDataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveCategortCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Where(c => c.CategoryStatus == true).Count();
        }

        public int CategortCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Count();
        }

        public int PassiveCategortCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Where(c => c.CategoryStatus == false).Count();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;

namespace SignalRDataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByTableNumber(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Where(x => x.TableID == id).Include(y=>y.Product).ToList();
            return values;
        }
    }
}

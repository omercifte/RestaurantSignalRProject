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
    public class EfOrderDetailDal:GenericRepository<OrderDetail>,IOrderDetailDal
    {
        public EfOrderDetailDal(SignalRContext context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalREntityLayer.Entities;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;

namespace SignalRDataAccessLayer.EntityFramework
{
    public class EfTableDal:GenericRepository<Table>,ITableDal
    {
        public EfTableDal(SignalRContext context) : base(context)
        {

        }

        public void ChangeTableStatusToFalse(int id)
        {
            using var context = new SignalRContext();
            var values=context.Tables.Where(x => x.TableID == id).FirstOrDefault();
            values.TableStatus = false;
            context.SaveChanges();
        }

        public void ChangeTableStatusToTrue(int id)
        {
            using var context = new SignalRContext();
            var values = context.Tables.Where(x => x.TableID == id).FirstOrDefault();
            values.TableStatus = true;
            context.SaveChanges();
        }

        public int TableCount()
        {
            using var context = new SignalRContext();
            return context.Tables.Count();
        }
    }
}

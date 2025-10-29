using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalREntityLayer.Entities;

namespace SignalRDataAccessLayer.Abstract
{
    public interface ITableDal:IGenericDal<Table>
    {
        int TableCount();
        void ChangeTableStatusToTrue(int id);
        void ChangeTableStatusToFalse(int id);
    }
}

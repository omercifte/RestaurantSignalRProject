using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalREntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;

namespace SignalRBusinessLayer.Concrete
{
    public class TableManager : ITableService
    {
        private readonly ITableDal _tableDal;

        public TableManager(ITableDal tableDal)
        {
            _tableDal = tableDal;
        }

        public void TAdd(Table entity)
        {
            _tableDal.Add(entity);
        }

        public void TChangeTableStatusToFalse(int id)
        {
            _tableDal.ChangeTableStatusToFalse(id);
        }

        public void TChangeTableStatusToTrue(int id)
        {
            _tableDal.ChangeTableStatusToTrue(id);
        }

        public void TDelete(Table entity)
        {
            _tableDal.Delete(entity);
        }

        public Table TGetByID(int id)
        {
            return _tableDal.GetByID(id);
        }

        public List<Table> TGetListAll()
        {
            return _tableDal.GetListAll();
        }

        public int TTableCount()
        {
            return _tableDal.TableCount();
        }

        public void TUpdate(Table entity)
        {
            _tableDal.Update(entity);
        }
    }
}

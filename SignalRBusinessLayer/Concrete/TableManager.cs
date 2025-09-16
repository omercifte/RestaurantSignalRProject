using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            throw new NotImplementedException();
        }

        public void TDelete(Table entity)
        {
            throw new NotImplementedException();
        }

        public Table TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Table> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public int TTableCount()
        {
            return _tableDal.TableCount();
        }

        public void TUpdate(Table entity)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;

namespace SignalRBusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int TCategortCount()
        {
            return _categoryDal.CategortCount();
        }

        public void TAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category TGetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> TGetListAll()
        {
            return _categoryDal.GetListAll();
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public int TActiveCategortCount()
        {
            return _categoryDal.ActiveCategortCount();
        }

        public int TPassiveCategortCount()
        {
            return _categoryDal.PassiveCategortCount();
        }
    }
}

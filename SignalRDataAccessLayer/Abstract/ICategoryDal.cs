using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalREntityLayer.Entities;

namespace SignalRDataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        int CategortCount();
        int ActiveCategortCount();
        int PassiveCategortCount();
    }
}

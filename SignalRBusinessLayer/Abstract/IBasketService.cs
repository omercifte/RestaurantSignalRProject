using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalREntityLayer.Entities;

namespace SignalRBusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        List<Basket> TGetBasketByTableNumber(int id);
    }
}

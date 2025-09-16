using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalREntityLayer.Entities;

namespace SignalRBusinessLayer.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        int TTotalOrderCount();
        int TActiveOrderCount();
        decimal TLastOrderPrice();
        decimal TTodayTotalPrice();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalREntityLayer.Entities;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        void BookingStatusApproved(int id);
        void BookingStatusCancel(int id);
    }
}

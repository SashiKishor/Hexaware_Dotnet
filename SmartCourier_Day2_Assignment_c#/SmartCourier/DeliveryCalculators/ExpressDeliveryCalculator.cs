using SmartCourier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCourier.DeliveryCalculators
{
    public class ExpressDeliveryCalculator: IDeliveryChargeCalculator
    {
        public decimal DeliverCharge(ICourierBooking booking)
        {
            return booking.Parcel.Weight * 80 + 100;
        }
    }
}

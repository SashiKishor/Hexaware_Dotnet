using SmartCourier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCourier.DeliveryCalculators
{
    public class InternationalDeliveryCalculator: IDeliveryChargeCalculator
    {
        public decimal DeliverCharge(ICourierBooking booking)
        {
            return booking.Parcel.Weight * 150 + 500;
        }
    }
}

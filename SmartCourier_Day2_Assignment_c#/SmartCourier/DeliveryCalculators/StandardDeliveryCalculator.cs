using SmartCourier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCourier.DeliveryCalculators
{
    public class StandardDeliveryCalculator: IDeliveryChargeCalculator
    {
        public decimal DeliverCharge(ICourierBooking booking)
        {
            return booking.Parcel.Weight * 50;
        }
    }
}

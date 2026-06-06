using SmartCourier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCourier.DeliveryCalculators
{
    public interface IDeliveryChargeCalculator
    {
        decimal DeliverCharge(ICourierBooking booking);

    }



}


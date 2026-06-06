using SmartCourier.DeliveryCalculators;
using SmartCourier.Invoices;
using SmartCourier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCourier.Notifications
{
    public interface INotificationService
    {
        public void SendMessage(ICourierBooking booking);
    }
}

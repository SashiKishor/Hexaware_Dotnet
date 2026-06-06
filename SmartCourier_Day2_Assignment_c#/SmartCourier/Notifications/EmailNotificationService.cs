using SmartCourier.DeliveryCalculators;
using SmartCourier.Invoices;
using SmartCourier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCourier.Notifications
{
    public class EmailNotificationService:INotificationService
    {
        public void SendMessage(ICourierBooking booking)
        {
            Console.WriteLine($"Message: Dear {booking.Customer.CustomerName}, your courier booking from {booking.SourceCity} to {booking.DestinationCity} has been successfully confirmed!\n");
            Console.WriteLine($"Mail Sent to {booking.Customer.Email}");
        }
    }
}

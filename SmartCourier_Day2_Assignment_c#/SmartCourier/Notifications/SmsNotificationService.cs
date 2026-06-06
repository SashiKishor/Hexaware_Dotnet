using SmartCourier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCourier.Notifications
{
    public class SmsNotificationService: INotificationService
    {
        public void SendMessage(ICourierBooking booking)
        {
            Console.WriteLine($"Message: Dear {booking.Customer.CustomerName}, your courier booking from {booking.SourceCity} to {booking.DestinationCity} has been successfully confirmed!\n");
            Console.WriteLine($"SMS Sent to {booking.Customer.MobileNumber}");
        }

    }
}

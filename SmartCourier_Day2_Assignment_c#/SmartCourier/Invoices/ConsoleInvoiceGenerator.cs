using System;
using System.Collections.Generic;
using System.Text;
using SmartCourier.DeliveryCalculators;
using SmartCourier.Models;

namespace SmartCourier.Invoices
{
    public class ConsoleInvoiceGenerator:IInvoiceGenerator
    {
        public void Invoice(ICourierBooking booking,decimal total) {
            Console.WriteLine($"Customer Name:{booking.Customer.CustomerName}\nSource City:{booking.SourceCity}\nDestination City:{booking.DestinationCity}\nParcel Weight:{booking.Parcel.Weight}\nDelivery Type:{booking.DeliveryType}\nTotal Delivery Charge:{total}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SmartCourier.DeliveryCalculators;
using SmartCourier.Models;

namespace SmartCourier.Invoices
{
    public interface IInvoiceGenerator
    {
        public void Invoice(ICourierBooking booking,decimal total);
    }
}

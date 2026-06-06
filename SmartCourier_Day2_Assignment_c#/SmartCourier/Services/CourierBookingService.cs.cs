using SmartCourier.DeliveryCalculators;
using SmartCourier.Invoices;
using SmartCourier.Models;
using SmartCourier.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCourier.Services
{
    public class CourierBookingService
    {
        private readonly IInvoiceGenerator _invoiceGenerator;
        private readonly IDeliveryChargeCalculator _chargeCalculator;
        private readonly INotificationService _notificationService;

        public CourierBookingService(IInvoiceGenerator invoiceGenerator, IDeliveryChargeCalculator chargeCalculator, INotificationService notificationService)
        {
            _invoiceGenerator = invoiceGenerator;
            _chargeCalculator = chargeCalculator;
            _notificationService = notificationService;
        }

        public void ProcessBooking(ICourierBooking booking)
        {
            decimal total = _chargeCalculator.DeliverCharge(booking);
            _invoiceGenerator.Invoice(booking, total);
            _notificationService.SendMessage(booking);
        }

       

    }
}

using SmartCourier.DeliveryCalculators;
using SmartCourier.Invoices;
using SmartCourier.Models;
using SmartCourier.Notifications;
using SmartCourier.Services;

namespace SmartCourier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Customer Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Customer Mobile Number: ");
            long mobile = long.Parse(Console.ReadLine());

            Console.Write("Enter Parcel Weight (in kg): ");
            decimal weight = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Source City: ");
            string source = Console.ReadLine();

            Console.Write("Enter Destination City: ");
            string destination = Console.ReadLine();

            Console.WriteLine("\nSelect Delivery Type:");
            Console.WriteLine("1. Standard Delivery");
            Console.WriteLine("2. Express Delivery");
            Console.WriteLine("3. International Delivery");
            Console.Write("Enter choice (1-3): ");
            string deliveryChoice = Console.ReadLine();

            IDeliveryChargeCalculator selectedCalculator = null;
            string deliveryTypeName = "";

            switch (deliveryChoice)
            {
                case "1":
                    selectedCalculator = new StandardDeliveryCalculator();
                    deliveryTypeName = "Standard Delivery";
                    break;
                case "2":
                    selectedCalculator = new ExpressDeliveryCalculator();
                    deliveryTypeName = "Express Delivery";
                    break;
                case "3":
                    selectedCalculator = new InternationalDeliveryCalculator();
                    deliveryTypeName = "International Delivery";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Standard Delivery.");
                    selectedCalculator = new StandardDeliveryCalculator();
                    deliveryTypeName = "Standard Delivery";
                    break;
            }

            Console.WriteLine("\nSelect Notification Type:");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. SMS");
            Console.WriteLine("3. WhatsApp");
            Console.Write("Enter choice (1-3): ");
            string notificationChoice = Console.ReadLine();

            INotificationService selectedNotification = null;
            string notificationTypeName = "";

            switch (notificationChoice)
            {
                case "1":
                    selectedNotification = new EmailNotificationService();
                    notificationTypeName = "Email";
                    break;
                case "2":
                    selectedNotification = new SmsNotificationService();
                    notificationTypeName = "SMS";
                    break;
                case "3":
                    selectedNotification = new WhatsAppNotificationService();
                    notificationTypeName = "WhatsApp";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Email.");
                    selectedNotification = new EmailNotificationService();
                    notificationTypeName = "Email";
                    break;
            }

            IInvoiceGenerator consoleInvoice = new ConsoleInvoiceGenerator();

            ICourierBooking booking = new CourierBooking
            {
                Customer = new Customer
                {
                    CustomerName = name,
                    Email = email,
                    MobileNumber = mobile
                },
                Parcel = new Parcel { Weight = weight },
                SourceCity = source,
                DestinationCity = destination,
                DeliveryType = deliveryTypeName,
                NotificationType = notificationTypeName
            };

            CourierBookingService service=new CourierBookingService(consoleInvoice, selectedCalculator, selectedNotification);

            Console.WriteLine();
            service.ProcessBooking(booking);
         

        }
    }
}

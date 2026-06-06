using E_Commerce.Models;
using E_Commerce.Services;

namespace E_Commerce
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Order order =new Order(1,"Candy",90,9);
           OrderBillingService billingService = new OrderBillingService();
           Console.WriteLine($"Order Id:{order.Id}");
           Console.WriteLine($"Product Name:{order.Product}");
           Console.WriteLine($"Product Price:{order.ProductPrice}");
           Console.WriteLine($"Ordered Quantity:{order.Quantity}");
           Console.WriteLine($"Total Order bill:{billingService.CalculateFinalAmount(order.ProductPrice,order.Quantity)}");
        }
    }
}

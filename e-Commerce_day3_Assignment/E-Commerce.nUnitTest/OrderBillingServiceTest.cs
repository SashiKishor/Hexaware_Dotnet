using E_Commerce.Services;
using NUnit.Framework;

namespace E_Commerce.nUnitTest
{
    [TestFixture]
    public class OrderBillingServiceTest
    {
        private OrderBillingService _service;


        [SetUp]
        public void Setup()
        {
            _service=new OrderBillingService();
        }


        //Method-CalculateSubTotal

        [TestCase(90, 9, 810)]
        [TestCase(80, 9, 720)]
        public void When_Passing_ValidDetails_CalculateSubTotal(decimal price, int quantity, decimal total)
        {
            Assert.That(_service.CalculateSubTotal(price, quantity), Is.EqualTo(total));
        }

        [Test]
        public void When_Passing_InValidDetail_Product_CalculateSubTotal()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => _service.CalculateSubTotal(0, 10));
            Assert.That(exception.Message, Is.EqualTo("Product Price should be graeter than 0."));
        }

        [Test]
        public void When_Passing_InValidDetail_Quantity_CalculateSubTotal()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => _service.CalculateSubTotal(10, 0));
            Assert.That(exception.Message, Is.EqualTo("Quantity Should be Greater than 0."));
        }



        //Method-CalculateDiscount
        [TestCase(5000,500)]
        [TestCase(2000,100)]
        public void When_Passing_ValidDetails_CalculateDiscount(decimal subTotal, decimal discount)
        {
            Assert.That(_service.CalculateDiscount(subTotal), Is.EqualTo(discount));
        }

        public void When_Passing_InValidDetail_SubTotal_CalculateDiscount()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => _service.CalculateDiscount(0));
            Assert.That(exception.Message, Is.EqualTo("SubTotal Should be Greater than 0."));
        }


        //Method-CalculateDeliveryCharge
        [TestCase(1000, 100)]
        [TestCase(2000, 0)]
        public void When_Passing_ValidDetails_CalculateDeliveryCharge(decimal amountAfterDiscount, decimal deliveryCharge)
        {
            Assert.That(_service.CalculateDeliveryCharge(amountAfterDiscount), Is.EqualTo(deliveryCharge));
        }

        public void When_Passing_InValidDetail_amountAfterDiscount_CalculateDeliveryCharge()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => _service.CalculateDeliveryCharge(0));
            Assert.That(exception.Message, Is.EqualTo("Amount After the Discount Should be Greater than 0."));
        }



        //Method-CalculateFinalAmount
        [TestCase(90,9,910)]
        [TestCase(80,9,820)]
        public void When_Passing_ValidDetails_CalculateFinalAmount(decimal price,int quantity,decimal total)
        {
            Assert.That(_service.CalculateFinalAmount(price,quantity),Is.EqualTo(total));
        }

        [Test]
        public void When_Passing_InValidDetail_Product_CalculateFinalAmount() {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => _service.CalculateFinalAmount(0,10));
            Assert.That(exception.Message, Is.EqualTo("Product Price should be graeter than 0."));
        }

        [Test]
        public void When_Passing_InValidDetail_Quantity_CalculateFinalAmount()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => _service.CalculateFinalAmount(10,0));
            Assert.That(exception.Message, Is.EqualTo("Quantity Should be Greater than 0."));
        }



    }
}

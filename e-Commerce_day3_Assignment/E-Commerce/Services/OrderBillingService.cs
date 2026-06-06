using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Services
{
    public class OrderBillingService
    {
       
        public decimal CalculateSubTotal(decimal productPrice, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity Should be Greater than 0.");
            }

            if (productPrice <= 0)
            {
                throw new ArgumentException("Product Price should be graeter than 0.");
            }

            return productPrice * quantity;
        }

        public decimal CalculateDiscount(decimal subTotal)
        {
            if (subTotal <= 0)
            {
                throw new ArgumentException("SubTotal Should be Greater than 0.");
            }


            if (subTotal >= 5000)
            {
                return (subTotal/10);
            }
            else if(subTotal >=2000 && subTotal< 5000){
                return (subTotal / 100) * 5;
            }
            return 0;
        }

        public decimal CalculateDeliveryCharge(decimal amountAfterDiscount)
        {
            if (amountAfterDiscount <= 0)
            {
                throw new ArgumentException("Amount After the Discount Should be Greater than 0.");
            }

            if (amountAfterDiscount <= 1000)
            {
                return 100;
            }
            return 0;
        }

         public decimal CalculateFinalAmount(decimal productPrice, int quantity)
        {
            if (quantity <=0) {
                throw new ArgumentException("Quantity Should be Greater than 0.");
            }

            if (productPrice <= 0) {
                throw new ArgumentException("Product Price should be graeter than 0.");            
            }

            decimal subTotal=this.CalculateSubTotal(productPrice, quantity);
            decimal discount=this.CalculateDiscount(subTotal);
            decimal finalamount = subTotal - discount;
            decimal Delivery=this.CalculateDeliveryCharge(finalamount);
            
            return finalamount+Delivery;
        }


    }
}

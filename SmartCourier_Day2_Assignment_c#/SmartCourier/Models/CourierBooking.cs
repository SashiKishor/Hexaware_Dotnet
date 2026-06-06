using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCourier.Models
{
    public interface ICourierBooking
    {
         Customer Customer { get; set; }
         Parcel Parcel { get; set; }
         string SourceCity { get; set; }
         string DestinationCity { get; set; }
         string DeliveryType { get; set; }
         string NotificationType { get; set; }
    }
    public class CourierBooking: ICourierBooking
    {   
        //Composition(has-a) relation 
        public Customer Customer {  get; set; }
        public Parcel Parcel { get; set; }


        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }
        public string DeliveryType { get; set; }
        public string NotificationType { get; set; }

    }
}

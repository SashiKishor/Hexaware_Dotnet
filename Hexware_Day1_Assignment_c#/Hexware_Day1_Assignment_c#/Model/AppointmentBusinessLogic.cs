using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Model
{
    public partial class Appointment 
    {
        public void Bill()
        {
            decimal total = 0;
            decimal additionalCharge = 0;
  
                if (Status != "Critical")
                {
                    Console.WriteLine("Enter Consultation Fee:");
                    ConsultationFee= decimal.Parse(Console.ReadLine());
                    Console.WriteLine("No Additional Charge.");
                    IsValidAppointment();
                    total = ConsultationFee;
                }
                else
                {
                    Console.WriteLine("Enter Consultation Fee:");
                    ConsultationFee = decimal.Parse(Console.ReadLine());
                    IsValidAppointment();
                    Console.Write("Enter the Additional Charge:");
                    additionalCharge = decimal.Parse(Console.ReadLine());
                    if (additionalCharge <= 0)
                    {
                        throw new InvalidOperationException("Additional charge cannot be less tha or equal to 0.");
                    }
                    total += ConsultationFee + additionalCharge;
                }
                if(IsValidAppointment())
                {
                Console.WriteLine($"Patient Name:{PatientName}\nAppotiment Date:{AppointmentDate}\nInffectiom:{Infection}\nTotal Bill:{total}");
                }
                            
        }
    }
}

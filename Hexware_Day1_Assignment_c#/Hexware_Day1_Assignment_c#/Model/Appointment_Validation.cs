using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Model
{
    internal class Appointment_Validation
    {
    }

    public partial class Appointment
    {
        public bool IsValidAppointment()
        {
            try
            {
                if (TokenNo <= 0)
                {
                    Console.WriteLine("Validation Error: ID cannot be Negative Or 0.");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(PatientName))
                {
                    Console.WriteLine("Validation Error: PatientName cannot be Empty.");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(Infection))
                {
                    Console.WriteLine("Validation Error: Infection cannot be Empty.");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(Department))
                {
                    Console.WriteLine("Validation Error: Department cannot be Empty.");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(Status))
                {
                    Console.WriteLine("Validation Error: Status cannot be Empty.");
                    return false;
                }
                if (ConsultationFee <= 0)
                {
                    Console.WriteLine("Validation Error: ID cannot be Negative Or 0.");
                    return false;
                }
                return true;
            }
            catch(Exception ex) {
                Console.WriteLine($"Validation Error: {ex.Message}");
                return false;
            }
        }
    }
}

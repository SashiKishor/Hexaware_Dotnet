using MedicalAppointment.Model;
using MedicalAppointment.Services;

namespace Hex_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppotimentServices services = new AppotimentServices();

            
            List<Appointment> appointments = new List<Appointment>
            {
            new Appointment
            {
                TokenNo = 1,
                PatientName = "KK",
                AppointmentDate =new DateTime(2026,06,15),
                Infection = "Viral Fever",
                Department = "General Medicine",
                ConsultationFee = 500.00m,
                Consultation = "Scheduled",
                Status = "Confirmed"
            },
            new Appointment
            {
                TokenNo = 2,
                PatientName = "MK",
                AppointmentDate = DateTime.Now,
                Infection = "Gorhnia",
                Department = "General Medicine",
                ConsultationFee = 1500.00m,
                Consultation = "Completed",
                Status = "Confirmed"
            },
            new Appointment
            {
                TokenNo = 3,
                PatientName = "PK",
                AppointmentDate = DateTime.Now,
                Infection = "Palpitation",
                Department = "cardiology",
                ConsultationFee = 150000.00m,
                Consultation = "Scheduled",
                Status = "Confirmed"
            }
            };

            //Display all appointments
            foreach (var appointment in appointments)
            {
                services.DisplayAppotiments(appointment);
                Console.WriteLine();
            }

            // Display only the scheduled appointments
            var SceduledAppointments = appointments.Where(a => a.Consultation == "Scheduled").ToList();
            foreach (var appointment in SceduledAppointments)
            {
                services.DisplayAppotiments(appointment);
                Console.WriteLine();
            }

            //Display Completed Appotiments
            var CompletedAppotiments = appointments.Where(a => a.Consultation == "Completed").ToList();
            foreach (var appointment in CompletedAppotiments)
            {
                services.DisplayAppotiments(appointment);
                Console.WriteLine();
            }

            //Display appointments by Cardiology department
            var CardioCases = appointments.Where(a => a.Department == "cardiology").ToList();
            foreach (var appointment in CardioCases)
            {
                services.DisplayAppotiments(appointment);
                Console.WriteLine();
            }

            //Display appointments with consultation fee greater than 500
            var AppotimentGreaterThan500 = appointments.Where(a => a.ConsultationFee > 500).ToList();
            foreach (var appointment in AppotimentGreaterThan500)
            {
                services.DisplayAppotiments(appointment);
                Console.WriteLine();
            }

            //Sort appointments by appointment date
            var SceduledAppotimentBYDate = appointments.OrderBy(a => a.AppointmentDate).ToList();
            foreach (var appointment in SceduledAppotimentBYDate)
            {
                services.DisplayAppotiments(appointment);
                Console.WriteLine();
            }

            //Search appointment by patient name.
            Console.Write("Enter patient Name to find:");
            string patientName = Console.ReadLine();
            var patientRecord = appointments.Where(a => a.PatientName == patientName).ToList();
            foreach (var appointment in SceduledAppotimentBYDate)
            {
                services.DisplayAppotiments(appointment);
                Console.WriteLine();
            }

            //Group appointments by department
            var appotimentsByDepartment = appointments.GroupBy(a => a.Department);
            foreach (var group in appotimentsByDepartment)
            {
                Console.WriteLine($"Department:{group.Key}");
                Console.WriteLine();
                foreach (var appointment in group)
                {
                    services.DisplayAppotiments(appointment);
                    Console.WriteLine();
                }
            }

            //Count appointments by status.
            var TotalAppoitmentByStatus = appointments.GroupBy(a => a.Status);
            foreach (var group in appotimentsByDepartment)
            {
                Console.WriteLine($"Department:{group.Key}");
                Console.WriteLine(group.Count());
                Console.WriteLine();
            }

            //Calculate total revenue from completed appointments.
            decimal TotalRevenue = 0.00m;
            foreach (var appointment in CompletedAppotiments)
            {
                TotalRevenue += appointment.ConsultationFee;
            }
            Console.WriteLine(TotalRevenue);
            Console.WriteLine();

            //Calculate average consultation fee.
            decimal averageFee = 0.00m;
            int TotalAppotments = appointments.Count();
            foreach (var appotiment in appointments)
            {
                averageFee += appotiment.ConsultationFee;
            }
            averageFee = averageFee / TotalAppotments;
            Console.WriteLine($"{averageFee:F2}");
            Console.WriteLine();

            //Display upcoming appointments
            var UpcomingAppotiment=appointments.Where(a=>a.AppointmentDate>DateTime.Now).ToList();
            foreach (var appointment in UpcomingAppotiment)
            {
                services.DisplayAppotiments(appointment);
                Console.WriteLine();
            }


        }
    }
}

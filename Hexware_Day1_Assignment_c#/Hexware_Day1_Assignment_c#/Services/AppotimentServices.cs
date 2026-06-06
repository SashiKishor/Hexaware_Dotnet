using MedicalAppointment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Services
{
    internal class AppotimentServices
    {
        public void AddPateintDetail(Appointment appointment)
        {
            Console.WriteLine("Enter Patient inffection:");
            string inffection = Console.ReadLine();
            Console.WriteLine("Assign the appropriate Department:");
            string department = Console.ReadLine();
            Console.WriteLine("Enter the Patient Status:");
            string status = Console.ReadLine();

            appointment.Infection = inffection;
            appointment.Department = department;
            appointment.Status = status;
            appointment.Status = "Scheduled";
            appointment.AppointmentDate = DateTime.Now;
            
        }

        public void DisplayAppotiments(Appointment appointment)
        {
            Console.WriteLine($"TokenNo: {appointment.TokenNo}\nPatientName: {appointment.PatientName}\nAppointmentDate: {appointment.AppointmentDate}\nInfection: {appointment.Infection}\nDepartment: {appointment.Department}\nConsultationFee: {appointment.ConsultationFee}\nConsultation: {appointment.Consultation}\nStatus: {appointment.Status}");
        }


    }
}

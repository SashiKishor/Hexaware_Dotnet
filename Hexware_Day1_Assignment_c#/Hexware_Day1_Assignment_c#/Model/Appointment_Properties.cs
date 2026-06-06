using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Model
{
    public partial class Appointment
    {
        public int TokenNo { get; set; }

        public string PatientName { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Infection { get; set; } = "";

        public string Department { get; set; } = "";

        public decimal ConsultationFee { get; set; } = 0.0m;

        public string Consultation { get; set; } = "Not Sceduled";

        public string Status { get; set; } = "";


    }
}

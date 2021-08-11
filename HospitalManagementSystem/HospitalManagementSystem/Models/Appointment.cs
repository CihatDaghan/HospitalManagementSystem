using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public string doctor_name { get; set; }
        public string patient_name { get; set; }
        public DateTime appointment_date { get; set; }
    }
}

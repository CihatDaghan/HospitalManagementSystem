using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Patient
    {
        public int ID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string insurance { get; set; }
        public string adress { get; set; }
        public string phone_number { get; set; }
    }
}

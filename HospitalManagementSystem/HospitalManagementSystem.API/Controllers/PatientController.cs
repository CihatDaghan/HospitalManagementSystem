using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController:ControllerBase
    {
        DatabaseContext c = new DatabaseContext();
        [HttpGet]
        public List<Patient> getPatient()
        {
            
            return c.Patients.ToList();
        }
        [HttpGet ("{id}")]
        public Patient getPatientById(int id)
        {
            return c.Patients.Find(id); 
        }
        [HttpPost]
        public Patient addPatient([FromBody] Patient patient)
        {
            c.Patients.Add(patient);
            c.SaveChanges();
            return patient;
        }
        [HttpPut]
        public Patient updatePatient([FromBody] Patient patient)
        {
            var data = c.Patients.Find(patient.ID);
            data.firstname = patient.firstname;
            data.lastname = patient.lastname;
            data.insurance = patient.insurance;
            data.adress = patient.adress;
            data.phone_number = patient.phone_number;
            c.SaveChanges();
            return patient;
        }
        [HttpDelete]
        public void deletePatient(int id)
        {
            var patient = c.Patients.Find(id);
            c.Patients.Remove(patient);
            c.SaveChanges();
        }
    }
}

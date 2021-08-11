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
    public class DoctorController:ControllerBase
    {
        DatabaseContext c = new DatabaseContext();
        [HttpGet]
        public List<Doctor> getDoctor()
        {
            return c.Doctors.ToList();
        }
        [HttpGet ("{id}")]
        public Doctor getDoctorById(int id)
        {
            return c.Doctors.Find(id); 
        }
        [HttpPost]
        public Doctor addDoctor([FromBody] Doctor Doctor)
        {
            c.Doctors.Add(Doctor);
            c.SaveChanges();
            return Doctor;
        }
        [HttpPut]
        public Doctor updateDoctor([FromBody] Doctor doctor)
        {
            var data = c.Doctors.Find(doctor.ID);
            data.firstname = doctor.firstname;
            data.lastname = doctor.lastname;
            data.adress = doctor.adress;
            data.number = doctor.number;
            c.SaveChanges();
            return doctor;
        }
        [HttpDelete]
        public void deleteDoctor(int id)
        {
            var Doctor = c.Doctors.Find(id);
            c.Doctors.Remove(Doctor);
            c.SaveChanges();
        }
    }
}

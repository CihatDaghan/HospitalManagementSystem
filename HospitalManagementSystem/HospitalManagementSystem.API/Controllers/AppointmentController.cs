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
    public class AppointmentController:ControllerBase
    {
        DatabaseContext c = new DatabaseContext();
        [HttpGet]
        public List<Appointment> getAppointment()
        {
            return c.Appointments.ToList();
        }
        [HttpGet ("{id}")]
        public Appointment getAppointmentById(int id)
        {
            return c.Appointments.Find(id); 
        }
        [HttpPost]
        public Appointment addAppointment([FromBody] Appointment Appointment)
        {
            c.Appointments.Add(Appointment);
            c.SaveChanges();
            return Appointment;
        }
        [HttpPut]
        public Appointment updateAppointment([FromBody] Appointment Appointment)
        {
            var data = c.Appointments.Find(Appointment.ID);
            data.doctor_name = Appointment.doctor_name;
            data.patient_name = Appointment.patient_name;
            data.appointment_date = Appointment.appointment_date;
            c.SaveChanges();
            return Appointment;
        }
        [HttpDelete]
        public void deleteAppointment(int id)
        {
            var Appointment = c.Appointments.Find(id);
            c.Appointments.Remove(Appointment);
            c.SaveChanges();
        }
    }
}

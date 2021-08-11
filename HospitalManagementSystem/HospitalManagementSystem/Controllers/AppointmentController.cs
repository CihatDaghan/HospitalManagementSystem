using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {

        DatabaseContext c = new DatabaseContext();
        public IActionResult Index()
        {
            var data = c.Appointments.ToList();
            return View(data);
        }

        [Route("Appointment/AppointmentGet/{ID}")]
        public IActionResult AppointmentGet(int id)
        {
            List<SelectListItem> datas = (from x in c.Patients.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.firstname,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.Patients = datas;
            List<SelectListItem> data = (from x in c.Doctors.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.firstname,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.Doctor = datas;
            var appointment = c.Appointments.Find(id);
            return View("AppointmentGet", appointment);
        }

        [Route("Appointment/AppointmentDelete/{ID}")]
        public IActionResult AppointmentDelete(int id)
        {
            var appointment = c.Appointments.Find(id);
            c.Appointments.Remove(appointment);
            c.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AppointmentAdd(Appointment appointment)
        {
            var datas = c.Patients.ToList();
            ViewBag.Patients = datas;
            var data = c.Doctors.ToList();

            ViewBag.Doctor = data;
            if (appointment.doctor_name != null)
            {
                c.Appointments.Add(appointment);
                c.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult search(string search)
        {
            var query = from x in c.Appointments
                        where x.doctor_name == search
                        select x;
            var data = query.ToList();
            return View("Index", data);
        }


    }

}


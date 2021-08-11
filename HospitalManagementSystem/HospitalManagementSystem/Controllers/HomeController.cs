using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext c = new DatabaseContext();
        public IActionResult Index()
        {
            var doctor = c.Doctors.Count();
            var appointments = c.Appointments.Count();
            var patients = c.Patients.Count();
            ViewBag.doctor = doctor;
            ViewBag.appointments = appointments;
            ViewBag.patients = patients;
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}

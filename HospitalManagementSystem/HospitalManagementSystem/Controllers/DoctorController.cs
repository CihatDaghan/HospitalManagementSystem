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
    public class DoctorController : Controller
    {
        DatabaseContext c = new DatabaseContext();
        public IActionResult Index()
        {
            var data = c.Doctors.ToList();
            return View(data);
        }

        [Route("Doctor/DoctorGet/{ID}")]
        public IActionResult DoctorGet(int id)
        {
            var doctor = c.Doctors.Find(id);
            return View("DoctorGet", doctor);
        }

        [Route("Doctor/DoctorDelete/{ID}")]
        public IActionResult DoctorDelete(int id)
        {
            var doctor = c.Doctors.Find(id);
            c.Doctors.Remove(doctor);
            c.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DoctorAdd(Doctor doctor)
        {
            if (doctor.firstname != null)
            {
                c.Doctors.Add(doctor);
                c.SaveChanges();
                return RedirectToAction("Success", "Home");
            }
            return View();
        }
        public IActionResult search(string search)
        {
            var query = from x in c.Doctors
                        where x.firstname == search
                        select x;
            var data = query.ToList();
            return View("Index", data);
        }

    }
}

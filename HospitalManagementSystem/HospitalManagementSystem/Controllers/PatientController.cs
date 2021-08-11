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
    public class PatientController : Controller
    {
        DatabaseContext c = new DatabaseContext();

        public IActionResult Index()
        {
            var data = c.Patients.ToList();
            return View(data);
        }

        [Route("Patient/PatientGet/{ID}")]
        public IActionResult PatientGet(int id)
        {
            var patient = c.Patients.Find(id);
            return View("PatientGet", patient);
        }

        [Route("Patient/PatientDelete/{ID}")]
        public IActionResult PatientDelete(int id)
        {
            var patient = c.Patients.Find(id);
            c.Patients.Remove(patient);
            c.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult PatientAdd(Patient patient)
        {
            if (patient.firstname != null)
            {
                c.Patients.Add(patient);
                c.SaveChanges();
                return RedirectToAction("Success", "Home");
            }
            return View();
        }

        public IActionResult search(string search)
        {
            var query = from x in c.Patients
                                       where x.firstname == search
                                       select x;
            var data = query.ToList();
            return View("Index", data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovie.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorDbService _service;

        public DoctorsController(IDoctorDbService service)
        {
            _service = service;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task <IActionResult> GetDoctors()
        {
            return View(await _service.GetDoctors());
        }

        public async Task<IActionResult> ShowDoctorDetails(int id)
        {
         
            return View(await _service.ShowDoctorDetails(id));
        }

        public IActionResult AddDoctor()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> AddDoctor(Doctors doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);           //zeby nie wypelniac ponownie calego formularza
            }

            return View(await _service.AddDoctor(doctor));


            return RedirectToAction("AddDoctor");
        }

        [HttpPut]
        public async Task <IActionResult> ModifyDoctor(Doctors doctors)
        {

        }
    }
}

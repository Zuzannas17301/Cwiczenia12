using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Services
{
    interface IDoctorService
    {
         Task<IActionResult> GetDoctors();
         Task<IActionResult> ShowDoctorDetails(int id);
         Task<IActionResult> AddDoctor(Doctors doctor);
         Task<IActionResult> ModifyDoctor(Doctors doctor);
         Task<IActionResult> DeleteDoctor(Doctors doctor);
        
    }
}

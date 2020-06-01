using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Services
{
    public class IDoctorDbService : IDoctorService
    {
        private readonly s17301Context _context;

        public IDoctorDbService(s17301Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetDoctors()
        {
            return new OkObjectResult(_context.Doctors.ToList());
        }

        public async Task<IActionResult> ShowDoctorDetails(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.IdDoctor == id);

            if (doctor == null)
                return new BadRequestResult();
            else
                return new OkObjectResult(doctor);

        }
        public async Task<IActionResult> AddDoctor(Doctors doctor)
        {
            _context.Add(new Doctors()
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email

            });
            await _context.SaveChangesAsync();
            return new OkObjectResult("Dodano nowego lekarza do bazy danych");
        }

        public async Task<IActionResult> ModifyDoctor(Doctors doctor)
        {
            var res = _context.Doctors.FirstOrDefault(d => d.IdDoctor == doctor.IdDoctor);

            if(res != null)
            {
                res.FirstName = doctor.FirstName;
                res.LastName = doctor.LastName;
                res.Email = doctor.Email;
            }
            else
            {
                return new BadRequestResult();
            }
            await _context.SaveChangesAsync();
            return new OkObjectResult(res);
        }

        public async Task<IActionResult> DeleteDoctor(Doctors doctor)
        {
            var prescriptions = _context.Prescription.Where(p => p.IdDoctor == doctor.IdDoctor).ToList();
            var prescriptionMedicamentList = new ArrayList();

            foreach(Prescription p in prescriptions)
            {
                prescriptionMedicamentList.Add(
                    _context.PrescriptionMedicaments.Where(p=>p.IdPrescription == p.IdPrescription));
            }

            foreach(PrescriptionMedicaments pm in prescriptionMedicamentList)
            {
                _context.Remove(pm);
            }

            foreach(Prescription p in prescriptions)
            {
                _context.Remove(prescriptions);
            }
            _context.Remove(_context.Doctors.Where(d => d.IdDoctor == doctor.IdDoctor).ToList().First());
            await _context.SaveChangesAsync();

            return new OkObjectResult("Pomyślnie usunięto doktora wraz ze wszystkimi wystawionymi przez niego receptami");
        }
    }
}

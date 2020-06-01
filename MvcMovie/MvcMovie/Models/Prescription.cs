using System;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public partial class Prescription
    {
        public Prescription()
        {
            PrescriptionMedicaments = new HashSet<PrescriptionMedicaments>();
        }

        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        public virtual Doctors IdDoctorNavigation { get; set; }
        public virtual Patients IdPatientNavigation { get; set; }
        public virtual ICollection<PrescriptionMedicaments> PrescriptionMedicaments { get; set; }
    }
}

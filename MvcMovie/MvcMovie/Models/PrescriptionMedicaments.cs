using System;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public partial class PrescriptionMedicaments
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }

        public virtual Medicaments IdMedicamentNavigation { get; set; }
        public virtual Prescription IdPrescriptionNavigation { get; set; }
    }
}

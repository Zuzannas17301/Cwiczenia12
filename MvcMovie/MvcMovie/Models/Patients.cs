using System;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Prescription = new HashSet<Prescription>();
        }

        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}

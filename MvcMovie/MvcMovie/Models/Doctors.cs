using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Prescription = new HashSet<Prescription>();
        }

        public int IdDoctor { get; set; }
        [DisplayName("Imię")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;

namespace MedicamenteDB.Models

{
    public class MedicamenteModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required()]
        [Display(Name = "Denumire comerciala")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Denumirea medicamentului trebuie sa fie cuprinsa intre 3 si 50 de caractere")]
        [Required()]
        [Display(Name = "Cateogrie (Alergologie, cardiologie, oncologie etc. )")]
        public string Category { get; set; }

        [Range(1, 100)]
        [Display(Name = "Dozaj exprimat in mg")]
        public int Dosage { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Denumirea medicamentului trebuie sa fie cuprinsa intre 3 si 50 de caractere)")]
        [Required()]
        [Display(Name = "Forma (Pilule, fiole, lotiuni, picaturi, perfuzabil etc. )")]
        public string Form { get; set; }
    }
}
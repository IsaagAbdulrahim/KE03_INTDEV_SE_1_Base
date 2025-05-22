using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KE03_INTDEV_SE_1_Base.Models
{
    public class Bestelling
    {
        public int Id { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [Required]
        public string Achternaam { get; set; }

        [Required]
        public string Woonplaats { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}[A-Z]{2}$", ErrorMessage = "Gebruik 4 cijfers en 2 hoofdletters, zoals 1234AB")]
        public string Postcode { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Betaalmethode { get; set; }

        public DateTime Datum { get; set; } = DateTime.Now;
        public decimal Totaalbedrag { get; set; }
        public string Status { get; set; } = "In behandeling";
    }
}

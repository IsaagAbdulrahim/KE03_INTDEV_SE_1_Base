using DataAccessLayer;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_1_Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class BestellenModel : PageModel
    {
        [BindProperty]

        public Bestelling NieuweBestelling { get; set; }

        public string Bevestiging { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Winkelmand ophalen
            var winkelmandStr = HttpContext.Session.GetString("Winkelmand");
            var winkelmand = string.IsNullOrEmpty(winkelmandStr)
                ? new List<WinkelmandItem>()
                : JsonSerializer.Deserialize<List<WinkelmandItem>>(winkelmandStr);

            decimal totaal = winkelmand.Sum(item => item.Product.Price * item.Aantal);
            NieuweBestelling.Totaalbedrag = totaal;

            _context.Bestellingen.Add(NieuweBestelling);
            _context.SaveChanges();

            // Winkelmand legen
            HttpContext.Session.Remove("Winkelmand");

            Bevestiging = "Uw bestelling wordt binnen 2 werkdagen geleverd.";
            return Page();
        }

        private readonly MatrixIncDbContext _context;

        public BestellenModel(MatrixIncDbContext context)
        {
            _context = context;
        }
        
    }
}




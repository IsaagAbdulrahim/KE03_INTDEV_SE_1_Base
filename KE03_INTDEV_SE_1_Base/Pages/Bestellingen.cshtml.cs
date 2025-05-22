using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KE03_INTDEV_SE_1_Base.Models;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;


namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class BestellingenModel : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public BestellingenModel(MatrixIncDbContext context)
        {
            _context = context;
        }

        public List<Bestelling> BestellingenLijst { get; set; }

        public void OnGet()
        {
            BestellingenLijst = _context.Bestellingen
                .OrderByDescending(b => b.Datum)
                .ToList();
        }
    }
}

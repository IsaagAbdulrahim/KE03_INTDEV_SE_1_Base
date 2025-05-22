using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using KE03_INTDEV_SE_1_Base.Models;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class ProductenModel : PageModel
    {
        public IActionResult OnPostToevoegen(int id)
        {
            // Maak lijst van producten aan (tijdelijk, in een echte app komt dit uit database)
            var alleProducten = new List<Product>
    {
        new Product { Id = 1, Name = "Boormachine", Price = 99.99M, Afbeelding = "boormachine.jpg" },
        new Product { Id = 2, Name = "Moersleutel", Price = 14.95M, Afbeelding = "moersleutel.webp" },
        new Product { Id = 3, Name = "Hamer", Price = 19.50M, Afbeelding = "hamer.jpg" },
        new Product { Id = 4, Name = "Tang", Price = 11.25M, Afbeelding = "tang.jpg" },
        new Product { Id = 5, Name = "Bankschroef", Price = 49.95M, Afbeelding = "bankschroef.jpg" }
    };

            var gekozen = alleProducten.FirstOrDefault(p => p.Id == id);

            if (gekozen == null) return RedirectToPage("/Producten");

            // Sessie ophalen
            var winkelmandStr = HttpContext.Session.GetString("Winkelmand");
            var winkelmand = string.IsNullOrEmpty(winkelmandStr)
                ? new List<WinkelmandItem>()
                : JsonSerializer.Deserialize<List<WinkelmandItem>>(winkelmandStr);

            var bestaand = winkelmand.FirstOrDefault(i => i.Product.Id == id);
            if (bestaand != null)
            {
                bestaand.Aantal++;
            }
            else
            {
                winkelmand.Add(new WinkelmandItem { Product = gekozen, Aantal = 1 });
            }

            // Sessie bijwerken
            HttpContext.Session.SetString("Winkelmand", JsonSerializer.Serialize(winkelmand));
            return RedirectToPage("/Producten");
        }
        public List<Product> Producten { get; set; }
        public void OnGet()
        {
            Producten = new List<Product>
            {
                new Product { Id = 1, Name = "Boormachine", Price = 99.99M, Afbeelding = "boormachine.jpg" },
                new Product { Id = 2, Name = "Moersleutel", Price = 14.95M, Afbeelding = "moersleutel.webp" },
                new Product { Id = 3, Name = "Hamer", Price = 19.50M, Afbeelding = "hamer.jpg" },
                new Product { Id = 4, Name = "Tang", Price = 11.25M, Afbeelding = "tang.jpg" },
                new Product { Id = 5, Name = "Bankschroef", Price = 49.95M, Afbeelding = "bankschroef.jpg" }
            };
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_1_Base.Models;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class WinkelmandModel : PageModel
    {
        public List<WinkelmandItem> Winkelmandje { get; set; }

        public void OnGet()
        {
            var winkelmandStr = HttpContext.Session.GetString("Winkelmand");
            Winkelmandje = string.IsNullOrEmpty(winkelmandStr)
                ? new List<WinkelmandItem>()
                : JsonSerializer.Deserialize<List<WinkelmandItem>>(winkelmandStr);
        }

        public IActionResult OnPostVerwijder(int id)
        {
            var winkelmandStr = HttpContext.Session.GetString("Winkelmand");
            var lijst = string.IsNullOrEmpty(winkelmandStr)
                ? new List<WinkelmandItem>()
                : JsonSerializer.Deserialize<List<WinkelmandItem>>(winkelmandStr);

            var item = lijst.FirstOrDefault(i => i.Product.Id == id);
            if (item != null)
            {
                lijst.Remove(item);
                HttpContext.Session.SetString("Winkelmand", JsonSerializer.Serialize(lijst));
            }

            return RedirectToPage();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace KE03_INTDEV_SE_1_Base.Models
{
    public class WinkelmandItem
    {
        public Product Product { get; set; }
        public int Aantal { get; set; }
    }
}

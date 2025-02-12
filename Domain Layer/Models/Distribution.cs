using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class Distribution
    {
        public int Id { get; set; }
        public int GebruikerId { get; set; }
        public int VoedselproductId { get; set; }
        public DateTime Tijdstip { get; set; }
    }
}

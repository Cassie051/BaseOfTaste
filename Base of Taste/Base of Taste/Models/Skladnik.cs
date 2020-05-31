
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace BazaSmakuAPI.Models
{
    public class Skladnik
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
    }

    public class ViewSkladniki : Skladnik
    {
        public List<Alergen> Alergeny { get; set; }
        public List<WartoscOdzywcza> WartoscOdzywcze { get; set; }
        public Jednostka Jednostka { get; set; }
        public decimal Ilosc { get; set; }
    }
}
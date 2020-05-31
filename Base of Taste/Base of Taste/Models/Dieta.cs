

using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace BazaSmakuAPI.Models
{
    public class Dieta
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
    }

    public class ViewDieta : Dieta
    {
        public List<Przepis> Przepisy { get; set; }
    }
}
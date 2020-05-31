

using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace BazaSmakuAPI.Models
{
    public class Przepis
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public int Opis_ID { get; set; }
    }

    public class ViewPrzepis : Przepis
    {
        public List<ViewSkladniki> Skladniki { get; set; }
        public List<Dieta> Diety { get; set; }
        public List<TypDania> TypDanias { get; set; }
        public Opis opis { get; set; }

    }
}
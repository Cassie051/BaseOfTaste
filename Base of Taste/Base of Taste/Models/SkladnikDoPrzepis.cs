

namespace BazaSmakuAPI.Models
{
    public class SkladnikDoPrzepis
    {
        public int ID { get; set; }
        public int Skladnik_ID { get; set; }
        public int Przepis_ID { get; set; }
        public int Ilosc { get; set; }
        public string Jednostka_ID { get; set; }

    }
}
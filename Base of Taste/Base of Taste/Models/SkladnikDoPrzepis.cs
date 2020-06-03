

namespace BazaSmakuAPI.Models
{
    public class SkladnikDoPrzepis
    {
        public int ID { get; set; }
        public int Skladnik_ID { get; set; }
        public int Przepis_ID { get; set; }
        public decimal Ilosc { get; set; }
        public int Jednostka_ID { get; set; }

    }
}
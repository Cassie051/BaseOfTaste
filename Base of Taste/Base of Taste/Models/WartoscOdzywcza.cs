

namespace BazaSmakuAPI.Models
{
    public class WartoscOdzywcza
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
    }

    public class ViewWarotscOdzywcza : WartoscOdzywcza
    {
        public int ilosc { get; set; }
    }
}
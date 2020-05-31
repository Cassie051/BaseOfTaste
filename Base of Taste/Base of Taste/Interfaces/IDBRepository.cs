
using BazaSmakuAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base_of_Taste.Interfaces
{
    public interface IDBRepository
    {
        public Alergen AddAlergen(Alergen alergen);
        public Dieta AddDieta(Dieta dieta);
        public Jednostka AddJednostka(Jednostka jednostka);
        public Przepis AddPrzepis(ViewPrzepis przepis);
        public Opis AddOpis(Opis opis);
        public Skladnik AddSkladnik(ViewSkladniki skladnik);
        public TypDania AddTypDania(TypDania typDania);
        public WartoscOdzywcza AddWartoscOdrzywcza(WartoscOdzywcza wartoscOdrzywcza);
        public bool UsunAlergen(int id);
        public bool UsunDieta(int id);
        public bool UsunPrzepis(int id);
        public bool UsunSkladnik(int id);
        public bool UsunOpis(int id);
        public bool UsunTypDania(int id);
        public bool UsunWartoscOdrzywcza(int id);
        public List<Alergen> GetAlergeny();
        public List<Dieta> GetDiety();
        public List<Jednostka> GetJednostki();
        public List<ViewPrzepis> GetPrzepisy();
        public List<ViewSkladniki> GetSkladniki();
        public List<WartoscOdzywcza> GetWartoscOdzywcze();
        public List<TypDania> GetTypyDania();


    }
}

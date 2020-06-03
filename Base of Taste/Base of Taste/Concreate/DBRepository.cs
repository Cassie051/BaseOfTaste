using Base_of_Taste.Interfaces;
using BazaSmakuAPI.Concrete;
using BazaSmakuAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Base_of_Taste.Concreate
{
    public class DBRepository : IDBRepository
    {
        private DatabaseContext _db = new DatabaseContext();
        public Alergen AddAlergen(Alergen alergen)
        {
            var toReturn =_db.Alergen.Add(alergen);
            _db.SaveChanges();
            return toReturn.Entity;
        }

        public Dieta AddDieta(Dieta dieta)
        {
            var toReturn = _db.Dieta.Add(dieta);
            _db.SaveChanges();
            return toReturn.Entity;
        }

        public Jednostka AddJednostka(Jednostka jednostka)
        {
            var toReturn = _db.Jednostka.Add(jednostka);
            _db.SaveChanges();
            return toReturn.Entity;
        }

        public Opis AddOpis(Opis opis)
        {
            //do usunięcia. opis będzie dodawany razem z przepisem;
            throw new NotImplementedException();
        }

        public Przepis AddPrzepis(ViewPrzepis przepis)
        {
            foreach(var skladnik in przepis.Skladniki)
            {
                var result = _db.Skladnik.Where(x => x.ID == skladnik.ID);
                if (result.Count() == 0) throw new Exception("Niektóre składniki nie występują w bazie");
            }

            foreach (var dieta in przepis.Diety)
            {
                var result = _db.Dieta.Where(x => x.ID == dieta.ID);
                if(result.Count() == 0) throw new Exception("Niektóre diety nie występują w bazie");
            }

            foreach(var typDania in przepis.TypDanias)
            {
                var result = _db.TypDania.Where(x => x.ID == typDania.ID);
                if (result.Count() == 0) throw new Exception("Niektóre typy dań nie występują w bazie");
            }

            var dbOpis = _db.Opis.Add(przepis.opis);

            przepis.Opis_ID = dbOpis.Entity.ID;

            var dbPrzepis = _db.Przepis.Add(przepis).Entity;

            foreach (var skladnik in przepis.Skladniki)
            {
                var skladnikDoPrzepis = new SkladnikDoPrzepis
                {
                    ID = skladnik.ID,
                    Ilosc = skladnik.Ilosc,
                    Jednostka_ID = skladnik.Jednostka.ID,
                    Przepis_ID = dbPrzepis.ID,
                    Skladnik_ID = skladnik.ID
                };

                _db.SkladnikDoPrzepis.Add(skladnikDoPrzepis);
            }

            foreach (var dieta in przepis.Diety)
            {
                var przepisDoDiety = new PrzepisDoDieta
                {
                    Dieta_ID = dieta.ID,
                    Przepis_ID = dbPrzepis.ID
                };

                _db.PrzepisDoDieta.Add(przepisDoDiety);
            }

            foreach (var typDania in przepis.TypDanias)
            {
                var typDoPrzepisu = new TypDoPrzepis
                {
                    Przepis_ID = dbPrzepis.ID,
                    Typ_ID = typDania.ID
                };

            }

            _db.SaveChanges();

            return dbPrzepis;
        }

        public Skladnik AddSkladnik(ViewSkladniki skladnik)
        {
            foreach(var alergen in skladnik.Alergeny)
            {
                var result = _db.Alergen.Where(x => x.ID == alergen.ID);
                if (result.Count() == 0) throw new Exception("Niektóre alergeny nie występują w bazie");
            }

            foreach (var wartoscOdrzywcza in skladnik.WartoscOdzywcze)
            {
                var result = _db.WartoscOdzywcza.Where(x => x.ID == wartoscOdrzywcza.ID);
                if (result.Count() == 0) throw new Exception("Niektóre wartości odrzywcze nie występują w bazie");
            }

            var dbSkladnik = _db.Skladnik.Add(skladnik).Entity;

            foreach (var alergen in skladnik.Alergeny)
            {
                _db.AlergenDoSkladnik.Add(new AlergenDoSkladnik
                {
                    Alergen_ID = alergen.ID,
                    Skladnik_ID = dbSkladnik.ID
                });
            }

            foreach (var wartoscOdrzywcza in skladnik.WartoscOdzywcze)
            {
                _db.WartosciDoSkladnikow.Add(new WartosciDoSkladnikow
                {
                    Ilosc = wartoscOdrzywcza.ilosc,
                    Wartosc_ID = wartoscOdrzywcza.ID,
                    Skladnik_ID = dbSkladnik.ID
                });

            }

            _db.SaveChanges();
            return dbSkladnik;
        }

        public TypDania AddTypDania(TypDania typDania)
        {
            var dbTypDania = _db.TypDania.Add(typDania);
            _db.SaveChanges();
            return dbTypDania.Entity;
        }

        public WartoscOdzywcza AddWartoscOdrzywcza(WartoscOdzywcza wartoscOdrzywcza)
        {
            var dbWartoscOdzywcza = _db.WartoscOdzywcza.Add(wartoscOdrzywcza);
            _db.SaveChanges();
            return dbWartoscOdzywcza.Entity;
        }

        public List<Alergen> GetAlergeny()
        {
            return _db.Alergen.ToList();
        }

        public List<Dieta> GetDiety()
        {
            return _db.Dieta.ToList();
        }

        public List<Jednostka> GetJednostki()
        {
            return _db.Jednostka.ToList();
        }

        public List<ViewPrzepis> GetPrzepisy()
        {
            throw new NotImplementedException();
        }

        public List<ViewSkladniki> GetSkladniki()
        {
            throw new NotImplementedException();
        }

        public List<TypDania> GetTypyDania()
        {
            return _db.TypDania.ToList();
        }

        public List<WartoscOdzywcza> GetWartoscOdzywcze()
        {
            return _db.WartoscOdzywcza.ToList();
        }

        public bool UsunAlergen(int id)
        {
            if (_db.AlergenDoSkladnik.Where(x => x.ID == id).Count() != 0)
                throw new Exception("Alergen przypisany jest do niektórych składników");
            var alergen = _db.Alergen.FirstOrDefault(x => x.ID == id);
            _db.Alergen.Remove(alergen);
            _db.SaveChanges();
            return true;
        }

        public bool UsunDieta(int id)
        {
            throw new NotImplementedException();
        }

        public bool UsunOpis(int id)
        {
            throw new NotImplementedException();
        }

        public bool UsunPrzepis(int id)
        {
            throw new NotImplementedException();
        }

        public bool UsunSkladnik(int id)
        {
            throw new NotImplementedException();
        }

        public bool UsunTypDania(int id)
        {
            throw new NotImplementedException();
        }

        public bool UsunWartoscOdrzywcza(int id)
        {
            throw new NotImplementedException();
        }
    }
}

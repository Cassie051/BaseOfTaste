using Base_of_Taste.Interfaces;
using BazaSmakuAPI.Concrete;
using BazaSmakuAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

            var toReturn = new List<ViewPrzepis>();
            foreach(var przepis in _db.Przepis.ToList())
            {
                toReturn.Add(new ViewPrzepis
                {
                    ID = przepis.ID,
                    Nazwa = przepis.Nazwa,
                    opis = _db.Opis.First(x=> x.ID == przepis.ID)
                });
            }

            foreach(var przepis in toReturn)
            {
                var ids = _db.TypDoPrzepis.Where(x => x.Przepis_ID == przepis.ID).ToList();
                List<int> intIds = new List<int>();
                foreach(var id in ids)
                {
                    intIds.Add(id.ID);
                }
                przepis.TypDanias = _db.TypDania.Where(x => intIds.Contains(x.ID)).ToList();

                var ids2 = _db.PrzepisDoDieta.Where(x => x.Przepis_ID == przepis.ID).ToList();
                foreach (var id in ids)
                {
                    intIds.Add(id.ID);
                }
                przepis.Diety = _db.Dieta.Where(x => intIds.Contains(x.ID)).ToList();

                var vskladniki = _db.SkladnikDoPrzepis.Join(_db.Skladnik, sdp => sdp.Skladnik_ID, skladnik => skladnik.ID, (x, y) => 
                    new { sdp = x, skladnik = y })
                    .Where(x=> x.sdp.Przepis_ID == przepis.ID);
                List<ViewSkladniki> skladnikis = new List<ViewSkladniki>();
                foreach(var vskladnik in vskladniki)
                {
                    var t =new ViewSkladniki
                    {
                        ID = vskladnik.skladnik.ID,
                        Nazwa = vskladnik.skladnik.Nazwa,
                        Ilosc = vskladnik.sdp.Ilosc,
                        Jednostka = _db.Jednostka.First(x => x.ID == vskladnik.sdp.Jednostka_ID)
                    };

                    var valergenys = _db.AlergenDoSkladnik.Join(_db.Alergen, ads => ads.Alergen_ID, alergen => alergen.ID, (x, y) 
                        => new { ads = x, alergen = y })
                        .Where(x => x.ads.Skladnik_ID == t.ID);
                    t.Alergeny = new List<Alergen>();
                    foreach(var valergen in valergenys)
                    {
                        t.Alergeny.Add(valergen.alergen);
                    }

                    t.WartoscOdzywcze = new List<ViewWarotscOdzywcza>();
                    var vwartodzs = _db.WartosciDoSkladnikow.Join(_db.WartoscOdzywcza, wds => wds.Wartosc_ID, wartosc => wartosc.ID, (x, y)
                        => new { wds = x, wartosc = y })
                        .Where(x => x.wds.Skladnik_ID == t.ID);
                    foreach(var vwartodz in vwartodzs)
                    {
                        t.WartoscOdzywcze.Add(new ViewWarotscOdzywcza
                        {
                            ID = vwartodz.wartosc.ID,
                            Nazwa = vwartodz.wartosc.Nazwa,
                            ilosc = vwartodz.wds.Ilosc
                        });

                    }

                     
                }

                przepis.Skladniki = skladnikis;

            }

            return toReturn;
        }

        public List<Skladnik> GetSkladniki()
        {
            return _db.Skladnik.ToList();
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
            if (_db.AlergenDoSkladnik.Where(x => x.Alergen_ID == id).Count() != 0)
                throw new Exception("Alergen przypisany jest do niektórych składników");
            var alergen = _db.Alergen.FirstOrDefault(x => x.ID == id);
            _db.Alergen.Remove(alergen);
            _db.SaveChanges();
            return true;
        }

        public bool UsunDieta(int id)
        {
            if (_db.PrzepisDoDieta.Where(x => x.Dieta_ID == id).Count() != 0)
                throw new Exception("Alergen przypisany jest do niektórych składników");
            var dieta = _db.Alergen.FirstOrDefault(x => x.ID == id);
            _db.Alergen.Remove(dieta);
            _db.SaveChanges();
            return true;
        }

        public bool UsunOpis(int id)
        {
            if (_db.Przepis.Where(x => x.Opis_ID == id).Count() != 0)
                throw new Exception("Alergen przypisany jest do niektórych składników");
            var opis = _db.Opis.FirstOrDefault(x => x.ID == id);
            _db.Opis.Remove(opis);
            _db.SaveChanges();
            return true;
        }

        public bool UsunPrzepis(int id)
        {
            Przepis dbPrzepis;
            var dbPrzepisy = _db.Przepis.Where(x => x.ID == id).ToList();
            if (dbPrzepisy.Count() == 0) throw new Exception("Niewłaściwe id przepisu");
            else dbPrzepis = dbPrzepisy[0];

            var skladnikiDoPrzepisow = _db.SkladnikDoPrzepis.Where(x => x.Przepis_ID == id);
            foreach(var sdp in skladnikiDoPrzepisow)
            {
                _db.SkladnikDoPrzepis.Remove(sdp);
            }

            var typyDoPrzepisow = _db.TypDoPrzepis.Where(x => x.Przepis_ID == id);
            foreach(var tdp in typyDoPrzepisow)
            {
                _db.TypDoPrzepis.Remove(tdp);
            }

            var dietyDoPrzepisow = _db.PrzepisDoDieta.Where(x => x.Przepis_ID == id);
            foreach(var dtp in dietyDoPrzepisow)
            {
                _db.PrzepisDoDieta.Remove(dtp);
            }

            Opis dbOpis;
            var dbOpisy = _db.Opis.Where(x => x.ID == id).ToList();
            if (dbOpisy.Count() == 0) throw new Exception("Niewłaściwe id przepisu");
            else dbOpis = dbOpisy[0];

            _db.Opis.Remove(dbOpis);
            _db.Przepis.Remove(dbPrzepis);

            _db.SaveChanges();
            return true;
        }

        public bool UsunSkladnik(int id)
        {
            Skladnik  dbSkladnik;
            var dbPrzepisy = _db.Skladnik.Where(x => x.ID == id).ToList();
            if (dbPrzepisy.Count() == 0) throw new Exception("Niewłaściwe id skladnika");
            else dbSkladnik = dbPrzepisy[0];

            if (_db.SkladnikDoPrzepis.Where(x => x.Skladnik_ID == id).Count() > 0)
                throw new Exception("Składnik wykorzystywany jest w przepisach");

            var alergenyDoSkladnikow = _db.AlergenDoSkladnik.Where(x => x.Skladnik_ID == id);
            foreach (var ads in alergenyDoSkladnikow)
            {
                _db.AlergenDoSkladnik.Remove(ads);
            }

            var wartosciDoSkladnikow = _db.WartosciDoSkladnikow.Where(x => x.Skladnik_ID == id);
            foreach (var wds in wartosciDoSkladnikow)
            {
                _db.WartosciDoSkladnikow.Remove(wds);
            }

            _db.Skladnik.Remove(dbSkladnik);

            _db.SaveChanges();

            return true;
        }

        public bool UsunTypDania(int id)
        {
            TypDania dbTypDania  ;
            var dbTypyDania = _db.TypDania.Where(x => x.ID == id).ToList();
            if (dbTypyDania.Count() == 0) throw new Exception("Niewłaściwe id typu dania");
            else dbTypDania = dbTypyDania[0];

            var typyDoPrzepisow = _db.TypDoPrzepis.Where(x => x.Typ_ID == id);
            foreach (var tdp in typyDoPrzepisow)
            {
                _db.TypDoPrzepis.Remove(tdp);
            }

            _db.TypDania.Remove(dbTypDania);
            return true;
        }

        public bool UsunWartoscOdrzywcza(int id)
        {
            WartoscOdzywcza dbWartoscOdz;
            var dbWartosciOdz = _db.WartoscOdzywcza.Where(x => x.ID == id).ToList();
            if (dbWartosciOdz.Count() == 0) throw new Exception("Niewłaściwe id typu dania");
            else dbWartoscOdz = dbWartosciOdz[0];

            if (_db.WartosciDoSkladnikow.Where(x => x.Wartosc_ID == id).Count() > 0) throw new Exception("Wartość jest używana w składnkach");

            _db.WartoscOdzywcza.Remove(dbWartoscOdz);

            return true;

        }
    }
}

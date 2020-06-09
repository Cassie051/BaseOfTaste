using BazaSmakuAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace BazaSmakuAPI.Concrete
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"DATA SOURCE=localhost:1521/BAZASMAKU;PERSIST SECURITY INFO=True;USER ID=BSUSER; PASSWORD=Start123");
        }

        public DbSet<Alergen> Alergen { get; set; }
        public DbSet<AlergenDoSkladnik> AlergenDoSkladnik { get; set; }
        public DbSet<Dieta> Dieta { get; set; }
        public DbSet<Jednostka> Jednostka { get; set; }
        public DbSet<Opis> Opis { get; set; }
        public DbSet<Przepis> Przepis { get; set; }
        public DbSet<PrzepisDoDieta> PrzepisDoDieta { get; set; }
        public DbSet<Skladnik> Skladnik { get; set; }
        public DbSet<SkladnikDoPrzepis> SkladnikDoPrzepis { get; set; }
        public DbSet<TypDania> TypDania { get; set; }
        public DbSet<TypDoPrzepis> TypDoPrzepis { get; set; }
        public DbSet<WartosciDoSkladnikow> WartosciDoSkladnikow { get; set; }
        public DbSet<WartoscOdzywcza> WartoscOdzywcza { get; set; }
    }
}
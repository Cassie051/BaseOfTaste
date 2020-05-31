using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace Base_of_Taste.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alergen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AlergenDoSkladnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Skladnik_ID = table.Column<int>(nullable: false),
                    Alergen_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlergenDoSkladnik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dieta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dieta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jednostka",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    Skrot = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jednostka", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Opis",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    opis = table.Column<string>(nullable: true),
                    Trudnosc = table.Column<int>(nullable: false),
                    Przygotowanie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Przepis",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    Opis_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przepis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrzepisDoDieta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Przepis_ID = table.Column<int>(nullable: false),
                    Dieta_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrzepisDoDieta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Skladnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladnik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SkladnikDoPrzepis",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Skladnik_ID = table.Column<int>(nullable: false),
                    Przepis_ID = table.Column<int>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false),
                    Jednostka_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkladnikDoPrzepis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypDania",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypDania", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypDoPrzepis",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Przepis_ID = table.Column<int>(nullable: false),
                    Typ_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypDoPrzepis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WartosciDoSkladnikow",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Skladnik_ID = table.Column<int>(nullable: false),
                    Wartosc_ID = table.Column<int>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WartosciDoSkladnikow", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WartoscOdzywcza",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WartoscOdzywcza", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergen");

            migrationBuilder.DropTable(
                name: "AlergenDoSkladnik");

            migrationBuilder.DropTable(
                name: "Dieta");

            migrationBuilder.DropTable(
                name: "Jednostka");

            migrationBuilder.DropTable(
                name: "Opis");

            migrationBuilder.DropTable(
                name: "Przepis");

            migrationBuilder.DropTable(
                name: "PrzepisDoDieta");

            migrationBuilder.DropTable(
                name: "Skladnik");

            migrationBuilder.DropTable(
                name: "SkladnikDoPrzepis");

            migrationBuilder.DropTable(
                name: "TypDania");

            migrationBuilder.DropTable(
                name: "TypDoPrzepis");

            migrationBuilder.DropTable(
                name: "WartosciDoSkladnikow");

            migrationBuilder.DropTable(
                name: "WartoscOdzywcza");
        }
    }
}

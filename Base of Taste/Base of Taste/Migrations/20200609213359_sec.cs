using Microsoft.EntityFrameworkCore.Migrations;

namespace Base_of_Taste.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Jednostka_ID",
                table: "SkladnikDoPrzepis",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Ilosc",
                table: "SkladnikDoPrzepis",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Jednostka_ID",
                table: "SkladnikDoPrzepis",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Ilosc",
                table: "SkladnikDoPrzepis",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWarsProject.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "SpeciesId", "SpeciesName" },
                values: new object[,]
                {
                    { 1, "Human" },
                    { 2, "Wookie" },
                    { 3, "Jawa" }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "WeaponId", "Damage", "Name" },
                values: new object[,]
                {
                    { 1, 100, "Ligthsaber" },
                    { 2, 30, "Blaster" },
                    { 3, 20, "Blaster Pistol" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 3);
        }
    }
}

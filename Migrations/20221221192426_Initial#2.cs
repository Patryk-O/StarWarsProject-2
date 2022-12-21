using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWarsProject.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterWeapon_Weapons_WeaponsWeaponId",
                table: "CharacterWeapon");

            migrationBuilder.RenameColumn(
                name: "WeaponsWeaponId",
                table: "CharacterWeapon",
                newName: "WeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterWeapon_WeaponsWeaponId",
                table: "CharacterWeapon",
                newName: "IX_CharacterWeapon_WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterWeapon_Weapons_WeaponId",
                table: "CharacterWeapon",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "WeaponId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterWeapon_Weapons_WeaponId",
                table: "CharacterWeapon");

            migrationBuilder.RenameColumn(
                name: "WeaponId",
                table: "CharacterWeapon",
                newName: "WeaponsWeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterWeapon_WeaponId",
                table: "CharacterWeapon",
                newName: "IX_CharacterWeapon_WeaponsWeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterWeapon_Weapons_WeaponsWeaponId",
                table: "CharacterWeapon",
                column: "WeaponsWeaponId",
                principalTable: "Weapons",
                principalColumn: "WeaponId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

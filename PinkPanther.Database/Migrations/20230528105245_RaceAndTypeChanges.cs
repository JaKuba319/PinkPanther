using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PinkPanther.Database.Migrations
{
    /// <inheritdoc />
    public partial class RaceAndTypeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Types_TypeId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_TypeId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Races_TypeId",
                table: "Races",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Types_TypeId",
                table: "Races",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Types_TypeId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_TypeId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Races");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_TypeId",
                table: "Animals",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Types_TypeId",
                table: "Animals",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

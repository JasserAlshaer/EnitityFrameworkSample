using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnitityFrameworkSample.Migrations
{
    /// <inheritdoc />
    public partial class trying : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Paitents_PaitentId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_PaitentId",
                table: "Logins");

            migrationBuilder.AlterColumn<int>(
                name: "PaitentId",
                table: "Logins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_PaitentId",
                table: "Logins",
                column: "PaitentId",
                unique: true,
                filter: "[PaitentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Paitents_PaitentId",
                table: "Logins",
                column: "PaitentId",
                principalTable: "Paitents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Paitents_PaitentId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_PaitentId",
                table: "Logins");

            migrationBuilder.AlterColumn<int>(
                name: "PaitentId",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_PaitentId",
                table: "Logins",
                column: "PaitentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Paitents_PaitentId",
                table: "Logins",
                column: "PaitentId",
                principalTable: "Paitents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

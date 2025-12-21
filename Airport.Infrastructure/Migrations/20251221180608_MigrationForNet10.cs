using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationForNet10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_passengers_PassengerId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_passengers",
                table: "passengers");

            migrationBuilder.RenameTable(
                name: "passengers",
                newName: "Passengers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "passengers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_passengers",
                table: "passengers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_passengers_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

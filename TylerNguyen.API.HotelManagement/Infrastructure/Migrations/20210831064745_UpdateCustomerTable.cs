using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Rooms_RoomId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Customers",
                newName: "RoomsId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_RoomId",
                table: "Customers",
                newName: "IX_Customers_RoomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Rooms_RoomsId",
                table: "Customers",
                column: "RoomsId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Rooms_RoomsId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "RoomsId",
                table: "Customers",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_RoomsId",
                table: "Customers",
                newName: "IX_Customers_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Rooms_RoomId",
                table: "Customers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

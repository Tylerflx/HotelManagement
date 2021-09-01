using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateCustomerRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Rooms_RoomsId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "RoomsId",
                table: "Customers",
                newName: "ROOMNO");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_RoomsId",
                table: "Customers",
                newName: "IX_Customers_ROOMNO");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Rooms_ROOMNO",
                table: "Customers",
                column: "ROOMNO",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Rooms_ROOMNO",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "ROOMNO",
                table: "Customers",
                newName: "RoomsId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_ROOMNO",
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
    }
}

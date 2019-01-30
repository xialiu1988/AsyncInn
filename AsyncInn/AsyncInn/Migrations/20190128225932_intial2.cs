using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class intial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Microwave" },
                    { 2, "Air Conditioner" },
                    { 3, "Television" },
                    { 4, "Mini Bar" },
                    { 5, "CoffeSet" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "1234 Main st", "AsyncInn Lakewood", "234-768-9078" },
                    { 2, "1235 Main st", "AsyncInn Seattle", "234-768-9078" },
                    { 3, "1234 Main st", "AsyncInn Bellevue", "234-768-9078" },
                    { 4, "1234 Main st", "AsyncInn Lynwood", "234-768-9078" },
                    { 5, "1234 Main st", "AsyncInn Tacoma", "234-768-9078" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "Layouts", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Seahawk" },
                    { 2, 0, "Rainer" },
                    { 3, 2, "Olympic" },
                    { 4, 1, "DisneyLand" },
                    { 5, 2, "MagicKingdom" },
                    { 6, 0, "AliceLake" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}

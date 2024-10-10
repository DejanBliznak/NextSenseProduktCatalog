using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextSenseProduktCatalog.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Manufacturer", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Dell", "Laptop", 1000.00m },
                    { 2, "Samsung", "Smartphone", 800.00m },
                    { 3, "Sony", "Headphones", 150.00m },
                    { 4, "Apple", "Smartwatch", 250.00m },
                    { 5, "Dell", "Monitor", 300.00m },
                    { 6, "Dell", "Keyboard", 50.00m },
                    { 7, "Dell", "Mouse", 40.00m },
                    { 8, "Apple", "Tablet", 500.00m },
                    { 9, "Samsung", "External Hard Drive", 120.00m },
                    { 10, "Sony", "Printer", 200.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextSenseProduktCatalog.Migrations
{
    public partial class AddIndexToOrderDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderDate",
                table: "Orders",
                column: "OrderDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_OrderDate",
                table: "Orders");
        }
    }
}

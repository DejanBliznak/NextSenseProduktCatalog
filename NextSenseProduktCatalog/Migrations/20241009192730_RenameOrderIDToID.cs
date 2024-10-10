using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextSenseProduktCatalog.Migrations
{
    public partial class RenameOrderIDToID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Orders",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Orders",
                newName: "OrderID");
        }
    }
}

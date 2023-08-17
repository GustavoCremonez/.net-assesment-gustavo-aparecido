using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNETAssesmentGA.Infra.Data.Migrations
{
    public partial class AddColumnIdToMongo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "_Id",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_Id",
                table: "Products");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig_aboutguncellemesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutDetails2",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AboutImage2",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AboutMapLocation",
                table: "Abouts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutDetails2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutImage2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutMapLocation",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

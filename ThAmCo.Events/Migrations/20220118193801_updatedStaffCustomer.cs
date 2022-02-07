using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class updatedStaffCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FirstAider",
                table: "Staff",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Attendance",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "VenueDto",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 5, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueDto", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VenueDto");

            migrationBuilder.DropColumn(
                name: "FirstAider",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Attendance",
                table: "Customers");
        }
    }
}

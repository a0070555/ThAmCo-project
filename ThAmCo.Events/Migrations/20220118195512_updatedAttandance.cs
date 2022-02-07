using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class updatedAttandance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attendance",
                table: "Customers");

            migrationBuilder.AddColumn<bool>(
                name: "Attendance",
                table: "GuestBookings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attendance",
                table: "GuestBookings");

            migrationBuilder.AddColumn<bool>(
                name: "Attendance",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

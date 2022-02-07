using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Catering.Migrations
{
    public partial class FoodBookingRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FoodBooking_MenuId",
                table: "FoodBooking",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodBooking_Menu_MenuId",
                table: "FoodBooking",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodBooking_Menu_MenuId",
                table: "FoodBooking");

            migrationBuilder.DropIndex(
                name: "IX_FoodBooking_MenuId",
                table: "FoodBooking");
        }
    }
}

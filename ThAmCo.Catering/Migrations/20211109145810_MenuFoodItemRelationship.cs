using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Catering.Migrations
{
    public partial class MenuFoodItemRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MenuFoodItem_FoodItemId",
                table: "MenuFoodItem",
                column: "FoodItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItem_FoodItem_FoodItemId",
                table: "MenuFoodItem",
                column: "FoodItemId",
                principalTable: "FoodItem",
                principalColumn: "FoodItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItem_FoodItem_FoodItemId",
                table: "MenuFoodItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuFoodItem_FoodItemId",
                table: "MenuFoodItem");
        }
    }
}

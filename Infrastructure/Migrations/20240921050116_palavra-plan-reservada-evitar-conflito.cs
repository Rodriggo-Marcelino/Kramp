using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class palavraplanreservadaevitarconflito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_plan_PlanId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_workout_plan_PlanId",
                table: "workout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plan",
                table: "plan");

            migrationBuilder.RenameTable(
                name: "plan",
                newName: "training_plan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_training_plan",
                table: "training_plan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_training_plan_PlanId",
                table: "users",
                column: "PlanId",
                principalTable: "training_plan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_workout_training_plan_PlanId",
                table: "workout",
                column: "PlanId",
                principalTable: "training_plan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_training_plan_PlanId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_workout_training_plan_PlanId",
                table: "workout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_training_plan",
                table: "training_plan");

            migrationBuilder.RenameTable(
                name: "training_plan",
                newName: "plan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plan",
                table: "plan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_plan_PlanId",
                table: "users",
                column: "PlanId",
                principalTable: "plan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_workout_plan_PlanId",
                table: "workout",
                column: "PlanId",
                principalTable: "plan",
                principalColumn: "Id");
        }
    }
}

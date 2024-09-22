using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renomeandotabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gym_UserGeneric_Id",
                table: "gym");

            migrationBuilder.DropForeignKey(
                name: "FK_manager_UserGeneric_Id",
                table: "manager");

            migrationBuilder.DropForeignKey(
                name: "FK_member_UserGeneric_Id",
                table: "member");

            migrationBuilder.DropForeignKey(
                name: "FK_professional_UserGeneric_Id",
                table: "professional");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGeneric_plan_PlanId",
                table: "UserGeneric");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGeneric_workout_WorkoutId",
                table: "UserGeneric");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGeneric",
                table: "UserGeneric");

            migrationBuilder.RenameTable(
                name: "UserGeneric",
                newName: "user");

            migrationBuilder.RenameIndex(
                name: "IX_UserGeneric_WorkoutId",
                table: "user",
                newName: "IX_user_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGeneric_PlanId",
                table: "user",
                newName: "IX_user_PlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_gym_user_Id",
                table: "gym",
                column: "Id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_manager_user_Id",
                table: "manager",
                column: "Id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_member_user_Id",
                table: "member",
                column: "Id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_professional_user_Id",
                table: "professional",
                column: "Id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_plan_PlanId",
                table: "user",
                column: "PlanId",
                principalTable: "plan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_workout_WorkoutId",
                table: "user",
                column: "WorkoutId",
                principalTable: "workout",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gym_user_Id",
                table: "gym");

            migrationBuilder.DropForeignKey(
                name: "FK_manager_user_Id",
                table: "manager");

            migrationBuilder.DropForeignKey(
                name: "FK_member_user_Id",
                table: "member");

            migrationBuilder.DropForeignKey(
                name: "FK_professional_user_Id",
                table: "professional");

            migrationBuilder.DropForeignKey(
                name: "FK_user_plan_PlanId",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_user_workout_WorkoutId",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "UserGeneric");

            migrationBuilder.RenameIndex(
                name: "IX_user_WorkoutId",
                table: "UserGeneric",
                newName: "IX_UserGeneric_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_user_PlanId",
                table: "UserGeneric",
                newName: "IX_UserGeneric_PlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGeneric",
                table: "UserGeneric",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_gym_UserGeneric_Id",
                table: "gym",
                column: "Id",
                principalTable: "UserGeneric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_manager_UserGeneric_Id",
                table: "manager",
                column: "Id",
                principalTable: "UserGeneric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_member_UserGeneric_Id",
                table: "member",
                column: "Id",
                principalTable: "UserGeneric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_professional_UserGeneric_Id",
                table: "professional",
                column: "Id",
                principalTable: "UserGeneric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGeneric_plan_PlanId",
                table: "UserGeneric",
                column: "PlanId",
                principalTable: "plan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGeneric_workout_WorkoutId",
                table: "UserGeneric",
                column: "WorkoutId",
                principalTable: "workout",
                principalColumn: "Id");
        }
    }
}

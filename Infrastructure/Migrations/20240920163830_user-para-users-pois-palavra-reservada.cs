using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userparauserspoispalavrareservada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "users");

            migrationBuilder.RenameIndex(
                name: "IX_user_WorkoutId",
                table: "users",
                newName: "IX_users_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_user_PlanId",
                table: "users",
                newName: "IX_users_PlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_gym_users_Id",
                table: "gym",
                column: "Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_manager_users_Id",
                table: "manager",
                column: "Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_member_users_Id",
                table: "member",
                column: "Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_professional_users_Id",
                table: "professional",
                column: "Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_plan_PlanId",
                table: "users",
                column: "PlanId",
                principalTable: "plan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_workout_WorkoutId",
                table: "users",
                column: "WorkoutId",
                principalTable: "workout",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gym_users_Id",
                table: "gym");

            migrationBuilder.DropForeignKey(
                name: "FK_manager_users_Id",
                table: "manager");

            migrationBuilder.DropForeignKey(
                name: "FK_member_users_Id",
                table: "member");

            migrationBuilder.DropForeignKey(
                name: "FK_professional_users_Id",
                table: "professional");

            migrationBuilder.DropForeignKey(
                name: "FK_users_plan_PlanId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_workout_WorkoutId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user");

            migrationBuilder.RenameIndex(
                name: "IX_users_WorkoutId",
                table: "user",
                newName: "IX_user_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_users_PlanId",
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
    }
}

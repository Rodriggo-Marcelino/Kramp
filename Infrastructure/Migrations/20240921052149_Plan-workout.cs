using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Planworkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workout_training_plan_PlanId",
                table: "workout");

            migrationBuilder.DropIndex(
                name: "IX_workout_PlanId",
                table: "workout");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "workout");

            migrationBuilder.CreateTable(
                name: "plan_workout",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plan_workout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_plan_workout_training_plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "training_plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_plan_workout_workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_plan_workout_PlanId",
                table: "plan_workout",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_plan_workout_WorkoutId",
                table: "plan_workout",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plan_workout");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                table: "workout",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_workout_PlanId",
                table: "workout",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_workout_training_plan_PlanId",
                table: "workout",
                column: "PlanId",
                principalTable: "training_plan",
                principalColumn: "Id");
        }
    }
}

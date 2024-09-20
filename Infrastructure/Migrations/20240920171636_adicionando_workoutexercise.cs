using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adicionando_workoutexercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exercise_workout_WorkoutId",
                table: "exercise");

            migrationBuilder.DropIndex(
                name: "IX_exercise_WorkoutId",
                table: "exercise");

            migrationBuilder.DropColumn(
                name: "ExerciseTimeInSeconds",
                table: "exercise");

            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "exercise");

            migrationBuilder.DropColumn(
                name: "RestTimeInSeconds",
                table: "exercise");

            migrationBuilder.DropColumn(
                name: "Series",
                table: "exercise");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "exercise");

            migrationBuilder.CreateTable(
                name: "workout_exercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestTimeInSeconds = table.Column<int>(type: "int", nullable: false),
                    ExerciseTimeInSeconds = table.Column<int>(type: "int", nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Repetitions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workout_exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workout_exercise_exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workout_exercise_workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_workout_exercise_ExerciseId",
                table: "workout_exercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_workout_exercise_WorkoutId",
                table: "workout_exercise",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workout_exercise");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseTimeInSeconds",
                table: "exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestTimeInSeconds",
                table: "exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Series",
                table: "exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkoutId",
                table: "exercise",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_exercise_WorkoutId",
                table: "exercise",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_exercise_workout_WorkoutId",
                table: "exercise",
                column: "WorkoutId",
                principalTable: "workout",
                principalColumn: "Id");
        }
    }
}

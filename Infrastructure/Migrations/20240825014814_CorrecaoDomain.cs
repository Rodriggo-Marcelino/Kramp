using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "plan",
                type: "varchar(240)",
                maxLength: 240,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(240)",
                oldMaxLength: 240);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkoutId",
                table: "member",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_member_WorkoutId",
                table: "member",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_member_workout_WorkoutId",
                table: "member",
                column: "WorkoutId",
                principalTable: "workout",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_member_workout_WorkoutId",
                table: "member");

            migrationBuilder.DropIndex(
                name: "IX_member_WorkoutId",
                table: "member");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "member");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "plan",
                type: "varchar(240)",
                maxLength: 240,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(240)",
                oldMaxLength: 240,
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class simplificandoentidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_member_plan_PlanId",
                table: "member");

            migrationBuilder.DropForeignKey(
                name: "FK_member_workout_WorkoutId",
                table: "member");

            migrationBuilder.DropIndex(
                name: "IX_member_PlanId",
                table: "member");

            migrationBuilder.DropIndex(
                name: "IX_member_WorkoutId",
                table: "member");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "TypeDocument",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "professional");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "member");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "member");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "member");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "member");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "member");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "member");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "member");

            migrationBuilder.DropColumn(
                name: "TypeDocument",
                table: "member");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "member");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "member");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "manager");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "manager");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "manager");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "manager");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "manager");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "manager");

            migrationBuilder.DropColumn(
                name: "TypeDocument",
                table: "manager");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "manager");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "gym");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "gym");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "gym");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "gym");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "gym");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "gym");

            migrationBuilder.DropColumn(
                name: "TypeDocument",
                table: "gym");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "gym");

            migrationBuilder.RenameColumn(
                name: "TempoExercicioEmSegundos",
                table: "exercise",
                newName: "RestTimeInSeconds");

            migrationBuilder.RenameColumn(
                name: "TempoDescansoEmSegundos",
                table: "exercise",
                newName: "ExerciseTimeInSeconds");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "exercise",
                newName: "Photo");

            migrationBuilder.CreateTable(
                name: "UserGeneric",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeDocument = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGeneric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGeneric_plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "plan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGeneric_workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "workout",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGeneric_PlanId",
                table: "UserGeneric",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGeneric_WorkoutId",
                table: "UserGeneric",
                column: "WorkoutId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "UserGeneric");

            migrationBuilder.RenameColumn(
                name: "RestTimeInSeconds",
                table: "exercise",
                newName: "TempoExercicioEmSegundos");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "exercise",
                newName: "Foto");

            migrationBuilder.RenameColumn(
                name: "ExerciseTimeInSeconds",
                table: "exercise",
                newName: "TempoDescansoEmSegundos");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "professional",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "professional",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "professional",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "professional",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "professional",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "professional",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeDocument",
                table: "professional",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "professional",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "member",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "member",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "member",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "member",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                table: "member",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "member",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "member",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeDocument",
                table: "member",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "member",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkoutId",
                table: "member",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "manager",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "manager",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "manager",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "manager",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "manager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "manager",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeDocument",
                table: "manager",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "manager",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "gym",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "gym",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "gym",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "gym",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "gym",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "gym",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeDocument",
                table: "gym",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "gym",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_member_PlanId",
                table: "member",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_member_WorkoutId",
                table: "member",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_member_plan_PlanId",
                table: "member",
                column: "PlanId",
                principalTable: "plan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_member_workout_WorkoutId",
                table: "member",
                column: "WorkoutId",
                principalTable: "workout",
                principalColumn: "Id");
        }
    }
}

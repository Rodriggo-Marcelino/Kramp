using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixentitygenerics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_plan_workout_training_plan_PlanId",
                table: "plan_workout");

            migrationBuilder.DropForeignKey(
                name: "FK_plan_workout_workout_WorkoutId",
                table: "plan_workout");

            migrationBuilder.DropForeignKey(
                name: "FK_professional_users_Id",
                table: "professional");

            migrationBuilder.DropForeignKey(
                name: "FK_workout_exercise_exercise_ExerciseId",
                table: "workout_exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_workout_exercise_workout_WorkoutId",
                table: "workout_exercise");

            migrationBuilder.RenameColumn(
                name: "Series",
                table: "workout_exercise",
                newName: "series");

            migrationBuilder.RenameColumn(
                name: "Repetitions",
                table: "workout_exercise",
                newName: "repetitions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "workout_exercise",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "workout_exercise",
                newName: "workout_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "workout_exercise",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "RestTimeInSeconds",
                table: "workout_exercise",
                newName: "rest_time_in_seconds");

            migrationBuilder.RenameColumn(
                name: "ExerciseTimeInSeconds",
                table: "workout_exercise",
                newName: "exercise_time_in_seconds");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "workout_exercise",
                newName: "exercise_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "workout_exercise",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_workout_exercise_WorkoutId",
                table: "workout_exercise",
                newName: "IX_workout_exercise_workout_id");

            migrationBuilder.RenameIndex(
                name: "IX_workout_exercise_ExerciseId",
                table: "workout_exercise",
                newName: "IX_workout_exercise_exercise_id");

            migrationBuilder.RenameColumn(
                name: "Period",
                table: "workout",
                newName: "period");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "workout",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "workout",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "workout",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "workout",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TargetedMuscles",
                table: "workout",
                newName: "targeted_muscles");

            migrationBuilder.RenameColumn(
                name: "SeriesCount",
                table: "workout",
                newName: "series_count");

            migrationBuilder.RenameColumn(
                name: "RepetitionCount",
                table: "workout",
                newName: "repetition_count");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "workout",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "users",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TypeDocument",
                table: "users",
                newName: "type_document");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpiryTime",
                table: "users",
                newName: "refresh_token_expiry_time");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "users",
                newName: "refresh_token");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "DocumentNumber",
                table: "users",
                newName: "document_number");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "training_plan",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "training_plan",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "training_plan",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "training_plan",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "training_plan",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "training_plan",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "training_plan",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "professional",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Job",
                table: "professional",
                newName: "job");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "professional",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserBio",
                table: "professional",
                newName: "user_bio");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "professional",
                newName: "birth_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "plan_workout",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "plan_workout",
                newName: "workout_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "plan_workout",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "plan_workout",
                newName: "plan_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "plan_workout",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_plan_workout_WorkoutId",
                table: "plan_workout",
                newName: "IX_plan_workout_workout_id");

            migrationBuilder.RenameIndex(
                name: "IX_plan_workout_PlanId",
                table: "plan_workout",
                newName: "IX_plan_workout_plan_id");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "member",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "member",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserBio",
                table: "member",
                newName: "user_bio");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "member",
                newName: "birth_date");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "manager",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "manager",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserBio",
                table: "manager",
                newName: "user_bio");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "manager",
                newName: "birth_date");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "gym",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "gym",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Video",
                table: "exercise",
                newName: "video");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "exercise",
                newName: "photo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "exercise",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "exercise",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "exercise",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "exercise",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TargetedMuscle",
                table: "exercise",
                newName: "targeted_muscle");

            migrationBuilder.RenameColumn(
                name: "SynergistMuscle",
                table: "exercise",
                newName: "synergist_muscle");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "exercise",
                newName: "created_at");

            migrationBuilder.AlterColumn<string>(
                name: "document_number",
                table: "users",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_gym_users_id",
                table: "gym",
                column: "id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_manager_users_id",
                table: "manager",
                column: "id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_member_users_id",
                table: "member",
                column: "id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_plan_workout_training_plan_plan_id",
                table: "plan_workout",
                column: "plan_id",
                principalTable: "training_plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_plan_workout_workout_workout_id",
                table: "plan_workout",
                column: "workout_id",
                principalTable: "workout",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_professional_users_id",
                table: "professional",
                column: "id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workout_exercise_exercise_exercise_id",
                table: "workout_exercise",
                column: "exercise_id",
                principalTable: "exercise",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workout_exercise_workout_workout_id",
                table: "workout_exercise",
                column: "workout_id",
                principalTable: "workout",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gym_users_id",
                table: "gym");

            migrationBuilder.DropForeignKey(
                name: "FK_manager_users_id",
                table: "manager");

            migrationBuilder.DropForeignKey(
                name: "FK_member_users_id",
                table: "member");

            migrationBuilder.DropForeignKey(
                name: "FK_plan_workout_training_plan_plan_id",
                table: "plan_workout");

            migrationBuilder.DropForeignKey(
                name: "FK_plan_workout_workout_workout_id",
                table: "plan_workout");

            migrationBuilder.DropForeignKey(
                name: "FK_professional_users_id",
                table: "professional");

            migrationBuilder.DropForeignKey(
                name: "FK_workout_exercise_exercise_exercise_id",
                table: "workout_exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_workout_exercise_workout_workout_id",
                table: "workout_exercise");

            migrationBuilder.RenameColumn(
                name: "series",
                table: "workout_exercise",
                newName: "Series");

            migrationBuilder.RenameColumn(
                name: "repetitions",
                table: "workout_exercise",
                newName: "Repetitions");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "workout_exercise",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "workout_id",
                table: "workout_exercise",
                newName: "WorkoutId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "workout_exercise",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "rest_time_in_seconds",
                table: "workout_exercise",
                newName: "RestTimeInSeconds");

            migrationBuilder.RenameColumn(
                name: "exercise_time_in_seconds",
                table: "workout_exercise",
                newName: "ExerciseTimeInSeconds");

            migrationBuilder.RenameColumn(
                name: "exercise_id",
                table: "workout_exercise",
                newName: "ExerciseId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "workout_exercise",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_workout_exercise_workout_id",
                table: "workout_exercise",
                newName: "IX_workout_exercise_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_workout_exercise_exercise_id",
                table: "workout_exercise",
                newName: "IX_workout_exercise_ExerciseId");

            migrationBuilder.RenameColumn(
                name: "period",
                table: "workout",
                newName: "Period");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "workout",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "workout",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "workout",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "workout",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "targeted_muscles",
                table: "workout",
                newName: "TargetedMuscles");

            migrationBuilder.RenameColumn(
                name: "series_count",
                table: "workout",
                newName: "SeriesCount");

            migrationBuilder.RenameColumn(
                name: "repetition_count",
                table: "workout",
                newName: "RepetitionCount");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "workout",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "type_document",
                table: "users",
                newName: "TypeDocument");

            migrationBuilder.RenameColumn(
                name: "refresh_token_expiry_time",
                table: "users",
                newName: "RefreshTokenExpiryTime");

            migrationBuilder.RenameColumn(
                name: "refresh_token",
                table: "users",
                newName: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "document_number",
                table: "users",
                newName: "DocumentNumber");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "training_plan",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "training_plan",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "training_plan",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "training_plan",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "training_plan",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "training_plan",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "training_plan",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "professional",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "job",
                table: "professional",
                newName: "Job");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "professional",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_bio",
                table: "professional",
                newName: "UserBio");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "professional",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "plan_workout",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "workout_id",
                table: "plan_workout",
                newName: "WorkoutId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "plan_workout",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "plan_id",
                table: "plan_workout",
                newName: "PlanId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "plan_workout",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_plan_workout_workout_id",
                table: "plan_workout",
                newName: "IX_plan_workout_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_plan_workout_plan_id",
                table: "plan_workout",
                newName: "IX_plan_workout_PlanId");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "member",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "member",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_bio",
                table: "member",
                newName: "UserBio");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "member",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "manager",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "manager",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_bio",
                table: "manager",
                newName: "UserBio");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "manager",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "gym",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "gym",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "video",
                table: "exercise",
                newName: "Video");

            migrationBuilder.RenameColumn(
                name: "photo",
                table: "exercise",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "exercise",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "exercise",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "exercise",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "exercise",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "targeted_muscle",
                table: "exercise",
                newName: "TargetedMuscle");

            migrationBuilder.RenameColumn(
                name: "synergist_muscle",
                table: "exercise",
                newName: "SynergistMuscle");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "exercise",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

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
                name: "FK_plan_workout_training_plan_PlanId",
                table: "plan_workout",
                column: "PlanId",
                principalTable: "training_plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_plan_workout_workout_WorkoutId",
                table: "plan_workout",
                column: "WorkoutId",
                principalTable: "workout",
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
                name: "FK_workout_exercise_exercise_ExerciseId",
                table: "workout_exercise",
                column: "ExerciseId",
                principalTable: "exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workout_exercise_workout_WorkoutId",
                table: "workout_exercise",
                column: "WorkoutId",
                principalTable: "workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

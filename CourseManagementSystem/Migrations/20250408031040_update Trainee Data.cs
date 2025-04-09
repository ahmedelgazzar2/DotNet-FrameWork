using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateTraineeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Trainee");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Grade",
                table: "Trainee",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}

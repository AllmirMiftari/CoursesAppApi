using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCoursesApi.Migrations
{
    /// <inheritdoc />
    public partial class addedCourseLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "114925bf-dc41-404f-a392-f5f0b569c0a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b76509c5-1410-47de-bc35-dfe934b0f526");

            migrationBuilder.AddColumn<string>(
                name: "CourseLink",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08eb21e8-b316-4f86-b6ad-d5fe0922a368", null, "User", "USER" },
                    { "a6aec03b-b0de-4693-8f0e-d1cd34f0a4e8", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08eb21e8-b316-4f86-b6ad-d5fe0922a368");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6aec03b-b0de-4693-8f0e-d1cd34f0a4e8");

            migrationBuilder.DropColumn(
                name: "CourseLink",
                table: "Courses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "114925bf-dc41-404f-a392-f5f0b569c0a6", null, "Admin", "ADMIN" },
                    { "b76509c5-1410-47de-bc35-dfe934b0f526", null, "User", "USER" }
                });
        }
    }
}

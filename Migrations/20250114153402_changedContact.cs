using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCoursesApi.Migrations
{
    /// <inheritdoc />
    public partial class changedContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01900c34-2b3e-4f59-a564-0727fab32510");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bae847d-28a7-4819-b87f-f0088335381b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2259acb6-8200-4d5c-8e8d-56d097e191d7", null, "Admin", "ADMIN" },
                    { "954d5d33-cd49-4ead-93c9-ebdcd739dc4a", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2259acb6-8200-4d5c-8e8d-56d097e191d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "954d5d33-cd49-4ead-93c9-ebdcd739dc4a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01900c34-2b3e-4f59-a564-0727fab32510", null, "User", "USER" },
                    { "7bae847d-28a7-4819-b87f-f0088335381b", null, "Admin", "ADMIN" }
                });
        }
    }
}

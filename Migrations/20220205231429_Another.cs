using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission6GroupAssignment.Migrations
{
    public partial class Another : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "EntryId", "CategoryID", "Completed", "DueDate", "QuadrantNumber", "Task" },
                values: new object[] { 2, 1, false, "03-02-2022", 2, "Eat Food" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "EntryId", "CategoryID", "Completed", "DueDate", "QuadrantNumber", "Task" },
                values: new object[] { 3, 2, false, "03-03-2022", 3, "Dance" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "EntryId", "CategoryID", "Completed", "DueDate", "QuadrantNumber", "Task" },
                values: new object[] { 4, 4, false, "03-05-2022", 4, "Play Piano" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "EntryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "EntryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "EntryId",
                keyValue: 4);
        }
    }
}

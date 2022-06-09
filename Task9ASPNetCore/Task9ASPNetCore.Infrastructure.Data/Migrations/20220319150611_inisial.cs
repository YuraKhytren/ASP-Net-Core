using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task9ASPNetCore.Infrastructure.Data.Migrations
{
    public partial class inisial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 3, " Learn C# Lenguage", "C#" },
                    { 4, " Learn Java Lenguage", "Java" },
                    { 5, " Learn Python Lenguage", "Python" },
                    { 6, " Learn Ruby Lenguage", "Ruby" },
                    { 7, " Learn SQL Lenguage", "SQL" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CourseId", "Name" },
                values: new object[,]
                {
                    { 2, 3, "SR-02" },
                    { 3, 4, "SR-03" },
                    { 4, 4, "SR-04" },
                    { 5, 5, "SR-05" },
                    { 6, 5, "SR-06" },
                    { 7, 6, "SR-07" },
                    { 8, 6, "SR-08" },
                    { 9, 7, "SR-09" },
                    { 10, 7, "SR-10" },
                    { 11, 3, "SR-01" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "Patronymic" },
                values: new object[,]
                {
                    { 2, "Oleh", 11, " rynt", "Olehovich" },
                    { 3, "Oleh", 11, " rynt", "Olehovich" },
                    { 4, "Oleh", 3, " rynt", "Olehovich" },
                    { 5, "Oleh", 3, " rynt", "Olehovich" },
                    { 6, "Oleh", 5, " rynt", "Olehovich" },
                    { 7, "Oleh", 5, " rynt", "Olehovich" },
                    { 8, "Oleh", 6, " rynt", "Olehovich" },
                    { 9, "Oleh", 6, " rynt", "Olehovich" },
                    { 10, "Oleh", 7, " rynt", "Olehovich" },
                    { 11, "Oleh", 7, " rynt", "Olehovich" },
                    { 12, "Oleh", 9, " rynt", "Olehovich" },
                    { 13, "Oleh", 9, " rynt", "Olehovich" },
                    { 14, "Oleh", 11, " rynt", "Olehovich" },
                    { 15, "Oleh", 11, " rynt", "Olehovich" },
                    { 16, "Oleh", 11, " rynt", "Olehovich" },
                    { 17, "Oleh", 11, " rynt", "Olehovich" },
                    { 18, "Oleh", 11, " rynt", "Olehovich" },
                    { 19, "Oleh", 11, " rynt", "Olehovich" },
                    { 20, "Oleh", 11, " rynt", "Olehovich" },
                    { 21, "Oleh", 11, " rynt", "Olehovich" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}

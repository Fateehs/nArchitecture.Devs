using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddSubTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "JavaScript" });

            migrationBuilder.InsertData(
                table: "SubTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[,]
                {
                    { 1, "WPF", 1 },
                    { 2, "ASP.NET", 1 },
                    { 3, "Spring", 2 },
                    { 4, "JSP", 2 }
                });

            migrationBuilder.InsertData(
                table: "SubTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[] { 5, "Vue", 4 });

            migrationBuilder.InsertData(
                table: "SubTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[] { 6, "React", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_SubTechnologies_ProgrammingLanguageId",
                table: "SubTechnologies",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTechnologies");

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

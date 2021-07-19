using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ch04MultiPageAmbroson.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneContacts",
                columns: table => new
                {
                    PhoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneContacts", x => x.PhoneId);
                });

            migrationBuilder.InsertData(
                table: "PhoneContacts",
                columns: new[] { "PhoneId", "Name", "Notes", "Number" },
                values: new object[] { 1, "Nick", "Its me!", "515-555-1234" });

            migrationBuilder.InsertData(
                table: "PhoneContacts",
                columns: new[] { "PhoneId", "Name", "Notes", "Number" },
                values: new object[] { 2, "Hayley", "Wifey", "515-555-4321" });

            migrationBuilder.InsertData(
                table: "PhoneContacts",
                columns: new[] { "PhoneId", "Name", "Notes", "Number" },
                values: new object[] { 3, "Griff", "Big man Griffin", "515-555-1111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneContacts");
        }
    }
}

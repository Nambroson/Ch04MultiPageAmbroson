using Microsoft.EntityFrameworkCore.Migrations;

namespace Ch04MultiPageAmbroson.Migrations
{
    public partial class Contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactId",
                table: "PhoneContacts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Name" },
                values: new object[] { "M", "Mobile" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Name" },
                values: new object[] { "W", "Work" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Name" },
                values: new object[] { "H", "Home" });

            migrationBuilder.UpdateData(
                table: "PhoneContacts",
                keyColumn: "PhoneId",
                keyValue: 1,
                column: "ContactId",
                value: "M");

            migrationBuilder.UpdateData(
                table: "PhoneContacts",
                keyColumn: "PhoneId",
                keyValue: 2,
                column: "ContactId",
                value: "W");

            migrationBuilder.UpdateData(
                table: "PhoneContacts",
                keyColumn: "PhoneId",
                keyValue: 3,
                column: "ContactId",
                value: "H");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneContacts_ContactId",
                table: "PhoneContacts",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneContacts_Contacts_ContactId",
                table: "PhoneContacts",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneContacts_Contacts_ContactId",
                table: "PhoneContacts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_PhoneContacts_ContactId",
                table: "PhoneContacts");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "PhoneContacts");
        }
    }
}

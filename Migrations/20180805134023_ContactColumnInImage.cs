using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsForever.Migrations
{
    public partial class ContactColumnInImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_ProfileImageId",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ContactId",
                table: "Images",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ProfileImageId",
                table: "Contacts",
                column: "ProfileImageId",
                unique: true,
                filter: "[ProfileImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Contacts_ContactId",
                table: "Images",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Contacts_ContactId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ContactId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ProfileImageId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ProfileImageId",
                table: "Contacts",
                column: "ProfileImageId");
        }
    }
}

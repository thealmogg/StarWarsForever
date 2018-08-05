using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsForever.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Contacts (Name, Last, IsDisplayed) VALUES ('Leia', 'Organa', 1)");
            migrationBuilder.Sql("INSERT INTO Contacts (Name, Last, IsDisplayed) VALUES ('Anakin', 'Skywalker', 0)");
            migrationBuilder.Sql("INSERT INTO Contacts (Name, Last, IsDisplayed) VALUES ('Darth', 'Vader', 1)");

            migrationBuilder.Sql("INSERT INTO Weapons (Name, ContactId) VALUES ('Weapon 1', (select id from Contacts where Name = 'Leia' and Last = 'Organa'))");
            migrationBuilder.Sql("INSERT INTO Weapons (Name, ContactId) VALUES ('Weapon 2', (select id from Contacts where Name = 'Leia' and Last = 'Organa'))");

            migrationBuilder.Sql("INSERT INTO Weapons (Name, ContactId) VALUES ('Weapon 3', (select id from Contacts where Name = 'Anakin' and Last = 'Skywalker'))");
            migrationBuilder.Sql("INSERT INTO Weapons (Name, ContactId) VALUES ('Weapon 4', (select id from Contacts where Name = 'Anakin' and Last = 'Skywalker'))");

            migrationBuilder.Sql("INSERT INTO Weapons (Name, ContactId) VALUES ('Weapon 5', (select id from Contacts where Name = 'Darth' and Last = 'Vader'))");
            migrationBuilder.Sql("INSERT INTO Weapons (Name, ContactId) VALUES ('Weapon 6', (select id from Contacts where Name = 'Darth' and Last = 'Vader'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE from Contacts WHERE Name IN ('Leia', 'Anakin', 'Darth')");
        }
    }
}

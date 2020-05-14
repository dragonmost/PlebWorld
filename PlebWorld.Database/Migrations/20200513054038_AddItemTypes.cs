using Microsoft.EntityFrameworkCore.Migrations;

namespace PlebWorld.Database.Migrations
{
    public partial class AddItemTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Sword" });

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "Spear" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTypes");
        }
    }
}

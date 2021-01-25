using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample.Game.Entities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Account = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    AccountType = table.Column<string>(type: "varchar(10) CHARACTER SET utf8mb4", maxLength: 10, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nickname = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: true),
                    Classes = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlayerId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Account", "AccountType", "DateCreated" },
                values: new object[] { new Guid("5b78c67b-9e09-48a1-88e9-b24eab8809ce"), "mw2021", "Free", new DateTime(2021, 1, 12, 19, 7, 26, 474, DateTimeKind.Local).AddTicks(5302) });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Account", "AccountType", "DateCreated" },
                values: new object[] { new Guid("05223341-774c-4ba0-9e29-4107f30c1819"), "dc2021", "Free", new DateTime(2021, 1, 12, 19, 7, 26, 475, DateTimeKind.Local).AddTicks(4456) });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "Classes", "DateCreated", "Level", "Nickname", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("b845ff6a-770a-4ebb-971c-435c6a5ada1b"), "Mage", new DateTime(2021, 1, 12, 19, 7, 26, 475, DateTimeKind.Local).AddTicks(5981), 99, "Code Man", new Guid("5b78c67b-9e09-48a1-88e9-b24eab8809ce") },
                    { new Guid("7174670a-84ef-4d2f-983b-f132dcaf38a3"), "Warrior", new DateTime(2021, 1, 12, 19, 7, 26, 475, DateTimeKind.Local).AddTicks(6279), 90, "Iron Man", new Guid("5b78c67b-9e09-48a1-88e9-b24eab8809ce") },
                    { new Guid("9957e487-ff8e-4033-b4c9-038b86b0cdca"), "Druid", new DateTime(2021, 1, 12, 19, 7, 26, 475, DateTimeKind.Local).AddTicks(6283), 80, "Spider Man", new Guid("5b78c67b-9e09-48a1-88e9-b24eab8809ce") },
                    { new Guid("be39e62d-b97c-455d-99a2-c441426a09cb"), "Death Knight", new DateTime(2021, 1, 12, 19, 7, 26, 475, DateTimeKind.Local).AddTicks(6285), 90, "Batman", new Guid("05223341-774c-4ba0-9e29-4107f30c1819") },
                    { new Guid("78e39d8e-eb3a-4a7b-afcc-a27e28077092"), "Paladin", new DateTime(2021, 1, 12, 19, 7, 26, 475, DateTimeKind.Local).AddTicks(6301), 99, "Superman", new Guid("05223341-774c-4ba0-9e29-4107f30c1819") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlayerId",
                table: "Characters",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}

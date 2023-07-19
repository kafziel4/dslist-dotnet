using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PostgresMigrations.Migrations
{
    /// <inheritdoc />
    public partial class CreateBelonging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Belongings",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    GameListId = table.Column<long>(type: "bigint", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Belongings", x => new { x.GameId, x.GameListId });
                    table.ForeignKey(
                        name: "FK_Belongings_GameLists_GameListId",
                        column: x => x.GameListId,
                        principalTable: "GameLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Belongings_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Belongings",
                columns: new[] { "GameId", "GameListId", "Position" },
                values: new object[,]
                {
                    { 1L, 1L, 0 },
                    { 2L, 1L, 1 },
                    { 3L, 1L, 2 },
                    { 4L, 1L, 3 },
                    { 5L, 1L, 4 },
                    { 6L, 2L, 0 },
                    { 7L, 2L, 1 },
                    { 8L, 2L, 2 },
                    { 9L, 2L, 3 },
                    { 10L, 2L, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Belongings_GameListId",
                table: "Belongings",
                column: "GameListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Belongings");
        }
    }
}

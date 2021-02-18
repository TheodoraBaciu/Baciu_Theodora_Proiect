using Microsoft.EntityFrameworkCore.Migrations;

namespace Baciu_Theodora_Proiect.Migrations
{
    public partial class FlowerBoxCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "FlowerBox",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "FlowerBox",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FlowerBoxCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerBoxID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerBoxCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FlowerBoxCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowerBoxCategory_FlowerBox_FlowerBoxID",
                        column: x => x.FlowerBoxID,
                        principalTable: "FlowerBox",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowerBox_StoreID",
                table: "FlowerBox",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerBoxCategory_CategoryID",
                table: "FlowerBoxCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerBoxCategory_FlowerBoxID",
                table: "FlowerBoxCategory",
                column: "FlowerBoxID");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerBox_Store_StoreID",
                table: "FlowerBox",
                column: "StoreID",
                principalTable: "Store",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerBox_Store_StoreID",
                table: "FlowerBox");

            migrationBuilder.DropTable(
                name: "FlowerBoxCategory");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_FlowerBox_StoreID",
                table: "FlowerBox");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "FlowerBox");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "FlowerBox");
        }
    }
}

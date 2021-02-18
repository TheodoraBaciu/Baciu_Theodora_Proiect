using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Baciu_Theodora_Proiect.Migrations
{
    public partial class AparitionDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AparitionDate",
                table: "FlowerBox",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AparitionDate",
                table: "FlowerBox");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessFoods.Infrastructure.Data.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Failure = table.Column<bool>(type: "bit", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    Imported_t = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_t = table.Column<long>(type: "bigint", nullable: false),
                    Last_modified_t = table.Column<long>(type: "bigint", nullable: false),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brands = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Labels = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purchase_places = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Traces = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serving_size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serving_quantity = table.Column<double>(type: "float", nullable: true),
                    Nutriscore_score = table.Column<int>(type: "int", nullable: true),
                    Nutriscore_grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main_category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportHistory");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

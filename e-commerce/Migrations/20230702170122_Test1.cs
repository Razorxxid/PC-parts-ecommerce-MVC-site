using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfRelease = table.Column<int>(type: "int", nullable: true),
                    BaseClockSpeed = table.Column<float>(type: "real", nullable: true),
                    BoostClockSpeed = table.Column<float>(type: "real", nullable: true),
                    Assembler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryInGB = table.Column<int>(type: "int", nullable: true),
                    VideoCard_YearOfRelease = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

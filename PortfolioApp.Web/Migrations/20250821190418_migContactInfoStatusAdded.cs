using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class migContactInfoStatusAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "ContactInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ContactInfos");
        }
    }
}

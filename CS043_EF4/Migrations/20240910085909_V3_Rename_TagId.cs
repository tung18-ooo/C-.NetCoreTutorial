using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS043_EF4.Migrations
{
    /// <inheritdoc />
    public partial class V3_Rename_TagId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagIdNew",
                table: "tags",
                newName: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "tags",
                newName: "TagIdNew");
        }
    }
}

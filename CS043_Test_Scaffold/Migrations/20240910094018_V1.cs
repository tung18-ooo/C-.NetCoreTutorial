﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS043_Test_Scaffold.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tendaydu",
                table: "Cungcap",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Cungcap",
                newName: "Tendaydu");
        }
    }
}

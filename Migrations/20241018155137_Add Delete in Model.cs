﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteinModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Students");
        }
    }
}

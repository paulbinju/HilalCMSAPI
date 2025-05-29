using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class apr11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishToTA",
                table: "Articles",
                newName: "ShowInTA");

            migrationBuilder.RenameColumn(
                name: "PublishToMAG",
                table: "Articles",
                newName: "ShowInMAG");

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Published",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "ShowInTA",
                table: "Articles",
                newName: "PublishToTA");

            migrationBuilder.RenameColumn(
                name: "ShowInMAG",
                table: "Articles",
                newName: "PublishToMAG");
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeallySpeaking.Migrations
{
    public partial class MVCRunThrough_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Teaser",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Badges");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Badges",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Badges",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "Badges",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Headline",
                table: "Articles",
                maxLength: 125,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Badges");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Badges",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Badges",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "Badges",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Headline",
                table: "Articles",
                nullable: true);
        }
    }
}

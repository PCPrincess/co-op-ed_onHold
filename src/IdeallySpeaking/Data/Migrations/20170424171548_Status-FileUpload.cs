using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeallySpeaking.Migrations
{
    public partial class StatusFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Badges");

            migrationBuilder.AddColumn<bool>(
                name: "CanPost",
                table: "Comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "BadgeImage",
                table: "Badges",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ArticlePhoto",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEightySixed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnTimeOut",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusChangeDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanPost",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BadgeImage",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "ArticlePhoto",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsEightySixed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsOnTimeOut",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StatusChangeDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Badges",
                nullable: true);
        }
    }
}

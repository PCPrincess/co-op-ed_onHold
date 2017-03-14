using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeallySpeaking.Data.Migrations
{
    public partial class SpruceUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_ApplicationUserId1",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CommentId1",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_ApplicationUserId",
                table: "ApplicationUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_ArticleId",
                table: "ApplicationUser",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_CommentId1",
                table: "ApplicationUser",
                column: "CommentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_ApplicationUserId",
                table: "ApplicationUser",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Articles_ArticleId",
                table: "ApplicationUser",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_ApplicationUser_CommentId1",
                table: "ApplicationUser",
                column: "CommentId1",
                principalTable: "ApplicationUser",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_ApplicationUserId",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Articles_ArticleId",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_ApplicationUser_CommentId1",
                table: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_ApplicationUserId",
                table: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_ArticleId",
                table: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_CommentId1",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "CommentId1",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ApplicationUser",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_ApplicationUserId1",
                table: "ApplicationUser",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUser",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

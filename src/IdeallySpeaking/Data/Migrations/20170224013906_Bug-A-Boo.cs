using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeallySpeaking.Data.Migrations
{
    public partial class BugABoo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Articles_ArticleId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_CommentId1",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ArticleId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CommentId1",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CommentId1",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AuthorUserId",
                table: "Articles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId1",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorUserId",
                table: "Articles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ArticleId",
                table: "Comment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentId1",
                table: "Comment",
                column: "CommentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Articles_ArticleId",
                table: "Comment",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_CommentId1",
                table: "Comment",
                column: "CommentId1",
                principalTable: "Comment",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

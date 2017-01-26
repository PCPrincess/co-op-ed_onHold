using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeallySpeaking.Data.Migrations
{
    public partial class CommentViewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_ReplyCommentId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ReplyCommentId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Minus",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Plus",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ReplyCommentId",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Comment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "Minus",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Plus",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReplyCommentId",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ReplyCommentId",
                table: "Comment",
                column: "ReplyCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_ReplyCommentId",
                table: "Comment",
                column: "ReplyCommentId",
                principalTable: "Comment",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

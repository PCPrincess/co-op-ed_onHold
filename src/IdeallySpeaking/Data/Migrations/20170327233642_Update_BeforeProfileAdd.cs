using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeallySpeaking.Data.Migrations
{
    public partial class Update_BeforeProfileAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Articles_ArticleId",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_ApplicationUser_CommentId1",
                table: "ApplicationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "ApplicationUser",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUser",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "ApplicationUser",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentId1",
                table: "ApplicationUser",
                column: "CommentId1",
                principalTable: "ApplicationUser",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_CommentId1",
                table: "ApplicationUser",
                newName: "IX_Comments_CommentId1");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_ArticleId",
                table: "ApplicationUser",
                newName: "IX_Comments_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_ApplicationUserId1",
                table: "ApplicationUser",
                newName: "IX_Comments_ApplicationUserId1");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentId1",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_ApplicationUserId1",
                table: "Comments",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Articles_ArticleId",
                table: "Comments",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_ApplicationUser_CommentId1",
                table: "Comments",
                column: "CommentId1",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentId1",
                table: "Comments",
                newName: "IX_ApplicationUser_CommentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                newName: "IX_ApplicationUser_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ApplicationUserId1",
                table: "Comments",
                newName: "IX_ApplicationUser_ApplicationUserId1");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "ApplicationUser");
        }
    }
}

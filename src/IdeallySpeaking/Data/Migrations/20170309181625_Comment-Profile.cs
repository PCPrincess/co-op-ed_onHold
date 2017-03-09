using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdeallySpeaking.Data.Migrations
{
    public partial class CommentProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId1",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_ApplicationUserId1",
                table: "Comment",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ApplicationUserId1",
                table: "Comment",
                newName: "IX_ApplicationUser_ApplicationUserId1");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "ApplicationUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "ApplicationUser",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUser",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_ApplicationUserId1",
                table: "ApplicationUser",
                newName: "IX_Comment_ApplicationUserId1");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "Comment");
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IdeallySpeaking.Migrations
{
    public partial class ProfileModelChangeEtc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_AspNetUsers_ApplicationUserId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ApplicationUserId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Badges_ApplicationUserId",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Badges");

            migrationBuilder.CreateTable(
                name: "CommentsRating",
                columns: table => new
                {
                    Rating = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsRating", x => x.Rating);
                });

            migrationBuilder.AddColumn<string>(
                name: "CommentAuthorId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentsRatingRating",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasReply",
                table: "Comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BadgeOwnerId",
                table: "Badges",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentAuthorId",
                table: "Comments",
                column: "CommentAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentsRatingRating",
                table: "Comments",
                column: "CommentsRatingRating");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_BadgeOwnerId",
                table: "Badges",
                column: "BadgeOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_AspNetUsers_BadgeOwnerId",
                table: "Badges",
                column: "BadgeOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CommentAuthorId",
                table: "Comments",
                column: "CommentAuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CommentsRating_CommentsRatingRating",
                table: "Comments",
                column: "CommentsRatingRating",
                principalTable: "CommentsRating",
                principalColumn: "Rating",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_AspNetUsers_BadgeOwnerId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CommentAuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CommentsRating_CommentsRatingRating",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentAuthorId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentsRatingRating",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Badges_BadgeOwnerId",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "CommentAuthorId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentsRatingRating",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "HasReply",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BadgeOwnerId",
                table: "Badges");

            migrationBuilder.DropTable(
                name: "CommentsRating");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Badges",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserId1",
                table: "Comments",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_ApplicationUserId",
                table: "Badges",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_AspNetUsers_ApplicationUserId",
                table: "Badges",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId1",
                table: "Comments",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

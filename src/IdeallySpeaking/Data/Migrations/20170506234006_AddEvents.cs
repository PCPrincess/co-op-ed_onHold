using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IdeallySpeaking.Migrations
{
    public partial class AddEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventDescription = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: true),
                    EventOrganizerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_EventOrganizerId",
                        column: x => x.EventOrganizerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "EventViewModelEventId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EventViewModelEventId",
                table: "AspNetUsers",
                column: "EventViewModelEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventOrganizerId",
                table: "Events",
                column: "EventOrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Events_EventViewModelEventId",
                table: "AspNetUsers",
                column: "EventViewModelEventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Events_EventViewModelEventId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EventViewModelEventId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EventViewModelEventId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}

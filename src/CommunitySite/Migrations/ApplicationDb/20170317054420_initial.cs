using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CommunitySite.Migrations.ApplicationDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkMembers",
                columns: table => new
                {
                    ParkMemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DogBreed = table.Column<string>(nullable: true),
                    DogName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    ForumAlias = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkMembers", x => x.ParkMemberID);
                });

            migrationBuilder.CreateTable(
                name: "ForumMessages",
                columns: table => new
                {
                    ForumMessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(maxLength: 20, nullable: false),
                    UserParkMemberID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumMessages", x => x.ForumMessageID);
                    table.ForeignKey(
                        name: "FK_ForumMessages_ParkMembers_UserParkMemberID",
                        column: x => x.UserParkMemberID,
                        principalTable: "ParkMembers",
                        principalColumn: "ParkMemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    ReplyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    ForumMessageID = table.Column<int>(nullable: true),
                    From = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.ReplyID);
                    table.ForeignKey(
                        name: "FK_Reply_ForumMessages_ForumMessageID",
                        column: x => x.ForumMessageID,
                        principalTable: "ForumMessages",
                        principalColumn: "ForumMessageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumMessages_UserParkMemberID",
                table: "ForumMessages",
                column: "UserParkMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_ForumMessageID",
                table: "Reply",
                column: "ForumMessageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "ForumMessages");

            migrationBuilder.DropTable(
                name: "ParkMembers");
        }
    }
}

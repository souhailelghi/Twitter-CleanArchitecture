using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Twitter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tweets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TweetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { new Guid("a37a1218-5b95-4779-a1a5-1f3ef57998d9"), "jane@example.com", "Jane Smith", "password2", "0987654321" },
                    { new Guid("f0256865-2fbb-4b76-8848-d0330dfaf011"), "john@example.com", "John Doe", "password1", "1234567890" }
                });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "Id", "CreatedAt", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("6e2651e9-a898-4a3d-978e-6a8505d5de98"), new DateTime(2024, 9, 7, 2, 11, 59, 814, DateTimeKind.Local).AddTicks(9229), "Learning EF Core!", new Guid("a37a1218-5b95-4779-a1a5-1f3ef57998d9") },
                    { new Guid("cbbc0ebf-c533-4f0a-a9e9-4abde3860fe3"), new DateTime(2024, 9, 7, 2, 11, 59, 807, DateTimeKind.Local).AddTicks(7681), "Hello, world!", new Guid("f0256865-2fbb-4b76-8848-d0330dfaf011") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Text", "TweetId", "UserId" },
                values: new object[,]
                {
                    { new Guid("679fdb1e-e7d1-4382-8489-a8b56d915968"), "Great tweet!", new Guid("cbbc0ebf-c533-4f0a-a9e9-4abde3860fe3"), new Guid("a37a1218-5b95-4779-a1a5-1f3ef57998d9") },
                    { new Guid("6c78d220-7ec9-4581-b71a-345bd07f380e"), "Thanks for the info!", new Guid("6e2651e9-a898-4a3d-978e-6a8505d5de98"), new Guid("f0256865-2fbb-4b76-8848-d0330dfaf011") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TweetId",
                table: "Comments",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_UserId",
                table: "Tweets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

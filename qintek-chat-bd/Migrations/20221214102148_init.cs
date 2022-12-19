using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace qintek_chat_bd.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    groupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    grupo = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    userID_A = table.Column<int>(type: "int", nullable: false),
                    userID_B = table.Column<int>(type: "int", nullable: false),
                    dateCreated = table.Column<DateTimeOffset>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.groupID);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    messageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    message = table.Column<string>(type: "text", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: false),
                    group = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    readed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.messageID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    nick = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    dateLogged = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    connectionId = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    messages = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}

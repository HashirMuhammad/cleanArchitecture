using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cleanArchSql.Migrations
{
    /// <inheritdoc />
    public partial class formtable_users_again6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormDataUser");

            migrationBuilder.CreateTable(
                name: "UserName",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserName", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FormDataUserName",
                columns: table => new
                {
                    AssignedUsersUserId = table.Column<int>(type: "int", nullable: false),
                    FormDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormDataUserName", x => new { x.AssignedUsersUserId, x.FormDataId });
                    table.ForeignKey(
                        name: "FK_FormDataUserName_FormDatas_FormDataId",
                        column: x => x.FormDataId,
                        principalTable: "FormDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormDataUserName_UserName_AssignedUsersUserId",
                        column: x => x.AssignedUsersUserId,
                        principalTable: "UserName",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormDataUserName_FormDataId",
                table: "FormDataUserName",
                column: "FormDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormDataUserName");

            migrationBuilder.DropTable(
                name: "UserName");

            migrationBuilder.CreateTable(
                name: "FormDataUser",
                columns: table => new
                {
                    AssignedUsersId = table.Column<int>(type: "int", nullable: false),
                    FormDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormDataUser", x => new { x.AssignedUsersId, x.FormDataId });
                    table.ForeignKey(
                        name: "FK_FormDataUser_FormDatas_FormDataId",
                        column: x => x.FormDataId,
                        principalTable: "FormDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormDataUser_Users_AssignedUsersId",
                        column: x => x.AssignedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormDataUser_FormDataId",
                table: "FormDataUser",
                column: "FormDataId");
        }
    }
}

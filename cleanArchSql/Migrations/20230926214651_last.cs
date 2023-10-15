using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cleanArchSql.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedUsers_FormDatas_FormDataId",
                table: "AssignedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedUsers_Users_UserId",
                table: "AssignedUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignedUsers",
                table: "AssignedUsers");

            migrationBuilder.DropIndex(
                name: "IX_AssignedUsers_FormDataId",
                table: "AssignedUsers");

            migrationBuilder.DropIndex(
                name: "IX_AssignedUsers_UserId",
                table: "AssignedUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AssignedUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AssignedUsers");

            migrationBuilder.RenameTable(
                name: "AssignedUsers",
                newName: "AssignedUser");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AssignedUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignedUser",
                table: "AssignedUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AssignedUserFormData",
                columns: table => new
                {
                    AssignedUsersId = table.Column<int>(type: "int", nullable: false),
                    FormDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedUserFormData", x => new { x.AssignedUsersId, x.FormDataId });
                    table.ForeignKey(
                        name: "FK_AssignedUserFormData_AssignedUser_AssignedUsersId",
                        column: x => x.AssignedUsersId,
                        principalTable: "AssignedUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedUserFormData_FormDatas_FormDataId",
                        column: x => x.FormDataId,
                        principalTable: "FormDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedUserFormData_FormDataId",
                table: "AssignedUserFormData",
                column: "FormDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedUserFormData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignedUser",
                table: "AssignedUser");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AssignedUser");

            migrationBuilder.RenameTable(
                name: "AssignedUser",
                newName: "AssignedUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AssignedUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AssignedUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignedUsers",
                table: "AssignedUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedUsers_FormDataId",
                table: "AssignedUsers",
                column: "FormDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedUsers_UserId",
                table: "AssignedUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedUsers_FormDatas_FormDataId",
                table: "AssignedUsers",
                column: "FormDataId",
                principalTable: "FormDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedUsers_Users_UserId",
                table: "AssignedUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

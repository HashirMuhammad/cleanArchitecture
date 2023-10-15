using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cleanArchSql.Migrations
{
    /// <inheritdoc />
    public partial class formtable_users_again5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFormData_FormDatas_FormDatasId",
                table: "UserFormData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFormData_Users_AssignedUsersId",
                table: "UserFormData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFormData",
                table: "UserFormData");

            migrationBuilder.RenameTable(
                name: "UserFormData",
                newName: "FormDataUser");

            migrationBuilder.RenameColumn(
                name: "FormDatasId",
                table: "FormDataUser",
                newName: "FormDataId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFormData_FormDatasId",
                table: "FormDataUser",
                newName: "IX_FormDataUser_FormDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormDataUser",
                table: "FormDataUser",
                columns: new[] { "AssignedUsersId", "FormDataId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FormDataUser_FormDatas_FormDataId",
                table: "FormDataUser",
                column: "FormDataId",
                principalTable: "FormDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormDataUser_Users_AssignedUsersId",
                table: "FormDataUser",
                column: "AssignedUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormDataUser_FormDatas_FormDataId",
                table: "FormDataUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FormDataUser_Users_AssignedUsersId",
                table: "FormDataUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormDataUser",
                table: "FormDataUser");

            migrationBuilder.RenameTable(
                name: "FormDataUser",
                newName: "UserFormData");

            migrationBuilder.RenameColumn(
                name: "FormDataId",
                table: "UserFormData",
                newName: "FormDatasId");

            migrationBuilder.RenameIndex(
                name: "IX_FormDataUser_FormDataId",
                table: "UserFormData",
                newName: "IX_UserFormData_FormDatasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFormData",
                table: "UserFormData",
                columns: new[] { "AssignedUsersId", "FormDatasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFormData_FormDatas_FormDatasId",
                table: "UserFormData",
                column: "FormDatasId",
                principalTable: "FormDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFormData_Users_AssignedUsersId",
                table: "UserFormData",
                column: "AssignedUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

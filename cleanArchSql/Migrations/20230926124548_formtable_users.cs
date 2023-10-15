using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cleanArchSql.Migrations
{
    /// <inheritdoc />
    public partial class formtable_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_FormDatas_FormDataId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FormDataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FormDataId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "AssignedUsers",
                table: "FormDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedUsers",
                table: "FormDatas");

            migrationBuilder.AddColumn<int>(
                name: "FormDataId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FormDataId",
                table: "Users",
                column: "FormDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FormDatas_FormDataId",
                table: "Users",
                column: "FormDataId",
                principalTable: "FormDatas",
                principalColumn: "Id");
        }
    }
}

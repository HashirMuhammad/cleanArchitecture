using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cleanArchSql.Migrations
{
    /// <inheritdoc />
    public partial class form_table_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormDataId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FormDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageDesignFile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormDatas", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_FormDatas_FormDataId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "FormDatas");

            migrationBuilder.DropIndex(
                name: "IX_Users_FormDataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FormDataId",
                table: "Users");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramBotAgenta.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Todos",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UsersId",
                table: "Todos",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Users_UsersId",
                table: "Todos",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Users_UsersId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_UsersId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Todos",
                newName: "UserName");
        }
    }
}

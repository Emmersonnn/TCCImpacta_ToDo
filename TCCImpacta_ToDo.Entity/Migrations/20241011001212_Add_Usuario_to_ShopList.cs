using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCCImpacta_ToDo.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Add_Usuario_to_ShopList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ShopList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopList_UserId",
                table: "ShopList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopList_Usuarios_UserId",
                table: "ShopList",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopList_Usuarios_UserId",
                table: "ShopList");

            migrationBuilder.DropIndex(
                name: "IX_ShopList_UserId",
                table: "ShopList");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShopList");
        }
    }
}

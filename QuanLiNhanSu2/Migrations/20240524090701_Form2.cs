using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLiNhanSu2.Migrations
{
    public partial class Form2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Form_User_UserId",
                table: "Form");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Form",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Form_UserId",
                table: "Form",
                newName: "IX_Form_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Form_AspNetUsers_Id",
                table: "Form",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Form_AspNetUsers_Id",
                table: "Form");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Form",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Form_Id",
                table: "Form",
                newName: "IX_Form_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Form_User_UserId",
                table: "Form",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

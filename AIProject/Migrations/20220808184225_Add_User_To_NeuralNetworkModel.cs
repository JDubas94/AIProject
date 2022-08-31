using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIProject.Migrations
{
    public partial class Add_User_To_NeuralNetworkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "NeuralNetworkModels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "NeuralNetworkModels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NeuralNetworkModels_UserId",
                table: "NeuralNetworkModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NeuralNetworkModels_AspNetUsers_UserId",
                table: "NeuralNetworkModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NeuralNetworkModels_AspNetUsers_UserId",
                table: "NeuralNetworkModels");

            migrationBuilder.DropIndex(
                name: "IX_NeuralNetworkModels_UserId",
                table: "NeuralNetworkModels");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "NeuralNetworkModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NeuralNetworkModels");
        }
    }
}

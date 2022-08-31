using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIProject.Migrations
{
    public partial class Add_NeuralNetworkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NeuralNetworkModels_AspNetUsers_UserId",
                table: "NeuralNetworkModels");

            migrationBuilder.DropForeignKey(
                name: "FK_NeuralNetworkModels_NeuralNetworkTypes_TypeNNId",
                table: "NeuralNetworkModels");

            migrationBuilder.DropIndex(
                name: "IX_NeuralNetworkModels_TypeNNId",
                table: "NeuralNetworkModels");

            migrationBuilder.DropIndex(
                name: "IX_NeuralNetworkModels_UserId",
                table: "NeuralNetworkModels");

            migrationBuilder.DropColumn(
                name: "TypeNNId",
                table: "NeuralNetworkModels");

            migrationBuilder.RenameColumn(
                name: "NewronsLayer",
                table: "NeuralNetworkModels",
                newName: "NewronsInLayer");

            migrationBuilder.RenameColumn(
                name: "Layer",
                table: "NeuralNetworkModels",
                newName: "Layers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "NeuralNetworkTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "NeuralNetworkTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "NeuralNetworkModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PersentageTestSet",
                table: "NeuralNetworkModels",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "NeuralNetworkModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "NeuralNetworkModels");

            migrationBuilder.RenameColumn(
                name: "NewronsInLayer",
                table: "NeuralNetworkModels",
                newName: "NewronsLayer");

            migrationBuilder.RenameColumn(
                name: "Layers",
                table: "NeuralNetworkModels",
                newName: "Layer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "NeuralNetworkTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "NeuralNetworkTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "NeuralNetworkModels",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PersentageTestSet",
                table: "NeuralNetworkModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeNNId",
                table: "NeuralNetworkModels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NeuralNetworkModels_TypeNNId",
                table: "NeuralNetworkModels",
                column: "TypeNNId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_NeuralNetworkModels_NeuralNetworkTypes_TypeNNId",
                table: "NeuralNetworkModels",
                column: "TypeNNId",
                principalTable: "NeuralNetworkTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

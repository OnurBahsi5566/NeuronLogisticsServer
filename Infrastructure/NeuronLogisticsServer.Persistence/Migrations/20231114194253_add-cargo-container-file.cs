using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuronLogisticsServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addcargocontainerfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CargoContainerId",
                table: "UploadFiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UploadFiles_CargoContainerId",
                table: "UploadFiles",
                column: "CargoContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadFiles_CargoContainers_CargoContainerId",
                table: "UploadFiles",
                column: "CargoContainerId",
                principalTable: "CargoContainers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadFiles_CargoContainers_CargoContainerId",
                table: "UploadFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadFiles_CargoContainerId",
                table: "UploadFiles");

            migrationBuilder.DropColumn(
                name: "CargoContainerId",
                table: "UploadFiles");
        }
    }
}

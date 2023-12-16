using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuronLogisticsServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CargoContainerCargoContainerFile",
                columns: table => new
                {
                    CargoContainerFilesId = table.Column<Guid>(type: "uuid", nullable: false),
                    CargoContainersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoContainerCargoContainerFile", x => new { x.CargoContainerFilesId, x.CargoContainersId });
                    table.ForeignKey(
                        name: "FK_CargoContainerCargoContainerFile_CargoContainers_CargoConta~",
                        column: x => x.CargoContainersId,
                        principalTable: "CargoContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoContainerCargoContainerFile_UploadFiles_CargoContainer~",
                        column: x => x.CargoContainerFilesId,
                        principalTable: "UploadFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoContainerCargoContainerFile_CargoContainersId",
                table: "CargoContainerCargoContainerFile",
                column: "CargoContainersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoContainerCargoContainerFile");

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
    }
}

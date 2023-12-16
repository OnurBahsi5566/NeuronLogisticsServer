using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuronLogisticsServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    YearOfConstruction = table.Column<string>(type: "text", nullable: false),
                    Imo = table.Column<string>(type: "text", nullable: false),
                    FlagName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voyages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CargoContainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Teu = table.Column<double>(type: "double precision", nullable: false),
                    VesselId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoContainers_Vessels_VesselId",
                        column: x => x.VesselId,
                        principalTable: "Vessels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VesselVoyage",
                columns: table => new
                {
                    VesselsId = table.Column<Guid>(type: "uuid", nullable: false),
                    VoyagesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselVoyage", x => new { x.VesselsId, x.VoyagesId });
                    table.ForeignKey(
                        name: "FK_VesselVoyage_Vessels_VesselsId",
                        column: x => x.VesselsId,
                        principalTable: "Vessels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VesselVoyage_Voyages_VoyagesId",
                        column: x => x.VoyagesId,
                        principalTable: "Voyages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoContainers_VesselId",
                table: "CargoContainers",
                column: "VesselId");

            migrationBuilder.CreateIndex(
                name: "IX_VesselVoyage_VoyagesId",
                table: "VesselVoyage",
                column: "VoyagesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoContainers");

            migrationBuilder.DropTable(
                name: "VesselVoyage");

            migrationBuilder.DropTable(
                name: "Vessels");

            migrationBuilder.DropTable(
                name: "Voyages");
        }
    }
}

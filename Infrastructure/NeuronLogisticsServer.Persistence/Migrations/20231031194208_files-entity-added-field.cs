using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuronLogisticsServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class filesentityaddedfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillOfLadingNo",
                table: "UploadFiles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "UploadFiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "UploadFiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "UploadFiles",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillOfLadingNo",
                table: "UploadFiles");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "UploadFiles");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "UploadFiles");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "UploadFiles");
        }
    }
}

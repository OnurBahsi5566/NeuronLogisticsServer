using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuronLogisticsServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addstoragefieldtofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Storage",
                table: "UploadFiles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Storage",
                table: "UploadFiles");
        }
    }
}

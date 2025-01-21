using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUI.Migrations
{
    /// <inheritdoc />
    public partial class BugFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Entities_ServiceLayerId",
                table: "Services");

            migrationBuilder.CreateIndex(
                name: "IX_Services_RelatedEntityId",
                table: "Services",
                column: "RelatedEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Entities_RelatedEntityId",
                table: "Services",
                column: "RelatedEntityId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Entities_RelatedEntityId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_RelatedEntityId",
                table: "Services");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Entities_ServiceLayerId",
                table: "Services",
                column: "ServiceLayerId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

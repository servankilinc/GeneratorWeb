using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDtoField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DtoFieldMaps");

            migrationBuilder.CreateTable(
                name: "DtoFields",
                columns: table => new
                {
                    DtoId = table.Column<int>(type: "INTEGER", nullable: false),
                    SourceFieldId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoFields", x => new { x.DtoId, x.SourceFieldId });
                    table.ForeignKey(
                        name: "FK_DtoFields_Dtos_DtoId",
                        column: x => x.DtoId,
                        principalTable: "Dtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DtoFields_Fields_SourceFieldId",
                        column: x => x.SourceFieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DtoFields_SourceFieldId",
                table: "DtoFields",
                column: "SourceFieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DtoFields");

            migrationBuilder.CreateTable(
                name: "DtoFieldMaps",
                columns: table => new
                {
                    DtoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoFieldMaps", x => new { x.DtoId, x.FieldId });
                    table.ForeignKey(
                        name: "FK_DtoFieldMaps_Dtos_DtoId",
                        column: x => x.DtoId,
                        principalTable: "Dtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DtoFieldMaps_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DtoFieldMaps_FieldId",
                table: "DtoFieldMaps",
                column: "FieldId");
        }
    }
}

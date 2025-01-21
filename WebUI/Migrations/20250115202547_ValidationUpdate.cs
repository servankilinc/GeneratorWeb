using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUI.Migrations
{
    /// <inheritdoc />
    public partial class ValidationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValidationParam_Validations_ValidationId",
                table: "ValidationParam");

            migrationBuilder.DropForeignKey(
                name: "FK_ValidationParam_ValidatorTypeParams_ValidatorTypeParamId",
                table: "ValidationParam");

            migrationBuilder.DropIndex(
                name: "IX_Validations_DtoFieldId",
                table: "Validations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValidationParam",
                table: "ValidationParam");

            migrationBuilder.RenameTable(
                name: "ValidationParam",
                newName: "ValidationParams");

            migrationBuilder.RenameIndex(
                name: "IX_ValidationParam_ValidatorTypeParamId",
                table: "ValidationParams",
                newName: "IX_ValidationParams_ValidatorTypeParamId");

            migrationBuilder.AddColumn<int>(
                name: "ValidationId",
                table: "DtoFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValidationParams",
                table: "ValidationParams",
                columns: new[] { "ValidationId", "ValidatorTypeParamId" });

            migrationBuilder.CreateIndex(
                name: "IX_Validations_DtoFieldId",
                table: "Validations",
                column: "DtoFieldId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ValidationParams_Validations_ValidationId",
                table: "ValidationParams",
                column: "ValidationId",
                principalTable: "Validations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ValidationParams_ValidatorTypeParams_ValidatorTypeParamId",
                table: "ValidationParams",
                column: "ValidatorTypeParamId",
                principalTable: "ValidatorTypeParams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValidationParams_Validations_ValidationId",
                table: "ValidationParams");

            migrationBuilder.DropForeignKey(
                name: "FK_ValidationParams_ValidatorTypeParams_ValidatorTypeParamId",
                table: "ValidationParams");

            migrationBuilder.DropIndex(
                name: "IX_Validations_DtoFieldId",
                table: "Validations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValidationParams",
                table: "ValidationParams");

            migrationBuilder.DropColumn(
                name: "ValidationId",
                table: "DtoFields");

            migrationBuilder.RenameTable(
                name: "ValidationParams",
                newName: "ValidationParam");

            migrationBuilder.RenameIndex(
                name: "IX_ValidationParams_ValidatorTypeParamId",
                table: "ValidationParam",
                newName: "IX_ValidationParam_ValidatorTypeParamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValidationParam",
                table: "ValidationParam",
                columns: new[] { "ValidationId", "ValidatorTypeParamId" });

            migrationBuilder.CreateIndex(
                name: "IX_Validations_DtoFieldId",
                table: "Validations",
                column: "DtoFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ValidationParam_Validations_ValidationId",
                table: "ValidationParam",
                column: "ValidationId",
                principalTable: "Validations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ValidationParam_ValidatorTypeParams_ValidatorTypeParamId",
                table: "ValidationParam",
                column: "ValidatorTypeParamId",
                principalTable: "ValidatorTypeParams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebUI.Migrations
{
    /// <inheritdoc />
    public partial class Setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldTypeSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTypeSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceLayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLayers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValidatorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidatorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatedEntityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dtos_Entities_RelatedEntityId",
                        column: x => x.RelatedEntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldTypes_FieldTypeSources_SourceTypeId",
                        column: x => x.SourceTypeId,
                        principalTable: "FieldTypeSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceLayerId = table.Column<int>(type: "int", nullable: false),
                    RelatedEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Entities_ServiceLayerId",
                        column: x => x.ServiceLayerId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_ServiceLayers_ServiceLayerId",
                        column: x => x.ServiceLayerId,
                        principalTable: "ServiceLayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValidatorTypeParams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidatorTypeId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidatorTypeParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidatorTypeParams_ValidatorTypes_ValidatorTypeId",
                        column: x => x.ValidatorTypeId,
                        principalTable: "ValidatorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    FieldTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUnique = table.Column<bool>(type: "bit", nullable: false),
                    IsList = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fields_FieldTypes_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Methods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ReturnMethodFieldId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAsync = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Methods_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DtoFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtoId = table.Column<int>(type: "int", nullable: false),
                    SourceFieldId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoFields", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryFieldId = table.Column<int>(type: "int", nullable: false),
                    ForeignFieldId = table.Column<int>(type: "int", nullable: false),
                    RelationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relations_Fields_ForeignFieldId",
                        column: x => x.ForeignFieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_Fields_PrimaryFieldId",
                        column: x => x.PrimaryFieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_RelationTypes_RelationTypeId",
                        column: x => x.RelationTypeId,
                        principalTable: "RelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MethodArgumentFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodId = table.Column<int>(type: "int", nullable: false),
                    FieldTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsList = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodArgumentFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MethodArgumentFields_FieldTypes_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MethodArgumentFields_Methods_MethodId",
                        column: x => x.MethodId,
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MethodReturnFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodId = table.Column<int>(type: "int", nullable: false),
                    FieldTypeId = table.Column<int>(type: "int", nullable: false),
                    IsList = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodReturnFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MethodReturnFields_FieldTypes_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MethodReturnFields_Methods_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Validations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtoFieldId = table.Column<int>(type: "int", nullable: false),
                    ValidatorTypeId = table.Column<int>(type: "int", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Validations_DtoFields_DtoFieldId",
                        column: x => x.DtoFieldId,
                        principalTable: "DtoFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Validations_ValidatorTypes_ValidatorTypeId",
                        column: x => x.ValidatorTypeId,
                        principalTable: "ValidatorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValidationParam",
                columns: table => new
                {
                    ValidationId = table.Column<int>(type: "int", nullable: false),
                    ValidatorTypeParamId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationParam", x => new { x.ValidationId, x.ValidatorTypeParamId });
                    table.ForeignKey(
                        name: "FK_ValidationParam_Validations_ValidationId",
                        column: x => x.ValidationId,
                        principalTable: "Validations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValidationParam_ValidatorTypeParams_ValidatorTypeParamId",
                        column: x => x.ValidatorTypeParamId,
                        principalTable: "ValidatorTypeParams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FieldTypeSources",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Base" },
                    { 2, "Entity" },
                    { 3, "Dto" }
                });

            migrationBuilder.InsertData(
                table: "RelationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "OnoToOne" },
                    { 2, "OnoToMany" }
                });

            migrationBuilder.InsertData(
                table: "ServiceLayers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Core" },
                    { 2, "Model" },
                    { 3, "DataAccess" },
                    { 4, "Business" },
                    { 5, "Presentation" }
                });

            migrationBuilder.InsertData(
                table: "ValidatorTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Field cannot be empty", "NotEmpty" },
                    { 2, "Field cannot be null", "NotNull" },
                    { 3, "Field cannot exceed maximum length", "MaxLength" },
                    { 4, "Value must be within a specific range", "Range" },
                    { 5, "Field must have a minimum number of characters", "MinLength" },
                    { 6, "Field must match a regular expression", "Regex" },
                    { 7, "Value must be greater than a specific number", "GreaterThan" },
                    { 8, "Value must be less than a specific number", "LessThan" },
                    { 9, "Field must be a valid email address", "EmailAddress" },
                    { 10, "Field must be a valid credit card number", "CreditCard" },
                    { 11, "Field must be a valid phone number", "Phone" },
                    { 12, "Field must be a valid URL", "Url" },
                    { 13, "Field must be a valid date", "Date" },
                    { 14, "Field must be a valid number", "Number" },
                    { 15, "Field mus be a valid guid value", "GuidNotEmpty" }
                });

            migrationBuilder.InsertData(
                table: "FieldTypes",
                columns: new[] { "Id", "Name", "SourceTypeId" },
                values: new object[,]
                {
                    { 1, "Int", 1 },
                    { 2, "String", 1 },
                    { 3, "Long", 1 },
                    { 4, "Float", 1 },
                    { 5, "Double", 1 },
                    { 6, "Bool", 1 },
                    { 7, "Char", 1 },
                    { 8, "Byte", 1 },
                    { 9, "DateTime", 1 },
                    { 10, "DateOnly", 1 },
                    { 11, "Guid", 1 }
                });

            migrationBuilder.InsertData(
                table: "ValidatorTypeParams",
                columns: new[] { "Id", "Key", "ValidatorTypeId" },
                values: new object[,]
                {
                    { 1, "Max", 3 },
                    { 2, "Min", 4 },
                    { 3, "Max", 4 },
                    { 4, "Min", 5 },
                    { 5, "Pattern", 6 },
                    { 6, "Value", 7 },
                    { 7, "Value", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DtoFields_DtoId",
                table: "DtoFields",
                column: "DtoId");

            migrationBuilder.CreateIndex(
                name: "IX_DtoFields_SourceFieldId",
                table: "DtoFields",
                column: "SourceFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Dtos_RelatedEntityId",
                table: "Dtos",
                column: "RelatedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_EntityId",
                table: "Fields",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FieldTypeId",
                table: "Fields",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldTypes_SourceTypeId",
                table: "FieldTypes",
                column: "SourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MethodArgumentFields_FieldTypeId",
                table: "MethodArgumentFields",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MethodArgumentFields_MethodId",
                table: "MethodArgumentFields",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_MethodReturnFields_FieldTypeId",
                table: "MethodReturnFields",
                column: "FieldTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MethodReturnFields_MethodId",
                table: "MethodReturnFields",
                column: "MethodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Methods_ServiceId",
                table: "Methods",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_ForeignFieldId",
                table: "Relations",
                column: "ForeignFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_PrimaryFieldId_ForeignFieldId",
                table: "Relations",
                columns: new[] { "PrimaryFieldId", "ForeignFieldId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Relations_RelationTypeId",
                table: "Relations",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceLayerId_RelatedEntityId",
                table: "Services",
                columns: new[] { "ServiceLayerId", "RelatedEntityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValidationParam_ValidatorTypeParamId",
                table: "ValidationParam",
                column: "ValidatorTypeParamId");

            migrationBuilder.CreateIndex(
                name: "IX_Validations_DtoFieldId",
                table: "Validations",
                column: "DtoFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Validations_ValidatorTypeId",
                table: "Validations",
                column: "ValidatorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidatorTypeParams_ValidatorTypeId",
                table: "ValidatorTypeParams",
                column: "ValidatorTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MethodArgumentFields");

            migrationBuilder.DropTable(
                name: "MethodReturnFields");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "ValidationParam");

            migrationBuilder.DropTable(
                name: "Methods");

            migrationBuilder.DropTable(
                name: "RelationTypes");

            migrationBuilder.DropTable(
                name: "Validations");

            migrationBuilder.DropTable(
                name: "ValidatorTypeParams");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "DtoFields");

            migrationBuilder.DropTable(
                name: "ValidatorTypes");

            migrationBuilder.DropTable(
                name: "ServiceLayers");

            migrationBuilder.DropTable(
                name: "Dtos");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "FieldTypes");

            migrationBuilder.DropTable(
                name: "FieldTypeSources");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kernel.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Query = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessType = table.Column<int>(type: "int", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessSteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeildType = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsDuplicate = table.Column<bool>(type: "bit", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFields_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LangMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LangMessages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LangMessages_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestPatterns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkFlowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPatterns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestPatterns_WorkFlows_WorkFlowId",
                        column: x => x.WorkFlowId,
                        principalTable: "WorkFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlowInput",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BodyJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkFlowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowInput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkFlowInput_WorkFlows_WorkFlowId",
                        column: x => x.WorkFlowId,
                        principalTable: "WorkFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlowResponse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponseJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkFlowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkFlowResponse_WorkFlows_WorkFlowId",
                        column: x => x.WorkFlowId,
                        principalTable: "WorkFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlowSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsFirst = table.Column<bool>(type: "bit", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordType = table.Column<int>(type: "int", nullable: false),
                    WorkFlowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkFlowSteps_WorkFlows_WorkFlowId",
                        column: x => x.WorkFlowId,
                        principalTable: "WorkFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldRelations_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityFieldRelations_EntityFields_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalTable: "EntityFields",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldValidations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Regex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldValidations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldValidations_EntityFields_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalTable: "EntityFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityFieldValidations_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlowStepMovmentValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValueStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowStepMovmentValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkFlowStepMovmentValues_WorkFlowSteps_ValueStepId",
                        column: x => x.ValueStepId,
                        principalTable: "WorkFlowSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlowStepMovments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowNextStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowStepMovmentValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlowStepMovments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkFlowStepMovments_WorkFlowStepMovmentValues_WorkFlowStepMovmentValueId",
                        column: x => x.WorkFlowStepMovmentValueId,
                        principalTable: "WorkFlowStepMovmentValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkFlowStepMovments_WorkFlowSteps_WorkFlowNextStepId",
                        column: x => x.WorkFlowNextStepId,
                        principalTable: "WorkFlowSteps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkFlowStepMovments_WorkFlowSteps_WorkFlowStepId",
                        column: x => x.WorkFlowStepId,
                        principalTable: "WorkFlowSteps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldRelations_EntityFieldId",
                table: "EntityFieldRelations",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldRelations_EntityId",
                table: "EntityFieldRelations",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFields_EntityId",
                table: "EntityFields",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldValidations_EntityFieldId",
                table: "EntityFieldValidations",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldValidations_MessageId",
                table: "EntityFieldValidations",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_LangMessages_LanguageId",
                table: "LangMessages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LangMessages_MessageId",
                table: "LangMessages",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestPatterns_WorkFlowId",
                table: "RequestPatterns",
                column: "WorkFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowInput_WorkFlowId",
                table: "WorkFlowInput",
                column: "WorkFlowId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowResponse_WorkFlowId",
                table: "WorkFlowResponse",
                column: "WorkFlowId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowStepMovments_WorkFlowNextStepId",
                table: "WorkFlowStepMovments",
                column: "WorkFlowNextStepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowStepMovments_WorkFlowStepId",
                table: "WorkFlowStepMovments",
                column: "WorkFlowStepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowStepMovments_WorkFlowStepMovmentValueId",
                table: "WorkFlowStepMovments",
                column: "WorkFlowStepMovmentValueId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowStepMovmentValues_ValueStepId",
                table: "WorkFlowStepMovmentValues",
                column: "ValueStepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowSteps_WorkFlowId",
                table: "WorkFlowSteps",
                column: "WorkFlowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityFieldRelations");

            migrationBuilder.DropTable(
                name: "EntityFieldValidations");

            migrationBuilder.DropTable(
                name: "LangMessages");

            migrationBuilder.DropTable(
                name: "ProcessSteps");

            migrationBuilder.DropTable(
                name: "RequestPatterns");

            migrationBuilder.DropTable(
                name: "WorkFlowInput");

            migrationBuilder.DropTable(
                name: "WorkFlowResponse");

            migrationBuilder.DropTable(
                name: "WorkFlowStepMovments");

            migrationBuilder.DropTable(
                name: "EntityFields");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "WorkFlowStepMovmentValues");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "WorkFlowSteps");

            migrationBuilder.DropTable(
                name: "WorkFlows");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kernel.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addvalidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkFlowStepMovments_WorkFlowStepMovmentValues_WorkFlowStepMovmentValueId",
                table: "WorkFlowStepMovments");

            migrationBuilder.DropTable(
                name: "WorkFlowStepMovmentValues");

            migrationBuilder.DropIndex(
                name: "IX_WorkFlowStepMovments_WorkFlowStepMovmentValueId",
                table: "WorkFlowStepMovments");

            migrationBuilder.DropColumn(
                name: "WorkFlowStepMovmentValueId",
                table: "WorkFlowStepMovments");

            migrationBuilder.CreateTable(
                name: "ValidationStepFalses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationStepFalses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidationStepFalses_WorkFlowSteps_WorkFlowStepId",
                        column: x => x.WorkFlowStepId,
                        principalTable: "WorkFlowSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValidationSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Query = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationSteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValidationStepTrues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowStepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationStepTrues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidationStepTrues_WorkFlowSteps_WorkFlowStepId",
                        column: x => x.WorkFlowStepId,
                        principalTable: "WorkFlowSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValidationStepFalses_WorkFlowStepId",
                table: "ValidationStepFalses",
                column: "WorkFlowStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationStepTrues_WorkFlowStepId",
                table: "ValidationStepTrues",
                column: "WorkFlowStepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValidationStepFalses");

            migrationBuilder.DropTable(
                name: "ValidationSteps");

            migrationBuilder.DropTable(
                name: "ValidationStepTrues");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkFlowStepMovmentValueId",
                table: "WorkFlowStepMovments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowStepMovments_WorkFlowStepMovmentValueId",
                table: "WorkFlowStepMovments",
                column: "WorkFlowStepMovmentValueId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkFlowStepMovmentValues_ValueStepId",
                table: "WorkFlowStepMovmentValues",
                column: "ValueStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkFlowStepMovments_WorkFlowStepMovmentValues_WorkFlowStepMovmentValueId",
                table: "WorkFlowStepMovments",
                column: "WorkFlowStepMovmentValueId",
                principalTable: "WorkFlowStepMovmentValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

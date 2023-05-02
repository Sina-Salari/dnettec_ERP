using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kernel.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addValidationStepIdtoValidationStepTrueFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ValidationStepId",
                table: "ValidationStepTrues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ValidationStepId",
                table: "ValidationStepFalses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ValidationStepTrues_ValidationStepId",
                table: "ValidationStepTrues",
                column: "ValidationStepId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValidationStepFalses_ValidationStepId",
                table: "ValidationStepFalses",
                column: "ValidationStepId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ValidationStepFalses_ValidationSteps_ValidationStepId",
                table: "ValidationStepFalses",
                column: "ValidationStepId",
                principalTable: "ValidationSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ValidationStepTrues_ValidationSteps_ValidationStepId",
                table: "ValidationStepTrues",
                column: "ValidationStepId",
                principalTable: "ValidationSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValidationStepFalses_ValidationSteps_ValidationStepId",
                table: "ValidationStepFalses");

            migrationBuilder.DropForeignKey(
                name: "FK_ValidationStepTrues_ValidationSteps_ValidationStepId",
                table: "ValidationStepTrues");

            migrationBuilder.DropIndex(
                name: "IX_ValidationStepTrues_ValidationStepId",
                table: "ValidationStepTrues");

            migrationBuilder.DropIndex(
                name: "IX_ValidationStepFalses_ValidationStepId",
                table: "ValidationStepFalses");

            migrationBuilder.DropColumn(
                name: "ValidationStepId",
                table: "ValidationStepTrues");

            migrationBuilder.DropColumn(
                name: "ValidationStepId",
                table: "ValidationStepFalses");
        }
    }
}

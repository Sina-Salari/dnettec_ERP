using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kernel.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addWorkFlowInputAndResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkFlowInput_WorkFlows_WorkFlowId",
                table: "WorkFlowInput");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkFlowResponse_WorkFlows_WorkFlowId",
                table: "WorkFlowResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkFlowResponse",
                table: "WorkFlowResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkFlowInput",
                table: "WorkFlowInput");

            migrationBuilder.RenameTable(
                name: "WorkFlowResponse",
                newName: "WorkFlowResponses");

            migrationBuilder.RenameTable(
                name: "WorkFlowInput",
                newName: "WorkFlowInputs");

            migrationBuilder.RenameIndex(
                name: "IX_WorkFlowResponse_WorkFlowId",
                table: "WorkFlowResponses",
                newName: "IX_WorkFlowResponses_WorkFlowId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkFlowInput_WorkFlowId",
                table: "WorkFlowInputs",
                newName: "IX_WorkFlowInputs_WorkFlowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkFlowResponses",
                table: "WorkFlowResponses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkFlowInputs",
                table: "WorkFlowInputs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkFlowInputs_WorkFlows_WorkFlowId",
                table: "WorkFlowInputs",
                column: "WorkFlowId",
                principalTable: "WorkFlows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkFlowResponses_WorkFlows_WorkFlowId",
                table: "WorkFlowResponses",
                column: "WorkFlowId",
                principalTable: "WorkFlows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkFlowInputs_WorkFlows_WorkFlowId",
                table: "WorkFlowInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkFlowResponses_WorkFlows_WorkFlowId",
                table: "WorkFlowResponses");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkFlowResponses",
                table: "WorkFlowResponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkFlowInputs",
                table: "WorkFlowInputs");

            migrationBuilder.RenameTable(
                name: "WorkFlowResponses",
                newName: "WorkFlowResponse");

            migrationBuilder.RenameTable(
                name: "WorkFlowInputs",
                newName: "WorkFlowInput");

            migrationBuilder.RenameIndex(
                name: "IX_WorkFlowResponses_WorkFlowId",
                table: "WorkFlowResponse",
                newName: "IX_WorkFlowResponse_WorkFlowId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkFlowInputs_WorkFlowId",
                table: "WorkFlowInput",
                newName: "IX_WorkFlowInput_WorkFlowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkFlowResponse",
                table: "WorkFlowResponse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkFlowInput",
                table: "WorkFlowInput",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkFlowInput_WorkFlows_WorkFlowId",
                table: "WorkFlowInput",
                column: "WorkFlowId",
                principalTable: "WorkFlows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkFlowResponse_WorkFlows_WorkFlowId",
                table: "WorkFlowResponse",
                column: "WorkFlowId",
                principalTable: "WorkFlows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

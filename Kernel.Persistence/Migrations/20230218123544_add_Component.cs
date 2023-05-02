using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kernel.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Pages",
                newName: "URL");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pages",
                newName: "Classes");

            migrationBuilder.AddColumn<Guid>(
                name: "PageTitleId",
                table: "Pages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentDirectionType = table.Column<int>(type: "int", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentItemType = table.Column<int>(type: "int", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentItems_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponetChildren",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChildComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponetChildren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponetChildren_Components_ChildComponentId",
                        column: x => x.ChildComponentId,
                        principalTable: "Components",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComponetChildren_Components_ParentComponentId",
                        column: x => x.ParentComponentId,
                        principalTable: "Components",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PageComponents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageComponents_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageComponents_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentItemOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Classes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceholderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentItemOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentItemOptions_ComponentItems_ComponentItemId",
                        column: x => x.ComponentItemId,
                        principalTable: "ComponentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentItemOptions_Messages_PlaceholderId",
                        column: x => x.PlaceholderId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_PageTitleId",
                table: "Pages",
                column: "PageTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentItemOptions_ComponentItemId",
                table: "ComponentItemOptions",
                column: "ComponentItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentItemOptions_PlaceholderId",
                table: "ComponentItemOptions",
                column: "PlaceholderId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentItems_ComponentId",
                table: "ComponentItems",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponetChildren_ChildComponentId",
                table: "ComponetChildren",
                column: "ChildComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponetChildren_ParentComponentId",
                table: "ComponetChildren",
                column: "ParentComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_ComponentId",
                table: "PageComponents",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_PageId",
                table: "PageComponents",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Messages_PageTitleId",
                table: "Pages",
                column: "PageTitleId",
                principalTable: "Messages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Messages_PageTitleId",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "ComponentItemOptions");

            migrationBuilder.DropTable(
                name: "ComponetChildren");

            migrationBuilder.DropTable(
                name: "PageComponents");

            migrationBuilder.DropTable(
                name: "ComponentItems");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropIndex(
                name: "IX_Pages_PageTitleId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PageTitleId",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Pages",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "Classes",
                table: "Pages",
                newName: "Name");
        }
    }
}

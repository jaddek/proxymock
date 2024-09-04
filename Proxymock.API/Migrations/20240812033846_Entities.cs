using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proxymock.API.Migrations
{
    /// <inheritdoc />
    public partial class Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projects_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "endpoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    SchemeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_endpoints_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_endpoints_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scheme",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    EndpointId = table.Column<Guid>(type: "uuid", nullable: false),
                    JsonData = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scheme_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scheme_endpoints_EndpointId",
                        column: x => x.EndpointId,
                        principalTable: "endpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_endpoints_ProjectId",
                table: "endpoints",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_endpoints_SchemeId",
                table: "endpoints",
                column: "SchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Scheme_EndpointId",
                table: "Scheme",
                column: "EndpointId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_endpoints_Scheme_SchemeId",
                table: "endpoints",
                column: "SchemeId",
                principalTable: "Scheme",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_endpoints_BaseEntity_Id",
                table: "endpoints");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_BaseEntity_Id",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Scheme_BaseEntity_Id",
                table: "Scheme");

            migrationBuilder.DropForeignKey(
                name: "FK_endpoints_Scheme_SchemeId",
                table: "endpoints");

            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.DropTable(
                name: "Scheme");

            migrationBuilder.DropTable(
                name: "endpoints");

            migrationBuilder.DropTable(
                name: "projects");
        }
    }
}

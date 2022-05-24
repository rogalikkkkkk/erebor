using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Erebor.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Lectors_LectorId",
                table: "Lectures");

            migrationBuilder.RenameColumn(
                name: "LectorId",
                table: "Lectures",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Lectures_LectorId",
                table: "Lectures",
                newName: "IX_Lectures_CourseId");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    LectorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cources_Lectors_LectorId",
                        column: x => x.LectorId,
                        principalTable: "Lectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cources_LectorId",
                table: "Cources",
                column: "LectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Cources_CourseId",
                table: "Lectures",
                column: "CourseId",
                principalTable: "Cources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Cources_CourseId",
                table: "Lectures");

            migrationBuilder.DropTable(
                name: "Cources");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Lectures",
                newName: "LectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures",
                newName: "IX_Lectures_LectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Lectors_LectorId",
                table: "Lectures",
                column: "LectorId",
                principalTable: "Lectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

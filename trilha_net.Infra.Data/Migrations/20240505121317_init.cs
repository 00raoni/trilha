using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trilha_net.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Login = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    CPF = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CreatedAtUtc",
                schema: "dbo",
                table: "Usuario",
                column: "CreatedAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UpdatedAtUtc",
                schema: "dbo",
                table: "Usuario",
                column: "UpdatedAtUtc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "dbo");
        }
    }
}

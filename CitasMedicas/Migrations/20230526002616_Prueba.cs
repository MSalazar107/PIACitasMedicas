using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    public partial class Prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PacienteCitas_PacienteId",
                table: "PacienteCitas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacienteCitas",
                table: "PacienteCitas",
                columns: new[] { "PacienteId", "CitaId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PacienteCitas",
                table: "PacienteCitas");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteCitas_PacienteId",
                table: "PacienteCitas",
                column: "PacienteId");
        }
    }
}

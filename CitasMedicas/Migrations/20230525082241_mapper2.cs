using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    public partial class mapper2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Paciente_PacienteId",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_PacienteId",
                table: "Cita");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cita_PacienteId",
                table: "Cita",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Paciente_PacienteId",
                table: "Cita",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    public partial class mapper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitaPaciente");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Paciente_PacienteId",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_PacienteId",
                table: "Cita");

            migrationBuilder.CreateTable(
                name: "CitaPaciente",
                columns: table => new
                {
                    CitasPId = table.Column<int>(type: "int", nullable: false),
                    pacientesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaPaciente", x => new { x.CitasPId, x.pacientesId });
                    table.ForeignKey(
                        name: "FK_CitaPaciente_Cita_CitasPId",
                        column: x => x.CitasPId,
                        principalTable: "Cita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitaPaciente_Paciente_pacientesId",
                        column: x => x.pacientesId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitaPaciente_pacientesId",
                table: "CitaPaciente",
                column: "pacientesId");
        }
    }
}

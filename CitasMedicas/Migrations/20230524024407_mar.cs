using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    public partial class mar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Paciente_pacientesId",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_pacientesId",
                table: "Cita");

            migrationBuilder.DropColumn(
                name: "pacientesId",
                table: "Cita");

            migrationBuilder.AddColumn<int>(
                name: "edad",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropColumn(
                name: "edad",
                table: "Paciente");

            migrationBuilder.AddColumn<int>(
                name: "pacientesId",
                table: "Cita",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cita_pacientesId",
                table: "Cita",
                column: "pacientesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Paciente_pacientesId",
                table: "Cita",
                column: "pacientesId",
                principalTable: "Paciente",
                principalColumn: "Id");
        }
    }
}

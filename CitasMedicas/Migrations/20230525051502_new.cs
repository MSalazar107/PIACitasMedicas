using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Doctor_DoctoresId",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Paciente_PacienteId",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_DoctoresId",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_PacienteId",
                table: "Cita");

            migrationBuilder.DropColumn(
                name: "DoctoresId",
                table: "Cita");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Paciente",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Paciente",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "direccion",
                table: "Paciente",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Doctor",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "especialidad",
                table: "Doctor",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "consultorio",
                table: "Doctor",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CitaId",
                table: "Doctor",
                type: "int",
                nullable: true);

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
                name: "IX_Doctor_CitaId",
                table: "Doctor",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaPaciente_pacientesId",
                table: "CitaPaciente",
                column: "pacientesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Cita_CitaId",
                table: "Doctor",
                column: "CitaId",
                principalTable: "Cita",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Cita_CitaId",
                table: "Doctor");

            migrationBuilder.DropTable(
                name: "CitaPaciente");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_CitaId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "CitaId",
                table: "Doctor");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "direccion",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "especialidad",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "consultorio",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "DoctoresId",
                table: "Cita",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cita_DoctoresId",
                table: "Cita",
                column: "DoctoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_PacienteId",
                table: "Cita",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Doctor_DoctoresId",
                table: "Cita",
                column: "DoctoresId",
                principalTable: "Doctor",
                principalColumn: "Id");

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

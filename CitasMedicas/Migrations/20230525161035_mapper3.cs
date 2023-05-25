using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicas.Migrations
{
    public partial class mapper3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "altura",
                table: "Paciente",
                type: "real",
                maxLength: 5,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "hisorialEnfermedades",
                table: "Paciente",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "peso",
                table: "Paciente",
                type: "real",
                maxLength: 3,
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "altura",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "hisorialEnfermedades",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "peso",
                table: "Paciente");
        }
    }
}

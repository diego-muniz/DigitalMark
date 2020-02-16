using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMark.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(256)", maxLength: 120, nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false),
                    Cep = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    Complemento = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    Localidade = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    UF = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfermeiro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    Coren = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfermeiro_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfermeiro_HospitalId",
                table: "Enfermeiro",
                column: "HospitalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enfermeiro");

            migrationBuilder.DropTable(
                name: "Hospital");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universidad.API.Migrations
{
    /// <inheritdoc />
    public partial class Oracle1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefono = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Correo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ponente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    añoDenacimiento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Fecha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Lugar = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evento_Participante_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participante",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FechaInscripcion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdEvento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdParticipante = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PartisipanteId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Participante_PartisipanteId",
                        column: x => x.PartisipanteId,
                        principalTable: "Participante",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sesion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Horario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sala = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdEvento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sesion_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Certificado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FechaEmision = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdInscripcion = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    InscripcionId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificado_Inscripcion_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripcion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    InscripcionId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Monto = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    FechaPago = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MetodoPago = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdInscripcion = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pago_Inscripcion_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripcion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_InscripcionId",
                table: "Certificado",
                column: "InscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_ParticipanteId",
                table: "Evento",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_EventoId",
                table: "Inscripcion",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_PartisipanteId",
                table: "Inscripcion",
                column: "PartisipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_InscripcionId",
                table: "Pago",
                column: "InscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesion_EventoId",
                table: "Sesion",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificado");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Ponente");

            migrationBuilder.DropTable(
                name: "Sesion");

            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Participante");
        }
    }
}

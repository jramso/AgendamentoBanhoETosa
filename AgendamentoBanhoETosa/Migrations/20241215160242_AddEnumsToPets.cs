using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendamentoBanhoETosa.Migrations
{
    /// <inheritdoc />
    public partial class AddEnumsToPets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Clientes_ClienteId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Pets_PetId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Clientes_ClienteId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ClienteId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ClienteId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_PetId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ServicoId",
                table: "Agendamentos");

            migrationBuilder.Sql("ALTER TABLE \"Pets\" ALTER COLUMN \"Tipo\" TYPE integer USING \"Tipo\"::integer;");


            migrationBuilder.AddColumn<int>(
                name: "RacaCachorro",
                table: "Pets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RacaGato",
                table: "Pets",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RacaCachorro",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "RacaGato",
                table: "Pets");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Pets",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ClienteId",
                table: "Pets",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ClienteId",
                table: "Agendamentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_PetId",
                table: "Agendamentos",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Clientes_ClienteId",
                table: "Agendamentos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Pets_PetId",
                table: "Agendamentos",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Clientes_ClienteId",
                table: "Pets",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

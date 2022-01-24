using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.DAL.Migrations
{
    public partial class TOKEN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "6c8998fd-cd99-4513-aa24-7452ef4ba11a");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "a5f48dc3-395a-49ee-8df0-e227fa5028b2");

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "4d36fa55-6db7-416a-b488-b9c2940d4a3c", "85f392e8-1a89-43e7-8cc3-329d38a2f845", "Usuario do sistema", "Usuario", "USUARIO" });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "69885de9-8343-48cf-98b9-b12e8cba563f", "94fd98e6-7253-4887-a8ad-ff1ea0cd09de", "Admintrador do sistema", "Administrador", "ADMINISTRADOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "4d36fa55-6db7-416a-b488-b9c2940d4a3c");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "69885de9-8343-48cf-98b9-b12e8cba563f");

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "6c8998fd-cd99-4513-aa24-7452ef4ba11a", "c4b3e3dc-66f7-4f08-8c68-8774236319b4", "Usuario do sistema", "Usuario", "USUARIO" });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "a5f48dc3-395a-49ee-8df0-e227fa5028b2", "1a986414-7c13-4266-a20f-b6d5b9754694", "Admintrador do sistema", "Administrador", "ADMINISTRADOR" });
        }
    }
}

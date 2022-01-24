using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.DAL.Migrations
{
    public partial class ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "373b1b63-2eee-4e65-8b98-9dbdfc8cfc14", "1c68b9bf-768b-4138-bb46-04ed1be68ac9", "Usuario do sistema", "Usuario", "USUARIO" });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "c62a7efc-4d49-46bf-b04f-b4f3e123e3fe", "b7cfc326-3b17-4192-9c7f-0f749640b199", "Admintrador do sistema", "Administrador", "ADMINISTRADOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "373b1b63-2eee-4e65-8b98-9dbdfc8cfc14");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "c62a7efc-4d49-46bf-b04f-b4f3e123e3fe");

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "4d36fa55-6db7-416a-b488-b9c2940d4a3c", "85f392e8-1a89-43e7-8cc3-329d38a2f845", "Usuario do sistema", "Usuario", "USUARIO" });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "69885de9-8343-48cf-98b9-b12e8cba563f", "94fd98e6-7253-4887-a8ad-ff1ea0cd09de", "Admintrador do sistema", "Administrador", "ADMINISTRADOR" });
        }
    }
}

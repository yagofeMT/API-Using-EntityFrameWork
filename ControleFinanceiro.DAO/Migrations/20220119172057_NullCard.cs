using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.DAL.Migrations
{
    public partial class NullCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "1e115a2c-746d-425d-a517-f7fe31f35210");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "e8ba1413-7a09-4f6a-90cd-7a3471e03ccb");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "6c8998fd-cd99-4513-aa24-7452ef4ba11a", "c4b3e3dc-66f7-4f08-8c68-8774236319b4", "Usuario do sistema", "Usuario", "USUARIO" });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "a5f48dc3-395a-49ee-8df0-e227fa5028b2", "1a986414-7c13-4266-a20f-b6d5b9754694", "Admintrador do sistema", "Administrador", "ADMINISTRADOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "6c8998fd-cd99-4513-aa24-7452ef4ba11a");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "a5f48dc3-395a-49ee-8df0-e227fa5028b2");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "1e115a2c-746d-425d-a517-f7fe31f35210", "14fc5096-733b-4056-8d43-a11765f98a16", "Usuario do sistema", "Usuario", "USUARIO" });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "e8ba1413-7a09-4f6a-90cd-7a3471e03ccb", "ce353eb1-1798-4f7b-a3c0-b771b77ff329", "Admintrador do sistema", "Administrador", "ADMINISTRADOR" });
        }
    }
}

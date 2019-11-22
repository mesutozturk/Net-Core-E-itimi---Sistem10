using Microsoft.EntityFrameworkCore.Migrations;

namespace Web1.Migrations
{
    public partial class FailBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "Kategoriler");

            migrationBuilder.DropColumn(
                name: "UrunAdi",
                table: "Kategoriler");

            migrationBuilder.AlterColumn<string>(
                name: "Renk",
                table: "Kategoriler",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KategoriAdi",
                table: "Kategoriler",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KategoriAdi",
                table: "Kategoriler");

            migrationBuilder.AlterColumn<string>(
                name: "Renk",
                table: "Kategoriler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Fiyat",
                table: "Kategoriler",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UrunAdi",
                table: "Kategoriler",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

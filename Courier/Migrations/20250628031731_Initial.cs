using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courier.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ordering");

            migrationBuilder.CreateTable(
                name: "Parcels",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SenderStreet = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SenderCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SenderState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SenderCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SenderZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RecipientStreet = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RecipientCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RecipientState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RecipientCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RecipientZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_TrackingNumber",
                schema: "ordering",
                table: "Parcels",
                column: "TrackingNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcels",
                schema: "ordering");
        }
    }
}

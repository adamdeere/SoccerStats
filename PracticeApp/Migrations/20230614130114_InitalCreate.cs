using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeApp.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationModel",
                columns: table => new
                {
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationModel", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel",
                columns: table => new
                {
                    SKUCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.SKUCode);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptModel",
                columns: table => new
                {
                    GRN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalWeight = table.Column<float>(type: "real", nullable: false),
                    TotalCube = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptModel", x => x.GRN);
                });

            migrationBuilder.CreateTable(
                name: "ItemModel",
                columns: table => new
                {
                    ItemNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRN = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    SKUCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModel", x => x.ItemNo);
                    table.ForeignKey(
                        name: "FK_ItemModel_ProductModel_SKUCode",
                        column: x => x.SKUCode,
                        principalTable: "ProductModel",
                        principalColumn: "SKUCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemModel_ReceiptModel_GRN",
                        column: x => x.GRN,
                        principalTable: "ReceiptModel",
                        principalColumn: "GRN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemLocationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GRN = table.Column<int>(type: "int", nullable: false),
                    ItemNo = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLocationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemLocationModel_ItemModel_ItemNo",
                        column: x => x.ItemNo,
                        principalTable: "ItemModel",
                        principalColumn: "ItemNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemLocationModel_LocationModel_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationModel",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemLocationModel_ReceiptModel_GRN",
                        column: x => x.GRN,
                        principalTable: "ReceiptModel",
                        principalColumn: "GRN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocationModel_GRN",
                table: "ItemLocationModel",
                column: "GRN");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocationModel_ItemNo",
                table: "ItemLocationModel",
                column: "ItemNo");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLocationModel_LocationId",
                table: "ItemLocationModel",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModel_GRN",
                table: "ItemModel",
                column: "GRN");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModel_SKUCode",
                table: "ItemModel",
                column: "SKUCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemLocationModel");

            migrationBuilder.DropTable(
                name: "ItemModel");

            migrationBuilder.DropTable(
                name: "LocationModel");

            migrationBuilder.DropTable(
                name: "ProductModel");

            migrationBuilder.DropTable(
                name: "ReceiptModel");
        }
    }
}
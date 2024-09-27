using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentsApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Variant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    MileageInKm = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doors = table.Column<int>(type: "int", nullable: false),
                    EngineCapacityInCc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransmissionDrive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    DealerLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TummCode = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealerContactInformation_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealerContactInformation_EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealerContactInformation_ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealerContactInformation_Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    DealerContactInformation_Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    DealerContactInformation_Address_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealerContactInformation_Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealerContactInformation_Address_Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealerContactInformation_Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealerContactInformation_Address_Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}

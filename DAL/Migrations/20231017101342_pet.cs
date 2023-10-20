using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class pet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d733d81-558e-4e1e-b4e3-8668dc85efea");

            migrationBuilder.AddColumn<bool>(
                name: "IsRated",
                table: "ReserveOffer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRated",
                table: "Reservation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "AverageRate",
                table: "MakeOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CountOfRating",
                table: "MakeOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SumOfRating",
                table: "MakeOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Rejected",
                table: "DoctorAttachment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "OfferRatings",
                columns: table => new
                {
                    ReserveOfferId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MakeOfferId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferRatings", x => x.ReserveOfferId);
                    table.ForeignKey(
                        name: "FK_OfferRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferRatings_MakeOffers_MakeOfferId",
                        column: x => x.MakeOfferId,
                        principalTable: "MakeOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferRatings_ReserveOffer_ReserveOfferId",
                        column: x => x.ReserveOfferId,
                        principalTable: "ReserveOffer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferRatings_MakeOfferId",
                table: "OfferRatings",
                column: "MakeOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferRatings_UserId",
                table: "OfferRatings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferRatings");

            migrationBuilder.DropColumn(
                name: "IsRated",
                table: "ReserveOffer");

            migrationBuilder.DropColumn(
                name: "IsRated",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "AverageRate",
                table: "MakeOffers");

            migrationBuilder.DropColumn(
                name: "CountOfRating",
                table: "MakeOffers");

            migrationBuilder.DropColumn(
                name: "SumOfRating",
                table: "MakeOffers");

            migrationBuilder.DropColumn(
                name: "Rejected",
                table: "DoctorAttachment");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsDoctor", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d733d81-558e-4e1e-b4e3-8668dc85efea", 0, "862ebaa0-b589-4a62-9332-dd314d726d09", "example.gmail.com", false, null, false, false, null, null, null, "123456", null, false, "c717599e-0ade-45a5-9cf5-f99069e93434", false, "admin" });
        }
    }
}

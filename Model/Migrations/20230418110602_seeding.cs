using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Landen",
                columns: new[] { "LandCode", "Naam" },
                values: new object[,]
                {
                    { "BEL", "België" },
                    { "DEU", "Duitsland" },
                    { "FRA", "Frankrijk" },
                    { "LUX", "Luxemburg" },
                    { "NLD", "Nederland" }
                });

            migrationBuilder.InsertData(
                table: "Talen",
                columns: new[] { "TaalCode", "Naam" },
                values: new object[,]
                {
                    { "de", "Duits" },
                    { "fr", "Frans" },
                    { "lb", "Luxemburgs" },
                    { "nl", "Nederlands" }
                });

            migrationBuilder.InsertData(
                table: "LandTaal",
                columns: new[] { "LandenLandCode", "TalenTaalCode" },
                values: new object[,]
                {
                    { "BEL", "de" },
                    { "BEL", "fr" },
                    { "BEL", "nl" },
                    { "DEU", "de" },
                    { "FRA", "fr" },
                    { "LUX", "de" },
                    { "LUX", "fr" },
                    { "LUX", "lb" },
                    { "NLD", "nl" }
                });

            migrationBuilder.InsertData(
                table: "Steden",
                columns: new[] { "StadNr", "LandCode", "Naam" },
                values: new object[,]
                {
                    { 1, "BEL", "Brussel" },
                    { 2, "BEL", "Antwerpen" },
                    { 3, "BEL", "Luik" },
                    { 4, "NLD", "Amsterdam" },
                    { 5, "NLD", "Den Haag" },
                    { 6, "NLD", "Rotterdam" },
                    { 7, "DEU", "Berlijn" },
                    { 8, "DEU", "Hamburg" },
                    { 9, "DEU", "München" },
                    { 10, "LUX", "Luxemburg" },
                    { 11, "FRA", "Parijs" },
                    { 12, "FRA", "Marseille" },
                    { 13, "FRA", "Lyon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LandTaal",
                keyColumns: new[] { "LandenLandCode", "TalenTaalCode" },
                keyValues: new object[] { "BEL", "de" });

            migrationBuilder.DeleteData(
                table: "LandTaal",
                keyColumns: new[] { "LandenLandCode", "TalenTaalCode" },
                keyValues: new object[] { "BEL", "fr" });

            migrationBuilder.DeleteData(
                table: "LandTaal",
                keyColumns: new[] { "LandenLandCode", "TalenTaalCode" },
                keyValues: new object[] { "BEL", "nl" });

            migrationBuilder.DeleteData(
                table: "LandTaal",
                keyColumns: new[] { "LandenLandCode", "TalenTaalCode" },
                keyValues: new object[] { "DEU", "de" });

            migrationBuilder.DeleteData(
                table: "LandTaal",
                keyColumns: new[] { "LandenLandCode", "TalenTaalCode" },
                keyValues: new object[] { "FRA", "fr" });

            migrationBuilder.DeleteData(
                table: "LandTaal",
                keyColumns: new[] { "LandenLandCode", "TalenTaalCode" },
                keyValues: new object[] { "LUX", "de" });

            migrationBuilder.DeleteData(
                table: "LandTaal",
                keyColumns: new[] { "LandenLandCode", "TalenTaalCode" },
                keyValues: new object[] { "LUX", "fr" });

            migrationBuilder.DeleteData(
                table: "LandTaal",
                keyColumns: new[] { "LandenLandCode", "TalenTaalCode" },
                keyValues: new object[] { "LUX", "lb" });

            migrationBuilder.DeleteData(
                table: "LandTaal",
                keyColumns: new[] { "LandenLandCode", "TalenTaalCode" },
                keyValues: new object[] { "NLD", "nl" });

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Steden",
                keyColumn: "StadNr",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "BEL");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "DEU");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "FRA");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "LUX");

            migrationBuilder.DeleteData(
                table: "Landen",
                keyColumn: "LandCode",
                keyValue: "NLD");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "TaalCode",
                keyValue: "de");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "TaalCode",
                keyValue: "fr");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "TaalCode",
                keyValue: "lb");

            migrationBuilder.DeleteData(
                table: "Talen",
                keyColumn: "TaalCode",
                keyValue: "nl");
        }
    }
}

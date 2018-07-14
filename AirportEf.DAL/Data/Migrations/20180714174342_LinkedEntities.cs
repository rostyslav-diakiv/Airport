using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportEf.DAL.Data.Migrations
{
    public partial class LinkedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Crews_CrewId",
                table: "Departures");

            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Flights_FlightNumber",
                table: "Departures");

            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Planes_PlaneId",
                table: "Departures");

            migrationBuilder.DropForeignKey(
                name: "FK_Planes_PlaneTypes_PlaneTypeId",
                table: "Planes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_FlightNumber",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Crews_CrewId",
                table: "Departures",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Flights_FlightNumber",
                table: "Departures",
                column: "FlightNumber",
                principalTable: "Flights",
                principalColumn: "Number",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Planes_PlaneId",
                table: "Departures",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_PlaneTypes_PlaneTypeId",
                table: "Planes",
                column: "PlaneTypeId",
                principalTable: "PlaneTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_FlightNumber",
                table: "Tickets",
                column: "FlightNumber",
                principalTable: "Flights",
                principalColumn: "Number",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Crews_CrewId",
                table: "Departures");

            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Flights_FlightNumber",
                table: "Departures");

            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Planes_PlaneId",
                table: "Departures");

            migrationBuilder.DropForeignKey(
                name: "FK_Planes_PlaneTypes_PlaneTypeId",
                table: "Planes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Flights_FlightNumber",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Crews_CrewId",
                table: "Departures",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Flights_FlightNumber",
                table: "Departures",
                column: "FlightNumber",
                principalTable: "Flights",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Planes_PlaneId",
                table: "Departures",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_PlaneTypes_PlaneTypeId",
                table: "Planes",
                column: "PlaneTypeId",
                principalTable: "PlaneTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Flights_FlightNumber",
                table: "Tickets",
                column: "FlightNumber",
                principalTable: "Flights",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

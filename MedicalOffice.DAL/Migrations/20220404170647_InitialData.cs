using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalOffice.DAL.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cabinet",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, "289a" },
                    { 2, "335" },
                    { 3, "258" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Address", "DateOfBirth", "FirstName", "Gender", "LastName", "SecondName" },
                values: new object[,]
                {
                    { 1, "ул Калатушкина", new DateTime(1995, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", 1, "Иванов", "Иванович" },
                    { 2, "ул Калатушкина", new DateTime(1995, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Петр", 1, "Петрович", "Петров" },
                    { 3, "ул Калатушкина", new DateTime(1995, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Алексей", 1, "Алексеевич", "Алексеев" },
                    { 4, "ул Калатушкина", new DateTime(1995, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Виктор", 1, "Викторов", "Викторович" },
                    { 5, "ул Калатушкина", new DateTime(1995, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Юлия", 2, "Иванова", "Ивановна" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, "26" },
                    { 2, "28" },
                    { 3, "29" }
                });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Хирург" },
                    { 2, "Онколог" },
                    { 3, "Анестезиолог" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "CabinetId", "FirstName", "LastName", "RegionId", "SecondName", "SpecializationId" },
                values: new object[,]
                {
                    { 1, 1, "Виктор", "Васильев", null, "Петрович", 1 },
                    { 2, 2, "Николай", "Илонов", null, "Алексеевич", 2 },
                    { 3, 3, "Василий", "Сдобов", 1, "Васильевич", 3 }
                });

            migrationBuilder.InsertData(
                table: "PatientRegionMapping",
                columns: new[] { "PatientId", "RegionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 3, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PatientRegionMapping",
                keyColumns: new[] { "PatientId", "RegionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PatientRegionMapping",
                keyColumns: new[] { "PatientId", "RegionId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PatientRegionMapping",
                keyColumns: new[] { "PatientId", "RegionId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cabinet",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cabinet",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cabinet",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Region",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

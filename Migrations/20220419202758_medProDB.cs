using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedPro.Migrations
{
    public partial class medProDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    sId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    timeNeeded = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sId", x => x.sId);
                });

            migrationBuilder.CreateTable(
                name: "times",
                columns: table => new
                {
                    timeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    timeStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    timeEnd = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_times", x => x.timeId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    docId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_docId", x => x.docId);
                    table.ForeignKey(
                        name: "fk_docUserId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    pId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pId", x => x.pId);
                    table.ForeignKey(
                        name: "fk_pUserId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "availability",
                columns: table => new
                {
                    availId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    docId = table.Column<int>(type: "int", nullable: false),
                    timeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_availId", x => x.availId);
                    table.ForeignKey(
                        name: "fk_availDocId",
                        column: x => x.docId,
                        principalTable: "doctors",
                        principalColumn: "docId");
                    table.ForeignKey(
                        name: "fk_availTimeId",
                        column: x => x.timeId,
                        principalTable: "times",
                        principalColumn: "timeId");
                });

            migrationBuilder.CreateTable(
                name: "doctorservices",
                columns: table => new
                {
                    dsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    docId = table.Column<int>(type: "int", nullable: false),
                    sId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dsId", x => x.dsId);
                    table.ForeignKey(
                        name: "fk_dsDocId",
                        column: x => x.docId,
                        principalTable: "doctors",
                        principalColumn: "docId");
                    table.ForeignKey(
                        name: "fk_dsSId",
                        column: x => x.sId,
                        principalTable: "services",
                        principalColumn: "sId");
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    apptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pId = table.Column<int>(type: "int", nullable: false),
                    docId = table.Column<int>(type: "int", nullable: false),
                    timeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_apptId", x => x.apptId);
                    table.ForeignKey(
                        name: "fk_apptDocId",
                        column: x => x.docId,
                        principalTable: "doctors",
                        principalColumn: "docId");
                    table.ForeignKey(
                        name: "fk_apptPId",
                        column: x => x.pId,
                        principalTable: "patients",
                        principalColumn: "pId");
                    table.ForeignKey(
                        name: "fk_apptTimeId",
                        column: x => x.timeId,
                        principalTable: "times",
                        principalColumn: "timeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_docId",
                table: "appointments",
                column: "docId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_pId",
                table: "appointments",
                column: "pId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_timeId",
                table: "appointments",
                column: "timeId");

            migrationBuilder.CreateIndex(
                name: "IX_availability_docId",
                table: "availability",
                column: "docId");

            migrationBuilder.CreateIndex(
                name: "IX_availability_timeId",
                table: "availability",
                column: "timeId");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_userId",
                table: "doctors",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_doctorservices_docId",
                table: "doctorservices",
                column: "docId");

            migrationBuilder.CreateIndex(
                name: "IX_doctorservices_sId",
                table: "doctorservices",
                column: "sId");

            migrationBuilder.CreateIndex(
                name: "IX_patients_userId",
                table: "patients",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "availability");

            migrationBuilder.DropTable(
                name: "doctorservices");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "times");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}

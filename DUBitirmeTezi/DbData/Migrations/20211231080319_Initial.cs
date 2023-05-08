using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DUBitirmeTezi.DbData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duyurulars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuyuruAdi = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Aciklama1 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Aciklama2 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    EklendigiTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duyurulars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enstitus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnstituName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enstitus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fakultes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakultes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FotografGalerisis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotografGalerisis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeslekYuksekokulus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicalSchoolName = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeslekYuksekokulus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjeSayilaris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Fakulte = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Enstitu = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Yuksekokul = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MeslekYuksekokulu = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    LisansProgrami = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    LisansutsuProgrami = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    UygulamaArastirmaMerkezi = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Koordinatorluk = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    BapProjesi = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Patent = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    SponsorluProje = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    TubitakProjesi = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeSayilaris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YetkiliGirisis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    DahiliTelefon = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    KullanicininEklendigiTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YetkiliGirisis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yonetims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unvan = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yonetims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yuksekokuls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollageName = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yuksekokuls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnstituDetays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnstituId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnstituDetays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnstituDetays_Enstitus_EnstituId",
                        column: x => x.EnstituId,
                        principalTable: "Enstitus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FakulteDetays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteId = table.Column<int>(type: "int", nullable: false),
                    EducationName = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Mission = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Vision = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakulteDetays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FakulteDetays_Fakultes_FakulteId",
                        column: x => x.FakulteId,
                        principalTable: "Fakultes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeslekYuksekokulDetays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeslekYuksekokuluId = table.Column<int>(type: "int", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeslekYuksekokulDetays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeslekYuksekokulDetays_MeslekYuksekokulus_MeslekYuksekokuluId",
                        column: x => x.MeslekYuksekokuluId,
                        principalTable: "MeslekYuksekokulus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YonetimDetays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YonetimId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YonetimDetays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YonetimDetays_Yonetims_YonetimId",
                        column: x => x.YonetimId,
                        principalTable: "Yonetims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YuksekokulDetays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YuksekokulId = table.Column<int>(type: "int", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YuksekokulDetays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YuksekokulDetays_Yuksekokuls_YuksekokulId",
                        column: x => x.YuksekokulId,
                        principalTable: "Yuksekokuls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProjeSayilaris",
                columns: new[] { "Id", "Aciklama", "BapProjesi", "Baslik", "Enstitu", "Fakulte", "Koordinatorluk", "LisansProgrami", "LisansutsuProgrami", "MeslekYuksekokulu", "Patent", "SponsorluProje", "TubitakProjesi", "UygulamaArastirmaMerkezi", "Yuksekokul" },
                values: new object[] { 1, "Sanayi ve iş dünyası ile üniversiteyi ortak akıl, ortak hedef ve ortak başarı ilkeleri doğrultusunda ortak projelerle biraraya getirerek üniversitenin ve sanayinin gelişmesine katkıda bulunmaktır.", "500", "KENTİMİZ VE SANAYİ ELELE ÜRETEN ÜNİVERSİTE", "4", "14", "7", "66", "71", "17", "300", "5", "77", "21", "14" });

            migrationBuilder.InsertData(
                table: "YetkiliGirisis",
                columns: new[] { "Id", "Ad", "AktifMi", "DahiliTelefon", "KullaniciAdi", "KullanicininEklendigiTarih", "Mail", "Sifre", "Soyad", "Telefon" },
                values: new object[] { 1, "Melih", true, "1234", "MelihDincer", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "melihdincer@gmail.com", "melih", "Dinçer", "05311048276" });

            migrationBuilder.InsertData(
                table: "YetkiliGirisis",
                columns: new[] { "Id", "Ad", "AktifMi", "DahiliTelefon", "KullaniciAdi", "KullanicininEklendigiTarih", "Mail", "Sifre", "Soyad", "Telefon" },
                values: new object[] { 2, "admin", true, "1234", "admin", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "admin", "admin", "05055055555" });

            migrationBuilder.CreateIndex(
                name: "IX_EnstituDetays_EnstituId",
                table: "EnstituDetays",
                column: "EnstituId");

            migrationBuilder.CreateIndex(
                name: "IX_FakulteDetays_FakulteId",
                table: "FakulteDetays",
                column: "FakulteId");

            migrationBuilder.CreateIndex(
                name: "IX_MeslekYuksekokulDetays_MeslekYuksekokuluId",
                table: "MeslekYuksekokulDetays",
                column: "MeslekYuksekokuluId");

            migrationBuilder.CreateIndex(
                name: "IX_YonetimDetays_YonetimId",
                table: "YonetimDetays",
                column: "YonetimId");

            migrationBuilder.CreateIndex(
                name: "IX_YuksekokulDetays_YuksekokulId",
                table: "YuksekokulDetays",
                column: "YuksekokulId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duyurulars");

            migrationBuilder.DropTable(
                name: "EnstituDetays");

            migrationBuilder.DropTable(
                name: "FakulteDetays");

            migrationBuilder.DropTable(
                name: "FotografGalerisis");

            migrationBuilder.DropTable(
                name: "MeslekYuksekokulDetays");

            migrationBuilder.DropTable(
                name: "ProjeSayilaris");

            migrationBuilder.DropTable(
                name: "YetkiliGirisis");

            migrationBuilder.DropTable(
                name: "YonetimDetays");

            migrationBuilder.DropTable(
                name: "YuksekokulDetays");

            migrationBuilder.DropTable(
                name: "Enstitus");

            migrationBuilder.DropTable(
                name: "Fakultes");

            migrationBuilder.DropTable(
                name: "MeslekYuksekokulus");

            migrationBuilder.DropTable(
                name: "Yonetims");

            migrationBuilder.DropTable(
                name: "Yuksekokuls");
        }
    }
}

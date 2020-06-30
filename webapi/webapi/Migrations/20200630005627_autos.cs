using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations
{
    public partial class autos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminuserroles",
                columns: table => new
                {
                    AdminUserId = table.Column<string>(maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminuserroles", x => x.AdminUserId);
                });

            migrationBuilder.CreateTable(
                name: "adminusers",
                columns: table => new
                {
                    AdminUserId = table.Column<string>(maxLength: 50, nullable: false),
                    AdminUserPwd = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminusers", x => x.AdminUserId);
                });

            migrationBuilder.CreateTable(
                name: "autosbuyer",
                columns: table => new
                {
                    BuyrID = table.Column<string>(maxLength: 30, nullable: false),
                    FsName = table.Column<string>(maxLength: 45, nullable: true),
                    LsName = table.Column<string>(maxLength: 45, nullable: true),
                    EmalID = table.Column<string>(maxLength: 45, nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    StatNm = table.Column<string>(maxLength: 45, nullable: true),
                    CityNm = table.Column<string>(maxLength: 45, nullable: true),
                    ZipCod = table.Column<string>(maxLength: 45, nullable: true),
                    CnName = table.Column<string>(maxLength: 45, nullable: true),
                    HomePn = table.Column<string>(maxLength: 20, nullable: true),
                    WorkPn = table.Column<string>(maxLength: 20, nullable: true),
                    CellPn1 = table.Column<string>(maxLength: 20, nullable: true),
                    CellPn2 = table.Column<string>(maxLength: 20, nullable: true),
                    BuType = table.Column<string>(maxLength: 20, nullable: true),
                    AutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autosbuyer", x => x.BuyrID);
                });

            migrationBuilder.CreateTable(
                name: "autosseller",
                columns: table => new
                {
                    SellID = table.Column<string>(maxLength: 30, nullable: false),
                    FsName = table.Column<string>(maxLength: 45, nullable: true),
                    LsName = table.Column<string>(maxLength: 45, nullable: true),
                    EmalID = table.Column<string>(maxLength: 45, nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    StatNm = table.Column<string>(maxLength: 45, nullable: true),
                    CityNm = table.Column<string>(maxLength: 45, nullable: true),
                    ZipCod = table.Column<string>(maxLength: 45, nullable: true),
                    CnName = table.Column<string>(maxLength: 45, nullable: true),
                    HomePn = table.Column<string>(maxLength: 20, nullable: true),
                    WorkPn = table.Column<string>(maxLength: 20, nullable: true),
                    CellPn1 = table.Column<string>(maxLength: 20, nullable: true),
                    CellPn2 = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autosseller", x => x.SellID);
                });

            migrationBuilder.CreateTable(
                name: "carbody",
                columns: table => new
                {
                    BodyId = table.Column<string>(maxLength: 30, nullable: false),
                    BDDesc = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carbody", x => x.BodyId);
                });

            migrationBuilder.CreateTable(
                name: "carcategory",
                columns: table => new
                {
                    CatgId = table.Column<string>(maxLength: 30, nullable: false),
                    CgDesc = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carcategory", x => x.CatgId);
                });

            migrationBuilder.CreateTable(
                name: "carmake",
                columns: table => new
                {
                    MakeId = table.Column<string>(maxLength: 30, nullable: false),
                    MkDesc = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carmake", x => x.MakeId);
                });

            migrationBuilder.CreateTable(
                name: "carmodel",
                columns: table => new
                {
                    ModlId = table.Column<string>(maxLength: 30, nullable: false),
                    MdDesc = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carmodel", x => x.ModlId);
                });

            migrationBuilder.CreateTable(
                name: "orderdetails",
                columns: table => new
                {
                    TRREFN = table.Column<int>(nullable: false),
                    TRDATE = table.Column<DateTime>(nullable: false),
                    AutoId = table.Column<int>(nullable: false),
                    BuyrID = table.Column<string>(maxLength: 30, nullable: true),
                    PURDAT = table.Column<DateTime>(maxLength: 1, nullable: false),
                    PURAMT = table.Column<int>(nullable: false),
                    PURTYP = table.Column<string>(nullable: true),
                    INVNUM = table.Column<int>(nullable: false),
                    CRDNUM = table.Column<string>(maxLength: 30, nullable: true),
                    CRDEXP = table.Column<DateTime>(nullable: false),
                    CRDTYP = table.Column<string>(maxLength: 1, nullable: true),
                    CRDCRV = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetails", x => new { x.TRREFN, x.TRDATE });
                    table.UniqueConstraint("AK_orderdetails_TRDATE_TRREFN", x => new { x.TRDATE, x.TRREFN });
                });

            migrationBuilder.CreateTable(
                name: "orderMaster",
                columns: table => new
                {
                    INVNUM = table.Column<int>(nullable: false),
                    TRDATE = table.Column<DateTime>(nullable: false),
                    BUYRID = table.Column<string>(maxLength: 30, nullable: true),
                    AMOUNT = table.Column<int>(nullable: false),
                    PartialPayment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderMaster", x => new { x.INVNUM, x.TRDATE });
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleDesc = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SiteUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 50, nullable: false),
                    UserFName = table.Column<string>(maxLength: 50, nullable: true),
                    UserMName = table.Column<string>(maxLength: 50, nullable: true),
                    UserLName = table.Column<string>(maxLength: 50, nullable: true),
                    UserPassword = table.Column<string>(maxLength: 50, nullable: true),
                    UserEmail = table.Column<string>(maxLength: 50, nullable: true),
                    IsActive = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<int>(nullable: false),
                    UserType = table.Column<string>(maxLength: 50, nullable: true),
                    RegDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "vehiclefeatures",
                columns: table => new
                {
                    FEATID = table.Column<string>(maxLength: 50, nullable: false),
                    FTDESC = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiclefeatures", x => x.FEATID);
                });

            migrationBuilder.CreateTable(
                name: "AutosVehicle",
                columns: table => new
                {
                    AutoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Acolor = table.Column<string>(maxLength: 30, nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    StatNm = table.Column<string>(maxLength: 45, nullable: true),
                    CityNm = table.Column<string>(maxLength: 45, nullable: true),
                    ZipCod = table.Column<string>(maxLength: 45, nullable: true),
                    CnName = table.Column<string>(maxLength: 45, nullable: true),
                    Mileag = table.Column<string>(maxLength: 45, nullable: true),
                    SellPri = table.Column<int>(nullable: false),
                    AuYear = table.Column<int>(nullable: false),
                    FuelType = table.Column<string>(maxLength: 45, nullable: true),
                    Transmission = table.Column<string>(maxLength: 45, nullable: true),
                    Power = table.Column<string>(maxLength: 45, nullable: true),
                    Volume = table.Column<int>(nullable: false),
                    Engine = table.Column<string>(maxLength: 45, nullable: true),
                    Seater = table.Column<int>(nullable: false),
                    Cosumption = table.Column<int>(nullable: false),
                    NoOfDoors = table.Column<int>(nullable: false),
                    IsSold = table.Column<int>(nullable: false),
                    IsReserved = table.Column<int>(nullable: false),
                    IsFeatured = table.Column<int>(nullable: false),
                    IsTrendy = table.Column<int>(nullable: false),
                    MakeId = table.Column<string>(nullable: true),
                    ModlId = table.Column<string>(nullable: true),
                    BodyId = table.Column<string>(nullable: true),
                    CatgId = table.Column<string>(nullable: true),
                    SellID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutosVehicle", x => x.AutoId);
                    table.ForeignKey(
                        name: "FK_AutosVehicle_carbody_BodyId",
                        column: x => x.BodyId,
                        principalTable: "carbody",
                        principalColumn: "BodyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutosVehicle_carcategory_CatgId",
                        column: x => x.CatgId,
                        principalTable: "carcategory",
                        principalColumn: "CatgId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutosVehicle_carmake_MakeId",
                        column: x => x.MakeId,
                        principalTable: "carmake",
                        principalColumn: "MakeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutosVehicle_carmodel_ModlId",
                        column: x => x.ModlId,
                        principalTable: "carmodel",
                        principalColumn: "ModlId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutosFeatures",
                columns: table => new
                {
                    AuFeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuDesc = table.Column<string>(maxLength: 70, nullable: true),
                    FEATID = table.Column<int>(nullable: false),
                    AutoId = table.Column<int>(nullable: false),
                    VehiclefeaturesFEATID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutosFeatures", x => x.AuFeId);
                    table.ForeignKey(
                        name: "FK_AutosFeatures_AutosVehicle_AutoId",
                        column: x => x.AutoId,
                        principalTable: "AutosVehicle",
                        principalColumn: "AutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutosFeatures_vehiclefeatures_VehiclefeaturesFEATID",
                        column: x => x.VehiclefeaturesFEATID,
                        principalTable: "vehiclefeatures",
                        principalColumn: "FEATID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutosImages",
                columns: table => new
                {
                    ImageID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AutosID = table.Column<int>(nullable: false),
                    ImgURL = table.Column<string>(maxLength: 200, nullable: true),
                    AutosVehicleAutoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutosImages", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_AutosImages_AutosVehicle_AutosVehicleAutoId",
                        column: x => x.AutosVehicleAutoId,
                        principalTable: "AutosVehicle",
                        principalColumn: "AutoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutosFeatures_AutoId",
                table: "AutosFeatures",
                column: "AutoId");

            migrationBuilder.CreateIndex(
                name: "IX_AutosFeatures_VehiclefeaturesFEATID",
                table: "AutosFeatures",
                column: "VehiclefeaturesFEATID");

            migrationBuilder.CreateIndex(
                name: "IX_AutosImages_AutosVehicleAutoId",
                table: "AutosImages",
                column: "AutosVehicleAutoId");

            migrationBuilder.CreateIndex(
                name: "IX_AutosVehicle_BodyId",
                table: "AutosVehicle",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_AutosVehicle_CatgId",
                table: "AutosVehicle",
                column: "CatgId");

            migrationBuilder.CreateIndex(
                name: "IX_AutosVehicle_MakeId",
                table: "AutosVehicle",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_AutosVehicle_ModlId",
                table: "AutosVehicle",
                column: "ModlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminuserroles");

            migrationBuilder.DropTable(
                name: "adminusers");

            migrationBuilder.DropTable(
                name: "autosbuyer");

            migrationBuilder.DropTable(
                name: "AutosFeatures");

            migrationBuilder.DropTable(
                name: "AutosImages");

            migrationBuilder.DropTable(
                name: "autosseller");

            migrationBuilder.DropTable(
                name: "orderdetails");

            migrationBuilder.DropTable(
                name: "orderMaster");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SiteUsers");

            migrationBuilder.DropTable(
                name: "vehiclefeatures");

            migrationBuilder.DropTable(
                name: "AutosVehicle");

            migrationBuilder.DropTable(
                name: "carbody");

            migrationBuilder.DropTable(
                name: "carcategory");

            migrationBuilder.DropTable(
                name: "carmake");

            migrationBuilder.DropTable(
                name: "carmodel");
        }
    }
}

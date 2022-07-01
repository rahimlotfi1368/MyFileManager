using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaadiranChainStorePrices.Migrations
{
    public partial class _init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbChainStorePriceBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KatalogName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbChainStorePriceBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbChainStorePriceUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbChainStorePriceUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TbChainStorePriceUser",
                columns: new[] { "Id", "CreateDate", "Creator", "DeleteDate", "FullName", "IsDelete", "Password", "PersonelCode", "UserName" },
                values: new object[] { new Guid("99201dfc-70ad-4dc6-bf41-1f8172efbbab"), new DateTime(2022, 6, 30, 17, 42, 40, 496, DateTimeKind.Utc).AddTicks(3740), null, null, "رحیم لطفی", null, "$2a$11$zuum5sIzXQWxl9jxJn1qR.aa6ssErbcrudQfuxUbYu21h0J7n73CC", "12002", "ChainStoreAdmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbChainStorePriceBrand");

            migrationBuilder.DropTable(
                name: "TbChainStorePriceUser");
        }
    }
}

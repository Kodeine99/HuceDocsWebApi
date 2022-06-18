using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDTest.Data.Migrations
{
    public partial class AddVerifyLinkToOCR_Request : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 18, 10, 53, 10, 498, DateTimeKind.Local).AddTicks(9211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 943, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.AddColumn<string>(
                name: "VerifyLink",
                table: "OCR_Request",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 18, 10, 53, 10, 502, DateTimeKind.Local).AddTicks(5311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 948, DateTimeKind.Local).AddTicks(4226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 18, 10, 53, 10, 506, DateTimeKind.Local).AddTicks(7225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 954, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 18, 10, 53, 10, 471, DateTimeKind.Local).AddTicks(7080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 910, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 18, 10, 53, 10, 515, DateTimeKind.Local).AddTicks(375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 960, DateTimeKind.Local).AddTicks(2078));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerifyLink",
                table: "OCR_Request");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 943, DateTimeKind.Local).AddTicks(1882),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 18, 10, 53, 10, 498, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 948, DateTimeKind.Local).AddTicks(4226),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 18, 10, 53, 10, 502, DateTimeKind.Local).AddTicks(5311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 954, DateTimeKind.Local).AddTicks(597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 18, 10, 53, 10, 506, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 910, DateTimeKind.Local).AddTicks(8370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 18, 10, 53, 10, 471, DateTimeKind.Local).AddTicks(7080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 960, DateTimeKind.Local).AddTicks(2078),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 18, 10, 53, 10, 515, DateTimeKind.Local).AddTicks(375));
        }
    }
}

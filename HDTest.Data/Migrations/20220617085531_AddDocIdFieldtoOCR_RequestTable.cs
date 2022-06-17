using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDTest.Data.Migrations
{
    public partial class AddDocIdFieldtoOCR_RequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 943, DateTimeKind.Local).AddTicks(1882),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 15, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "OCR_Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 948, DateTimeKind.Local).AddTicks(4226),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 18, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 954, DateTimeKind.Local).AddTicks(597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 26, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 910, DateTimeKind.Local).AddTicks(8370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 14, 52, 1, 981, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 960, DateTimeKind.Local).AddTicks(2078),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 35, DateTimeKind.Local).AddTicks(2525));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "OCR_Request");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 15, DateTimeKind.Local).AddTicks(3148),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 943, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 18, DateTimeKind.Local).AddTicks(7908),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 948, DateTimeKind.Local).AddTicks(4226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 26, DateTimeKind.Local).AddTicks(4071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 954, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 14, 52, 1, 981, DateTimeKind.Local).AddTicks(4758),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 910, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 35, DateTimeKind.Local).AddTicks(2525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 15, 55, 30, 960, DateTimeKind.Local).AddTicks(2078));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDTest.Data.Migrations
{
    public partial class configBangDiemTiengAnhModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Verify",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 20, 15, 38, 23, 759, DateTimeKind.Local).AddTicks(4510),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 19, 23, 17, 34, 352, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 20, 15, 38, 23, 763, DateTimeKind.Local).AddTicks(2924),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 19, 23, 17, 34, 357, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 20, 15, 38, 23, 767, DateTimeKind.Local).AddTicks(3785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 19, 23, 17, 34, 362, DateTimeKind.Local).AddTicks(4723));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 20, 15, 38, 23, 733, DateTimeKind.Local).AddTicks(970),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 19, 23, 17, 34, 317, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.AlterColumn<string>(
                name: "TRAINING_FORM",
                table: "BANG_DIEM_TIENG_ANH",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "TOTAL_CREDITS",
                table: "BANG_DIEM_TIENG_ANH",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "TICKET_ID",
                table: "BANG_DIEM_TIENG_ANH",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "S_CLASS",
                table: "BANG_DIEM_TIENG_ANH",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "STUDENT_ID",
                table: "BANG_DIEM_TIENG_ANH",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "MAJOR",
                table: "BANG_DIEM_TIENG_ANH",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "GPA_4SCALE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "GPA_10SCALE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "FULL_NAME",
                table: "BANG_DIEM_TIENG_ANH",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 20, 15, 38, 23, 770, DateTimeKind.Local).AddTicks(3956),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 19, 23, 17, 34, 368, DateTimeKind.Local).AddTicks(8527));

            migrationBuilder.AlterColumn<string>(
                name: "CLASSIFICATION",
                table: "BANG_DIEM_TIENG_ANH",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.CreateIndex(
                name: "IX_BANG_DIEM_TIENG_ANH_TICKET_ID",
                table: "BANG_DIEM_TIENG_ANH",
                column: "TICKET_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BANG_DIEM_TIENG_ANH_OCR_Request_TICKET_ID",
                table: "BANG_DIEM_TIENG_ANH",
                column: "TICKET_ID",
                principalTable: "OCR_Request",
                principalColumn: "Ticket_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BANG_DIEM_TIENG_ANH_OCR_Request_TICKET_ID",
                table: "BANG_DIEM_TIENG_ANH");

            migrationBuilder.DropIndex(
                name: "IX_BANG_DIEM_TIENG_ANH_TICKET_ID",
                table: "BANG_DIEM_TIENG_ANH");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Verify",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 19, 23, 17, 34, 352, DateTimeKind.Local).AddTicks(528),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 20, 15, 38, 23, 759, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 19, 23, 17, 34, 357, DateTimeKind.Local).AddTicks(2467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 20, 15, 38, 23, 763, DateTimeKind.Local).AddTicks(2924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 19, 23, 17, 34, 362, DateTimeKind.Local).AddTicks(4723),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 20, 15, 38, 23, 767, DateTimeKind.Local).AddTicks(3785));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 19, 23, 17, 34, 317, DateTimeKind.Local).AddTicks(9382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 20, 15, 38, 23, 733, DateTimeKind.Local).AddTicks(970));

            migrationBuilder.AlterColumn<int>(
                name: "TRAINING_FORM",
                table: "BANG_DIEM_TIENG_ANH",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TOTAL_CREDITS",
                table: "BANG_DIEM_TIENG_ANH",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TICKET_ID",
                table: "BANG_DIEM_TIENG_ANH",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "S_CLASS",
                table: "BANG_DIEM_TIENG_ANH",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "STUDENT_ID",
                table: "BANG_DIEM_TIENG_ANH",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MAJOR",
                table: "BANG_DIEM_TIENG_ANH",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GPA_4SCALE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GPA_10SCALE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FULL_NAME",
                table: "BANG_DIEM_TIENG_ANH",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 19, 23, 17, 34, 368, DateTimeKind.Local).AddTicks(8527),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 20, 15, 38, 23, 770, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.AlterColumn<int>(
                name: "CLASSIFICATION",
                table: "BANG_DIEM_TIENG_ANH",
                type: "int",
                maxLength: 255,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}

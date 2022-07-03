using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDTest.Data.Migrations
{
    public partial class addDON_XIN_NHAP_HOC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "THE_SINH_VIEN",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 304, DateTimeKind.Local).AddTicks(6145),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 305, DateTimeKind.Local).AddTicks(6908));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 272, DateTimeKind.Local).AddTicks(5601),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 274, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_VAY_VON",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 293, DateTimeKind.Local).AddTicks(3561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 292, DateTimeKind.Local).AddTicks(1470));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 278, DateTimeKind.Local).AddTicks(4650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 278, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 283, DateTimeKind.Local).AddTicks(6630),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 284, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 235, DateTimeKind.Local).AddTicks(996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 231, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "CCCD",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 301, DateTimeKind.Local).AddTicks(571),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 301, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 287, DateTimeKind.Local).AddTicks(523),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 288, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 297, DateTimeKind.Local).AddTicks(13),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 295, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.CreateTable(
                name: "DON_XIN_NHAP_HOC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TICKET_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HUCEDOCS_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_CREATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 310, DateTimeKind.Local).AddTicks(6110)),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    NGUOI_LAP_DON = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_SINH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MSSV = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KHOA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LOP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NHAP_HOC_TU_KY = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SO_GIAY_PHEP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_NGHI_THEO_GIAY_PHEP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_KY = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DON_XIN_NHAP_HOC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DON_XIN_NHAP_HOC_OCR_Request_TICKET_ID",
                        column: x => x.TICKET_ID,
                        principalTable: "OCR_Request",
                        principalColumn: "Ticket_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DON_XIN_NHAP_HOC_TICKET_ID",
                table: "DON_XIN_NHAP_HOC",
                column: "TICKET_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DON_XIN_NHAP_HOC");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "THE_SINH_VIEN",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 305, DateTimeKind.Local).AddTicks(6908),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 304, DateTimeKind.Local).AddTicks(6145));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 274, DateTimeKind.Local).AddTicks(5190),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 272, DateTimeKind.Local).AddTicks(5601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_VAY_VON",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 292, DateTimeKind.Local).AddTicks(1470),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 293, DateTimeKind.Local).AddTicks(3561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 278, DateTimeKind.Local).AddTicks(6536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 278, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 284, DateTimeKind.Local).AddTicks(8817),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 283, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 231, DateTimeKind.Local).AddTicks(1905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 235, DateTimeKind.Local).AddTicks(996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "CCCD",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 301, DateTimeKind.Local).AddTicks(635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 301, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 288, DateTimeKind.Local).AddTicks(2314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 287, DateTimeKind.Local).AddTicks(523));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 295, DateTimeKind.Local).AddTicks(4204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 3, 22, 7, 24, 297, DateTimeKind.Local).AddTicks(13));
        }
    }
}

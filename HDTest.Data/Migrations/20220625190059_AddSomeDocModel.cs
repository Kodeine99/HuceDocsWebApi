using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDTest.Data.Migrations
{
    public partial class AddSomeDocModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 927, DateTimeKind.Local).AddTicks(4422),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 11, 27, 802, DateTimeKind.Local).AddTicks(7475));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 931, DateTimeKind.Local).AddTicks(1882),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 11, 27, 806, DateTimeKind.Local).AddTicks(3238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 935, DateTimeKind.Local).AddTicks(1788),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 11, 27, 810, DateTimeKind.Local).AddTicks(146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 897, DateTimeKind.Local).AddTicks(9285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 11, 27, 779, DateTimeKind.Local).AddTicks(644));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 939, DateTimeKind.Local).AddTicks(3908),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 11, 27, 812, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.CreateTable(
                name: "BANG_DIEM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TICKET_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HUCEDOCS_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_CREATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 946, DateTimeKind.Local).AddTicks(8033)),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    HO_TEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MSSV = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_SINH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGANH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HE_DAO_TAO = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    THANG_DIEM_10 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    THANG_DIEM_4 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TONG_SO_TIN_CHI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MARK_TABLE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANG_DIEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BANG_DIEM_OCR_Request_TICKET_ID",
                        column: x => x.TICKET_ID,
                        principalTable: "OCR_Request",
                        principalColumn: "Ticket_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CCCD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TICKET_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HUCEDOCS_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_CREATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 949, DateTimeKind.Local).AddTicks(5662)),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    HO_TEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SO_THE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_SINH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GIOI_TINH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    QUOC_TICH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    QUE_QUAN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DIA_CHI_THUONG_TRU = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_CAP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCCD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCCD_OCR_Request_TICKET_ID",
                        column: x => x.TICKET_ID,
                        principalTable: "OCR_Request",
                        principalColumn: "Ticket_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GIAY_XAC_NHAN_VAY_VON",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TICKET_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HUCEDOCS_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_CREATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 943, DateTimeKind.Local).AddTicks(7114)),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    HO_TEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_SINH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GIOI_TINH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CMND = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_CAP_CMND = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NOI_CAP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MA_TRUONG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TEN_TRUONG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGANH_HOC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HE_DT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SO_KHOA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LOP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MSSV = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KHOA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_NHAP_HOC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_RA_TRUONG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HOC_PHI_MOI_THANG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    STK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TAI_NH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CM_THUOC_DIEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CM_THUOC_DOI_TUONG = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIAY_XAC_NHAN_VAY_VON", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GIAY_XAC_NHAN_VAY_VON_OCR_Request_TICKET_ID",
                        column: x => x.TICKET_ID,
                        principalTable: "OCR_Request",
                        principalColumn: "Ticket_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BANG_DIEM_TICKET_ID",
                table: "BANG_DIEM",
                column: "TICKET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CCCD_TICKET_ID",
                table: "CCCD",
                column: "TICKET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GIAY_XAC_NHAN_VAY_VON_TICKET_ID",
                table: "GIAY_XAC_NHAN_VAY_VON",
                column: "TICKET_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANG_DIEM");

            migrationBuilder.DropTable(
                name: "CCCD");

            migrationBuilder.DropTable(
                name: "GIAY_XAC_NHAN_VAY_VON");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 11, 27, 802, DateTimeKind.Local).AddTicks(7475),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 927, DateTimeKind.Local).AddTicks(4422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 11, 27, 806, DateTimeKind.Local).AddTicks(3238),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 931, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 11, 27, 810, DateTimeKind.Local).AddTicks(146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 935, DateTimeKind.Local).AddTicks(1788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 11, 27, 779, DateTimeKind.Local).AddTicks(644),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 897, DateTimeKind.Local).AddTicks(9285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 11, 27, 812, DateTimeKind.Local).AddTicks(7644),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 2, 0, 58, 939, DateTimeKind.Local).AddTicks(3908));
        }
    }
}

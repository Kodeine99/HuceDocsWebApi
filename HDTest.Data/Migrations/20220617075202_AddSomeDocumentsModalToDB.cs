using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDTest.Data.Migrations
{
    public partial class AddSomeDocumentsModalToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JsonData",
                table: "OCR_Request",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 15, DateTimeKind.Local).AddTicks(3148),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 15, 19, 17, 47, 57, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 18, DateTimeKind.Local).AddTicks(7908),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 15, 19, 17, 47, 60, DateTimeKind.Local).AddTicks(1264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 14, 52, 1, 981, DateTimeKind.Local).AddTicks(4758),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 15, 19, 17, 47, 34, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.CreateTable(
                name: "BANG_DIEM_TIENG_ANH",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TICKET_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HUCEDOCS_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_CREATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 35, DateTimeKind.Local).AddTicks(2525)),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    FULL_NAME = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MAJOR = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    STUDENT_ID = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    S_CLASS = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    TRAINING_FORM = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    GPA_10SCALE = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    GPA_4SCALE = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    TOTAL_CREDITS = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    CLASSIFICATION = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    MARK_TABLE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANG_DIEM_TIENG_ANH", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GIAY_CAM_KET_TRA_NO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TICKET_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HUCEDOCS_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_CREATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 26, DateTimeKind.Local).AddTicks(4071)),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    MAU_SO = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HO_TEN_SV = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_SINH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GIOI_TINH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CMND = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_CAP_CMND = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOI_CAP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LOP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KHOA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SO_THE_HSSV = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NIEN_KHOA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LOAI_HINH_DAO_TAO = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_NHAP_HOC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NGAY_RA_TRUONG = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MA_TRUONG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGUOI_DUNG_TEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DIA_CHI_NGUOI_DUNG_TEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAN_HANG_VAY_VON = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SO_TIEN_BANG_SO = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SO_TIEN_BANG_CHU = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_KY = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIAY_CAM_KET_TRA_NO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GIAY_CAM_KET_TRA_NO_OCR_Request_TICKET_ID",
                        column: x => x.TICKET_ID,
                        principalTable: "OCR_Request",
                        principalColumn: "Ticket_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GIAY_CAM_KET_TRA_NO_TICKET_ID",
                table: "GIAY_CAM_KET_TRA_NO",
                column: "TICKET_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANG_DIEM_TIENG_ANH");

            migrationBuilder.DropTable(
                name: "GIAY_CAM_KET_TRA_NO");

            migrationBuilder.AlterColumn<string>(
                name: "JsonData",
                table: "OCR_Request",
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
                defaultValue: new DateTime(2022, 6, 15, 19, 17, 47, 57, DateTimeKind.Local).AddTicks(1133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 15, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 15, 19, 17, 47, 60, DateTimeKind.Local).AddTicks(1264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 14, 52, 2, 18, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 15, 19, 17, 47, 34, DateTimeKind.Local).AddTicks(6057),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 14, 52, 1, 981, DateTimeKind.Local).AddTicks(4758));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDTest.Data.Migrations
{
    public partial class AddTheSinhVienModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SO_THE",
                table: "CCCD",
                newName: "SO");

            migrationBuilder.RenameColumn(
                name: "HO_TEN",
                table: "CCCD",
                newName: "NOI_THUONG_TRU");

            migrationBuilder.RenameColumn(
                name: "DIA_CHI_THUONG_TRU",
                table: "CCCD",
                newName: "NGUOI_KY");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 274, DateTimeKind.Local).AddTicks(5190),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 45, DateTimeKind.Local).AddTicks(4678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_VAY_VON",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 292, DateTimeKind.Local).AddTicks(1470),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 64, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 278, DateTimeKind.Local).AddTicks(6536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 50, DateTimeKind.Local).AddTicks(5073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 284, DateTimeKind.Local).AddTicks(8817),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 56, DateTimeKind.Local).AddTicks(1832));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 231, DateTimeKind.Local).AddTicks(1905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 23, 42, 24, 999, DateTimeKind.Local).AddTicks(5428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "CCCD",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 301, DateTimeKind.Local).AddTicks(635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 71, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.AddColumn<string>(
                name: "CO_GIA_TRI_DEN",
                table: "CCCD",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HO_VA_TEN",
                table: "CCCD",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 288, DateTimeKind.Local).AddTicks(2314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 60, DateTimeKind.Local).AddTicks(6058));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 295, DateTimeKind.Local).AddTicks(4204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 68, DateTimeKind.Local).AddTicks(9081));

            migrationBuilder.CreateTable(
                name: "THE_SINH_VIEN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TICKET_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HUCEDOCS_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_CREATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 305, DateTimeKind.Local).AddTicks(6908)),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    HO_TEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_SINH = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    MSSV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LOP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    KHOA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HKTT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KHOA_HOC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THE_SINH_VIEN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_THE_SINH_VIEN_OCR_Request_TICKET_ID",
                        column: x => x.TICKET_ID,
                        principalTable: "OCR_Request",
                        principalColumn: "Ticket_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_THE_SINH_VIEN_TICKET_ID",
                table: "THE_SINH_VIEN",
                column: "TICKET_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "THE_SINH_VIEN");

            migrationBuilder.DropColumn(
                name: "CO_GIA_TRI_DEN",
                table: "CCCD");

            migrationBuilder.DropColumn(
                name: "HO_VA_TEN",
                table: "CCCD");

            migrationBuilder.RenameColumn(
                name: "SO",
                table: "CCCD",
                newName: "SO_THE");

            migrationBuilder.RenameColumn(
                name: "NOI_THUONG_TRU",
                table: "CCCD",
                newName: "HO_TEN");

            migrationBuilder.RenameColumn(
                name: "NGUOI_KY",
                table: "CCCD",
                newName: "DIA_CHI_THUONG_TRU");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 45, DateTimeKind.Local).AddTicks(4678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 274, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_VAY_VON",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 64, DateTimeKind.Local).AddTicks(9740),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 292, DateTimeKind.Local).AddTicks(1470));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_XAC_NHAN_TOEIC",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 50, DateTimeKind.Local).AddTicks(5073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 278, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "GIAY_CAM_KET_TRA_NO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 56, DateTimeKind.Local).AddTicks(1832),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 284, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 23, 42, 24, 999, DateTimeKind.Local).AddTicks(5428),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 231, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "CCCD",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 71, DateTimeKind.Local).AddTicks(7734),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 301, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM_TIENG_ANH",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 60, DateTimeKind.Local).AddTicks(6058),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 288, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "BANG_DIEM",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 26, 23, 42, 25, 68, DateTimeKind.Local).AddTicks(9081),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 15, 53, 12, 295, DateTimeKind.Local).AddTicks(4204));
        }
    }
}

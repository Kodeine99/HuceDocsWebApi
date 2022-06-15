using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDTest.Data.Migrations
{
    public partial class AddHFileModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OCR_Request",
                table: "OCR_Request");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "FileLength",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "TotalOfFields",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "TotalOfPages",
                table: "Document");

            migrationBuilder.AlterColumn<string>(
                name: "Ticket_Id",
                table: "OCR_Request",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 15, 19, 17, 47, 57, DateTimeKind.Local).AddTicks(1133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 11, 14, 15, 57, 728, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 15, 19, 17, 47, 34, DateTimeKind.Local).AddTicks(6057),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 11, 14, 15, 57, 711, DateTimeKind.Local).AddTicks(8559));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OCR_Request",
                table: "OCR_Request",
                column: "Ticket_Id");

            migrationBuilder.CreateTable(
                name: "GIAY_XAC_NHAN_TOEIC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TICKET_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HUCEDOCS_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_CREATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 15, 19, 17, 47, 60, DateTimeKind.Local).AddTicks(1264)),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    HO_TEN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_SINH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MSSV = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LOP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGANH_HOC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HE_DAO_TAO = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KHOA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NDXN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DIEM_THI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DOT_THI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NGAY_XAC_NHAN = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIAY_XAC_NHAN_TOEIC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GIAY_XAC_NHAN_TOEIC_OCR_Request_TICKET_ID",
                        column: x => x.TICKET_ID,
                        principalTable: "OCR_Request",
                        principalColumn: "Ticket_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HFile_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GIAY_XAC_NHAN_TOEIC_TICKET_ID",
                table: "GIAY_XAC_NHAN_TOEIC",
                column: "TICKET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HFile_DocumentId",
                table: "HFile",
                column: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GIAY_XAC_NHAN_TOEIC");

            migrationBuilder.DropTable(
                name: "HFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OCR_Request",
                table: "OCR_Request");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "OCR_Request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 11, 14, 15, 57, 728, DateTimeKind.Local).AddTicks(221),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 15, 19, 17, 47, 57, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.AlterColumn<string>(
                name: "Ticket_Id",
                table: "OCR_Request",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Document",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 11, 14, 15, 57, 711, DateTimeKind.Local).AddTicks(8559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 15, 19, 17, 47, 34, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Document",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileLength",
                table: "Document",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Document",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Document",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalOfFields",
                table: "Document",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalOfPages",
                table: "Document",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OCR_Request",
                table: "OCR_Request",
                column: "Id");
        }
    }
}

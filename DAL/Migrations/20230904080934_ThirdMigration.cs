using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankCards_Users_UserId",
                table: "BankCards");

            migrationBuilder.DropIndex(
                name: "IX_BankCards_UserId",
                table: "BankCards");

            migrationBuilder.DropColumn(
                name: "Lifetime",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BankCards");

            migrationBuilder.RenameColumn(
                name: "CreditName",
                table: "Deposits",
                newName: "MinLifetime");

            migrationBuilder.AddColumn<string>(
                name: "DepositName",
                table: "Deposits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Lifetime",
                table: "Credits",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ValidityPeriod",
                table: "BankCards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "BankCards",
                columns: new[] { "Id", "CardIssue", "CardName", "CreatedAt", "Description", "UpdatedAt", "ValidityPeriod" },
                values: new object[,]
                {
                    { 1L, 20000m, "HUMO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O‘zbekiston bo‘ylab barcha turdagi to‘lovlar\r\nBankomatlar orqali kartadan naqd pul yechish\r\nPul mablag‘larini kartadan kartaga o‘tkazish\r\nBank kartasida NFC xizmati mavjud", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5" },
                    { 2L, 50000m, "UzCard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O‘zbekiston bo‘ylab barcha turdagi to‘lovlar\r\nBankomatlar orqali kartadan naqd pul yechish\r\nBank kartasini «Zoomrad» mobil ilovasiga ulash\r\nPul mablag‘larini kartadan kartaga o‘tkazish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5" },
                    { 3L, 30000m, "VISA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dunyo boʻyicha 2.6 milliondan ortiq bankomatlar\r\nNaqd shaklda xorijiy valyutani yechib olish\r\nBank kartasida NFC xizmati mavjud\r\n«Zoomrad» mobil ilovasi orqali mablagʻlarni boshqarish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5" },
                    { 4L, 30000m, "UzCard-UnionPay", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oʻzbekiston hududida hamda xorij mamlakatlarida toʻlovni amalga oshirish\r\nBitta kartada - ikkita toʻlov tizimi\r\nSoʻmdagi pul mablagʻlarini konvertatsiyasiz toʻlovlarni amalga oshirish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5" },
                    { 5L, 30000m, "UzCard-Mir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O‘zbekiston bo‘ylab barcha turdagi to‘lovlar\r\nBankomatlar orqali kartadan naqd pul yechish\r\nBank kartasini «Zoomrad» mobil ilovasiga ulash\r\nPul mablag‘larini kartadan kartaga o‘tkazish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5" }
                });

            migrationBuilder.InsertData(
                table: "Credits",
                columns: new[] { "Id", "CreatedAt", "CreditName", "Description", "Lifetime", "Percentage", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 9, 4, 8, 9, 34, 587, DateTimeKind.Utc).AddTicks(688), "Avtokredit - birlamchi bozor uchun", "Birlamchi bozordan yengil avtotransport vositalarini sotib olish uchun hamda sugʻurta mukofoti toʻlovlarini toʻlash uchun ajratiladi.\r\n", "4 yil", "24%", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avtokredit - BYD HAN, KIA, Chery, Jetour.", "Birlamchi bozordan «BYD HAN», «KIA», «Chery», «Jetour», «Bestune», «Hongqi», «Dongfeng», «Mazda», «Skywell», «Foton» hamda «Shineray» avtotransport vositalarini realizatsiya qiluvchi tashkilotlar («Roodell»MCHJ, «Auto Motors Asia» MCHJ, «King Garment Textile» MCHJ, «Sher-Don-Yda» MCHJ, «MK Direct» MCHJ, «Astana Motors Company» MCHJ ) bilan tuzilgan hamkorlik shartnomasi doirasida ushbu avtotransport vositalarini sotib olish uchun.", "5 yil", "20%", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Universal mikroqarz", "Har qanday maqsad uchun miqroqarz.\r\n", "3 yil", "24%", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "Id", "CreatedAt", "DepositName", "Description", "MinLifetime", "Percentage", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siz Uchun", "Yuqori daromad olish imkoniyatidan foydalaning\r\n\r\nOnlayn ochish mumkin\r\nOmonatni to‘ldirish\r\nQisman chiqim qilish", "24 oy", "23%", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "«COMFORT» PLUS", "Omonatga mablag‘lar naqdsiz shaklda bankning mobil ilova orqali qabul qilinadi. АQSh dollarida, istalgan vaqtda qoʻshimcha mablagʻ bilan to‘ldirishingiz hamda zarurat tugʻilganda undan 100 AQSH dollari qoldiq saqlagan holda qisman chiqim qilishingiz mumkin.\r\n\r\n", "24 oy", "6.5%", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "«Chorak asr» online", "Mablagʻlaringizni oʻzingiz xohlagandek boshqarish imkoniyati mavjud. Ya'ni, sizga qulay vaqtda omonatingizni qoʻshimcha mablagʻ bilan toʻldirishingiz yoki zarurat tugʻilganda omonatingiz foizlarini saqlagan holda undan qisman chiqim qilishingiz mumkin.", "12 oy", "22%", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 8, 9, 34, 587, DateTimeKind.Utc).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 8, 9, 34, 587, DateTimeKind.Utc).AddTicks(567));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 8, 9, 34, 587, DateTimeKind.Utc).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 8, 9, 34, 587, DateTimeKind.Utc).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 8, 9, 34, 587, DateTimeKind.Utc).AddTicks(569));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "DepositName",
                table: "Deposits");

            migrationBuilder.RenameColumn(
                name: "MinLifetime",
                table: "Deposits",
                newName: "CreditName");

            migrationBuilder.AddColumn<DateTime>(
                name: "Lifetime",
                table: "Deposits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Lifetime",
                table: "Credits",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidityPeriod",
                table: "BankCards",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "BankCards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 6, 55, 51, 703, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 6, 55, 51, 703, DateTimeKind.Utc).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 6, 55, 51, 703, DateTimeKind.Utc).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 6, 55, 51, 703, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 6, 55, 51, 703, DateTimeKind.Utc).AddTicks(1367));

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_UserId",
                table: "BankCards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankCards_Users_UserId",
                table: "BankCards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

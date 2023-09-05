using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DAL.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    DbSet<User> Users { get; set; }
    DbSet<Deposit> Deposits { get; set; }
    DbSet<Credit> Credits { get; set; }
    DbSet<Transfer> Transactions { get; set; }
    DbSet<BankCard> BankCards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(new User { FirstName = "Ravshan", LastName = "Isroilov", CreatedAt = DateTime.UtcNow, Email = "isroilovravshan42@gmail.com", Id = 1, Password = "1234", PhoneNumber = "+998902528196" },
                                                  new User { FirstName = "Oybek",   LastName = "Abdurahmonov", CreatedAt = DateTime.UtcNow, Email = "oybabd@gmail.com", Id = 2, Password = "1234", PhoneNumber = "+998998721027" },
                                                  new User { FirstName = "Akbarali", LastName = "Majidov", CreatedAt = DateTime.UtcNow, Email = "Majidov@gmail.com", Id = 3, Password = "1234", PhoneNumber = "+998902528196" },
                                                  new User { FirstName = "Bunyod", LastName = "Toshmatov", CreatedAt = DateTime.UtcNow, Email = "buni@gmail.com", Id = 4, Password = "1234", PhoneNumber = "+998900207228" },
                                                  new User { FirstName = "O'tkirbek", LastName = "Hamidov", CreatedAt = DateTime.UtcNow, Email = "otkir@gmail.com", Id = 5, Password = "1234", PhoneNumber = "+998995629737" });
       
        modelBuilder.Entity<BankCard>().HasData(new BankCard {CardName="HUMO",Description= "O‘zbekiston bo‘ylab barcha turdagi to‘lovlar\r\nBankomatlar orqali kartadan naqd pul yechish\r\nPul mablag‘larini kartadan kartaga o‘tkazish\r\nBank kartasida NFC xizmati mavjud",CardIssue=20000,ValidityPeriod="5",Id=1 },
                                                      new BankCard { CardName = "UzCard", Description = "O‘zbekiston bo‘ylab barcha turdagi to‘lovlar\r\nBankomatlar orqali kartadan naqd pul yechish\r\nBank kartasini «Zoomrad» mobil ilovasiga ulash\r\nPul mablag‘larini kartadan kartaga o‘tkazish", CardIssue = 50000, ValidityPeriod = "5", Id = 2 },
                                                      new BankCard { CardName = "VISA", Description = "Dunyo boʻyicha 2.6 milliondan ortiq bankomatlar\r\nNaqd shaklda xorijiy valyutani yechib olish\r\nBank kartasida NFC xizmati mavjud\r\n«Zoomrad» mobil ilovasi orqali mablagʻlarni boshqarish", CardIssue = 30000, ValidityPeriod = "5", Id = 3 },
                                                      new BankCard { CardName = "UzCard-UnionPay", Description = "Oʻzbekiston hududida hamda xorij mamlakatlarida toʻlovni amalga oshirish\r\nBitta kartada - ikkita toʻlov tizimi\r\nSoʻmdagi pul mablagʻlarini konvertatsiyasiz toʻlovlarni amalga oshirish", CardIssue = 30000, ValidityPeriod = "5", Id = 4 },
                                                      new BankCard { CardName = "UzCard-Mir", Description = "O‘zbekiston bo‘ylab barcha turdagi to‘lovlar\r\nBankomatlar orqali kartadan naqd pul yechish\r\nBank kartasini «Zoomrad» mobil ilovasiga ulash\r\nPul mablag‘larini kartadan kartaga o‘tkazish", CardIssue = 30000, ValidityPeriod = "5", Id = 5 });

        modelBuilder.Entity<Credit>().HasData(new Credit { CreditName = "Avtokredit - birlamchi bozor uchun", Description = "Birlamchi bozordan yengil avtotransport vositalarini sotib olish uchun hamda sugʻurta mukofoti toʻlovlarini toʻlash uchun ajratiladi.\r\n", Lifetime = "4 yil", Percentage = "24%", CreatedAt = DateTime.UtcNow, Id = 1 },
                                                     new Credit
                                                     {
                                                         CreditName = "Avtokredit - BYD HAN, KIA, Chery, Jetour.",
                                                         Description = "Birlamchi bozordan «BYD HAN», «KIA», «Chery», «Jetour», «Bestune», «Hongqi», «Dongfeng», «Mazda», «Skywell», «Foton» " +
                                                     "hamda «Shineray» avtotransport vositalarini realizatsiya qiluvchi tashkilotlar («Roodell»MCHJ, «Auto Motors Asia» MCHJ, «King Garment Textile» MCHJ, «Sher-Don-Yda» MCHJ, «MK Direct» MCHJ, «Astana" +
                                                     " Motors Company» MCHJ ) bilan tuzilgan hamkorlik shartnomasi doirasida ushbu avtotransport vositalarini sotib olish uchun.",
                                                         Lifetime = "5 yil",
                                                         Percentage = "20%",
                                                         Id = 2
                                                     },
                                                     new Credit { CreditName = "Universal mikroqarz", Description = "Har qanday maqsad uchun miqroqarz.\r\n", Lifetime = "3 yil", Percentage = "24%", Id = 3 });

        modelBuilder.Entity<Deposit>().HasData(new Deposit { DepositName = "Siz Uchun", Description = "Yuqori daromad olish imkoniyatidan foydalaning\r\n\r\nOnlayn ochish mumkin\r\nOmonatni to‘ldirish\r\nQisman chiqim qilish", MinLifetime = "24 oy", Percentage = "23%", Id = 1 },
                                                             new Deposit { DepositName = "«COMFORT» PLUS", Description = "Omonatga mablag‘lar naqdsiz shaklda bankning mobil ilova orqali qabul qilinadi. АQSh dollarida, istalgan vaqtda qoʻshimcha mablagʻ bilan to‘ldirishingiz hamda zarurat " +
                                                             "tugʻilganda undan 100 AQSH dollari qoldiq saqlagan holda qisman chiqim qilishingiz mumkin.\r\n\r\n", MinLifetime = "24 oy", Percentage = "6.5%", Id = 2 },
                                                             new Deposit { DepositName = "«Chorak asr» online", Description = "Mablagʻlaringizni oʻzingiz xohlagandek boshqarish imkoniyati mavjud. Ya'ni, sizga qulay vaqtda omonatingizni qoʻshimcha mablagʻ bilan toʻldirishingiz yoki " +
                                                             "zarurat tugʻilganda omonatingiz foizlarini saqlagan holda undan qisman chiqim qilishingiz mumkin.", MinLifetime = "12 oy", Percentage = "22%", Id = 3 });
    }
}

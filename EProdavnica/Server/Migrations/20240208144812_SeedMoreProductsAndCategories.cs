using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EProdavnica.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreProductsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kategorije",
                columns: new[] { "Id", "Ime", "Url" },
                values: new object[] { 4, "Tig zavarivanje", "tig" });

            migrationBuilder.InsertData(
                table: "Proizvodi",
                columns: new[] { "Id", "Cena", "KategorijaId", "Naziv", "Opis", "SlikaUrl" },
                values: new object[,]
                {
                    { 6, 5.99m, 2, "ESAB ARISTO 500ix", "SAB Aristo 500ix je prenosni pulsni višenamenski aparat za zavarivanje dizajniran i proizveden u skladu sa potrebama i željama najzahtevnijih industrijskih korisnika.\r\n\r\nUparen sa Robust Feed U6 ili Robust Feed Puls dodavačima ESAB Aristo 500ix predstavlja, u ovom trenutku, najnapredniju multiprocesnu zavarivačku opremu na svetskom tržištu namenjenu za korišćenje u ekstremnim radnim okruženjima.", "https://www.sualati.com/files/product_picture/659d524600d9f_aristo-500ix-pulse-robust-u6-1650528918-8531.jpg" },
                    { 7, 9.99m, 3, "WTL CUT 100CNC", "Aparat za plazma rezanje maksimalne jačine 100 A Paljenje luka bez kontakta sa materijalom(vazdušno). Intermitenca mu je na 90 A 100% Reže do maksimalne debljine od 55 mm Količina vazduha koja mu je potrebna za pravilan rad je od 30 do 290 litara u   minuti. Brener za rezanje je dužine 6M i opremljen je TECMO PT 100 gorionikom.", "https://www.sualati.com/files/product_picture/2019.07.11.14.16.25_5d272899aaebd_mig315a.jpg" },
                    { 8, 15.99m, 2, "WTL MIG 220 DIGI SYNERGIC", "Vrhunski polusinergetski inverterski aparat za zavarivanje sa automatskim izborom brzine žice na osnovu debljine žice i vrste gasa koji se koristi.\r\nOdlična dinamika zavarivanja, sinergetsko podešavanje parametra.", "https://www.wtl.si/media/catalog/product/cache/1/image/363x/83ec0365e1c5f79d81549ee4449e1b43/m/i/mig220_profile_002__1.jpg" },
                    { 9, 5.99m, 2, "WTL MCU 250 PULS", "Aparat se isporučuje sa gorionikom MB 25 3M, kleštima za masu i elektrodu sa pripadajućim kablovima.\r\n\r\nEkonomični sinergetski dupli pulsni aparat za MIG/MAG zavarivanje, odličnih performansi sa mogućnošću zavarivanja raznorodnih materijala.\r\n\r\nSynergic inverter sa pulsom, duplim pulsom, podešavanjem vremena početnog gasa i završnog gasa, frekvencijom pulsacije, gornjim i donjim strujama, podešavanjem dužine luka i kod gornje i kod donje struje, podešavanjem povećanja jačine i vremena trajanja prilikom starta paljenja luka, popunjavanje kratera prilikom završetka i trajanje popunjavanja kratera i indukcije.\r\n\r\nIzuzetno brzi igbt invertor, uparen sa kvalitetnom elektronikom i modernim softverom, daje izuzetnu dinamiku zavarivanja u svim režimima, omogućavajući odlične rezultate zavarivanja.\r\n\r\nWTL Schweisstechnik MCU MIG-250 je profesionalni aparat maksimalne jačine 230A, namenjen zavarivačima koji žele da poseduju kombinovani aparat sa kojim mogu u MIG/MAG postupku da zavaruju sve vrste materijala od crnih čelika, prohromskih čelika, aluminijuma.\r\n\r\nMogućnost korištenja sa Push-Pull gorionikom.\r\nTakodje omogućava zavarivanje REL i TIG(DC) postupkom.\r\nIdealan za izradu čamaca, lakih aluminijumskih i prohromskih konstrukcija, prikolica, limarske radove, za razne poslove reparaturnog tipa i slične namene.\r\nMonofazno napajanje(230V), vrlo mali gabariti i težina, omogućavaju da aparat bude vrlo prenosiv.\r\n\r\nDupli pogon žice sa četiri uzupčena točkića, koji omogućavaju besprekoran dotur žice, bez obzira na vrstu materijala koji se zavaruje i tipa žice koji se koristi.", "https://www.biljaca.rs/wp-content/uploads/2022/02/116691304_60a7dfcb25a209-62465989strana.jpg" },
                    { 4, 9.99m, 4, "WTL TT 2000 HF + REL", "Multifunkcionalni aparat za zavarivanje TIG DC HF i REL\r\nVeoma lagan i kompaktan IGBT inverterski aparat ali izuzetno robustan. Savršen partner za TIG DC zavarivanje sa izuzetno lakim HF bezkontaktnim paljenjem luka i mogućnošću podešavanja završne struje, vremena završnog gasa i 2T –4T rada.\r\nU REL varijanti poseduje ARC FORCE optimizovano stabilizaciju električnog luka,HOT START olakšava paljenje elektrode i ANTI STICKING smanjuje mogućnost lepljenja elektrode za bazni materijal.\r\nOpremljen sa temperaturnim,naponskim i senzorom za zaštitu od oscilacija u naponu i jačini struje.\r\nDizajniran za rad na diesel generatorima sa sposobnošću da izbegne kvarove koji mogu da se dese zbog naglih skokova napona,testiran na 440 V.\r\nVisoka intermitenca pogodna za radioničke i industrijske namene.\r\nHlađenje unutrašnje elektronike je prinudno pomoću vrlo efikasnog ventilatora.\r\nUrađen prema EN propisima EN 60974-1 usklađen sa CE oznakom", "https://www.wtl.si/media/catalog/product/cache/1/image/363x/83ec0365e1c5f79d81549ee4449e1b43/t/p/tp_2000.jpg" },
                    { 5, 15.99m, 4, "WTL TIG 320 AC/DC", "Aparat za zavarivanje WTL 320 TIG AC\\DC pulsni 320A\r\nTIG/REL(MMA )pulsni aparat pogodan za profesionalnu upotrebu.", "https://www.wtl.si/media/catalog/product/cache/1/image/363x/83ec0365e1c5f79d81549ee4449e1b43/t/i/tig_ac-dc_320.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Kategorije",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

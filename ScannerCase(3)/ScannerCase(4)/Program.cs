using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScannerCase
{
    class Case2
    {
        static async Task Main(string[] args)
        {
            await StartAsync();
            Console.ReadLine();
        }

        private static async Task StartAsync()
        {
            var url = "https://sahibinden.com";
            string url2 = "vitrin-list clearfix";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            int number = 0;// foreach dongusunde kac tane urunum oldugumu manuel sekilde ogrenmek ıcın bu ınteger degerı yarattım
            int total = 0;// ortalama alırken kullanmak ıcın Integer degerımı olusturdum.

            HtmlNodeCollection urunler = htmlDoc.DocumentNode.SelectNodes("//ul[contains(@class, 'vitrin-list clearfix')]");
            // burada html kodunun ıcınde kı bılgıyı vererek cekmek ıstedıgım veriyi belirtim.
            if (urunler != null)
            {
                using (StreamWriter dosya = new StreamWriter(@"c:\DENEME\scannercase.txt"))
                {
                    foreach (HtmlNode urun in urunler)
                    {
                        number++;

                        HtmlNode baslikNode = urun.SelectSingleNode(".//li/a/title");
                        if (baslikNode != null)
                        {
                            string title = baslikNode.InnerText.Trim();
                            Console.WriteLine("Title: " + title);
                            dosya.WriteLine(title);// Urunlerin title kısmını .txt dosyama eklemiş oluyorum
                        }

                        HtmlNode linkNode = urun.SelectSingleNode(".//a[contains(@class, 'classifiedTitle')]");
                        if (linkNode != null)
                        {
                            // fiyat kısmını ana sayfadan erişim yapamadığımdan dolayı linkin içine girerek yeni
                            //acilan sekmede fiyat kısmına erişmek istedim
                            string link = linkNode.GetAttributeValue("href", "");

                            string productHtml = await httpClient.GetStringAsync(link);
                            HtmlDocument productDoc = new HtmlDocument();
                            productDoc.LoadHtml(productHtml);

                            HtmlNode fiyatNode = productDoc.DocumentNode.SelectSingleNode("//h3[contains(@class, 'classifiedInfo')]");
                            if (fiyatNode != null)
                            {
                                string fiyat = fiyatNode.InnerText.Trim();
                                //Ortalama hesabını yaparken Integer değere donusturmek adına bunu uygun gordum.
                                if (int.TryParse(fiyat, out int price))
                                {
                                    total += price;//Int değerlere dönene ortalamaya katıyorum
                                    Console.WriteLine("Fiyat: " + price);
                                    dosya.WriteLine(price);// Urunlerin fiyat kısmını .txt dosyama eklemiş oluyorum.
                                }
                                else
                                {
                                    Console.WriteLine("Fiyatı int değere dönüştüremedim: " + fiyat);
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Avarage of Products Price: " + (total / number));
                Console.ReadLine();
            }
        }

        public void Api()
        {
            List<string> proxyIPList = new List<string>()
            {
                "123.456.789.1",
                "123.456.789.2",
                "123.456.789.3",
                // Birçok API adresi veya bunu rastgele oluşturan bir algoritma yazılabilir.
            };

            Random rand = new Random();
            string randomProxyIP = proxyIPList[rand.Next(proxyIPList.Count)];

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Forwarded-For", randomProxyIP);

            // Banlanmaya karşı süre kısıtlaması koymak için bekleme süresi ekleyebilirsiniz.
            // await Task.Delay(süre); şeklinde kullanabiliriz.
        }
    }
}

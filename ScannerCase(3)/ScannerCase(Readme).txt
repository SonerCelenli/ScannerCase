ReadMe

*Geliştirme Ortamını Hazırlama

	Web scraping için C# programlama dili kullanacağız. Öncelikle, C# ile geliştirme yapmak için bir IDE (Entegre Geliştirme Ortamı) seçmelisiniz. Önerilen IDE'lerden biri Visual Studio'dur. Visual Studio'yu indirerek ve kurarak geliştirme ortamını hazırlayabilirsiniz.

*Gerekli Kütüphaneleri Eklemek
	
	Web scraping işlemleri için bazı kütüphaneleri kullanacağım. Visual Studio'da, projenize gerekli kütüphaneleri eklemek için NuGet Paket Yöneticisi'ni kullanabiliriz. 
	Aşağıdaki kütüphaneleri projenize ekleyin:

	*HtmlAgilityPack: HTML sayfalarını işlemek için kullanılan bir kütüphane.
	*HttpClient: Web sayfalarını indirmek ve web istekleri yapmak için kullanılan bir kütüphane.
	*Systen.IO:Verileri .txt dosyasına yazdırabilmek için.
	
*Web Sayfasını İndirme ve İşleme
	C# ile web sayfalarını indirmek ve işlemek için aşağıdaki adımları izleyebilirsiniz:

(23.satır)var url = "https://sahibinden.com";
            string url2 = "vitrin-list clearfix";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);//await beklerken program devam etsin nedeniyle kullandım.

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(url);


	Yukarıdaki örneği açıklamak gerekirse ; 

	İlk olarak, url değişkenine hedef web sitesinin adresi olan "https://sahibinden.com" adresini atıyorum. Bu, web scraping yapmak istediğimiz web sitesinin doğru URL'sini temsil ediyor.

	url2 değişkenine ise "vitrin-list clearfix" ifadesini atıyorum. Bu ifade, hedef web sitesinde belirli bir HTML etiketini veya sınıfı temsil edebilir. Veri çekmek istediğimiz spesifik bir bölümü veya bileşeni belirtmek için kullanıyorum.

	HttpClient sınıfından bir nesne oluşturarak httpClient değişkenine atıyorum. Bu sınıf, web sayfalarını indirmek ve web istekleri yapmak için kullanılan bir sınıftır.

	await ifadesi, GetStringAsync() yönteminin tamamlanmasını beklemek için kullanılır. Bu sayede, web sayfasının içeriğini indirirken programın diğer işlemlere devam etmesine izin verir. GetStringAsync() yöntemi, belirtilen URL'deki web sayfasının içeriğini bir string olarak indirir ve html değişkenine atar.

	Bu şekilde, doğru URL'yi temsil eden url değişkenini kullanarak web sayfasının içeriğini html değişkenine indiriyorum. Böylece, indirilen içeriği htmlDoc nesnesine yükleyebilir ve web scraping işlemlerine devam edebilirim.


	Yukarıdaki örnekte, HtmlDocument sınıfını kullanarak htmlDoc nesnesini oluşturuyorum. Ardından LoadHtml() yöntemini kullanarak indirilen sayfa içeriğini htmlDoc nesnesine yüklüyorum.

*Verileri Kaydetme
	Öncelikle, verileri kaydetmek için bir metin dosyası oluşturmalıyım. Bunun için StreamWriter sınıfını kullanacağım. 
	StreamWriter sınıfından bir nesne oluşturarak dosya yazma işlemi için bir yol belirleyeceğim. Kod içinde ki örneğimi vericek olursam .

	using (System.IO.StreamWriter dosya = new System.IO.StreamWriter(@"c:\DENEME\DENEME2.txt"))
	
	Burada yapmış olduğum işlem StreamWriter sınıfından 'dosya' adında bir nesne oluşturarak o nesneye verilerimi kaydetmek olucaktır.
	(@c:\..........\........txt) tarafında ise oluşturduğum .txt dosyamın yerini belli ederek bilgisayarın nereye yükleyeceğine dair bilgi vermiş oluyorum. 
	
	Bu verileri kaydederken ise foreach döngüsünün içinde bir koleksiyon veya diziye sahip olarak . Bu verileri 'StreamWriter' nesnesiyle oluşturduğum dosyaya yazıyorum .Bunun için ise her bir veri için
'WriteLine()' yöntemini kullanarak dosyaya veriyi yazdırmış oluyoru. Aşağıda yazdığım projeden bir satır kod paylaşarak örnek vereceğim.
	
 (54.Satır)	dosya.WriteLine(title);// olusturduğum .txt dosyamın içine verilerin başlık bilgisini kaydediyorum.  

	

Soner Çelenlioğlu.




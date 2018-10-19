using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BKBlogMVCApp.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        //Veritabanına Test Verileri Ekleme
        protected override void Seed(BlogContext context)
        {
            
            List<Category> kategoriler = new List<Category>()
            {
                new Category(){KategoriAdi="Futbol"},
                new Category(){KategoriAdi="Teknoloji"},
                new Category(){KategoriAdi="Genel Kültür"},
                new Category(){KategoriAdi="Müzik"},
                new Category(){KategoriAdi="Edebiyat"},
                new Category(){KategoriAdi="Sinema"},
                new Category(){KategoriAdi="Yazılım"}
            };
            foreach (var kategori in kategoriler)
            {
                context.Kategoriler.Add(kategori);
            }
            context.SaveChanges();

            List<Blog> bloglar = new List<Blog>()
            {
                new Blog(){Baslik="Akhisarspor - Galatasaray",Aciklama="Galatasaray, Akhisar'da liderliği bıraktı!",EklenmeTarihi=DateTime.Now.AddDays(0),Anasayfa=true,Onay=true,Icerik=" Spor Toto Süper Lig'de 6. hafta maçında Galatasaray deplasmanda Akhisarspor'a 3-0 mağlup oldu. Akhisar Stadı'nda oynanan maçta ev sahibi Akhisarspor'a galibiyeti getiren golleri 51. dakikada Elvis Manu, 80. dakikada penaltıdan Güray Vural ve 84. dakikada Mustafa Yumlu kaydetti. Galatasaray'da Garry Rodrigues 42. dakikada poenaltı vuruşundan yararlanamadı. Bu sonucun ardından Akhisarspor ligde ilk galibiyetini alarak puanını 5'e yükseltirken, Galatasaray 12 puanda kaldı ve liderlik koltuğunu Medipol Başakşehir'e kaptırdı.",Resim="1.jpg",CategoryId=1},
                new Blog(){Baslik="Microsoft, Office 2019'u Resmi Olarak Duyurdu",Aciklama="Microsoft, Windows 10'un 2018'in Nisan ayında ticari önizlemesini yayınladığı Microsoft Office 2019'u resmi olarak duyurdu.",EklenmeTarihi=DateTime.Now.AddDays(0),Anasayfa=true,Onay=true,Icerik=" Microsoft, Office 2016 sonrasında terk ettiği yıl adlandırmasına bu sene itibarı ile geri dönüyor. Office 365 sonrasında uzunca bir süredir beklenen Office 2019'un resmi duyurusu bugün gerçekleştirildi. Önümüzdeki haftalarda tüm PC ve Mac kullanıcıları için sunulacak olan yeni ofis sürümü, bugünden itibaren ticari lisans sahiplerine dağıtılmaya başlandı.",Resim="2.jpg",CategoryId=2},
                new Blog(){Baslik="Meğerse Sırrı Buymuş!",Aciklama="Uzmanlar İtalyan Ressam Leonardo Da Vinci’nin dünyaca ünlü tablosu ‘Mona Lisa’nın büyüleyici gülüşünün gizemini çözmeyi başardı.",EklenmeTarihi=DateTime.Now.AddDays(0),Anasayfa=true,Onay=true,Icerik=" Sunderland Üniversitesi araştırmacılarından Sheffield Hallam, Da Vinci'nin Mona Lisa'dan önce yaptığı 'La Bella Principessa' isimli tabloyu incelediklerini belirtti. Araştırma kapsamında bir grup gönüllüye 'La Bella Principessa'yı çeşitli uzaklıklardan gösteren ve onları tablonun bulanıklaştırılmış ya da gözleri kapatılmış versiyonları hakkında yorum yapmaya yönlendiren uzmanlar, tüm deneklerin tablonun uzaktan bakıldığında daha mutlu göründüğünü ve figürün yüzündeki tebessümün gözlerden değil sadece dudaklardan kaynaklandığını söylediklerini belirtti.",Resim="3.png",CategoryId=3},
                new Blog(){Baslik="TRT, ABU Tv Şarkı Festivali İçin Güliz Ayla ve Bahadır Tatlıöz’ü Seçti!",Aciklama="TRT, ABU Tv Şarkı Festivali İçin Güliz Ayla ve Bahadır Tatlıöz’ü Seçti!",EklenmeTarihi=DateTime.Now.AddDays(0),Anasayfa=true,Onay=true,Icerik=" ABU TV Şarkı Festivali’nin 7.si 2 Ekim’de Türkmenistan’ın başkenti Aşkabat’ta gerçekleştirilecek.TRT, ülkemizi temsil etmesi için Güliz Ayla ve Bahadır Tatlıöz’ü seçti. 2 ünlü şarkıcı bayrağımızı 3.kez katıldığımız festivalde dalgalandıracak. Bu sene festivale 14 ülke katılım sağlayacak.Türkiye’yi daha önce 2014’te maNga, (performansı izleyin) ve ev sahibi olduğumuz 2015’te Murat Dalkılıç temsil etmişti. (performansı izleyin) o seneki yarışmayı buradan izleyebilirsiniz.Türkiye 2016 ve 2017’de yarışmaya katılmamıştı.Adı üstünde bu bir festival, yarışma değil dolayısıyla temsilciler şarkılarını seslendiriyor ancak oylama yapılmıyor.",Resim="4.jpg",CategoryId=4},
                new Blog(){Baslik="Çankaya Kitap Buluşması 29 Eylül’de başlıyor",Aciklama="Çankaya Kitap Buluşması’nın ilki Çankaya Belediyesi ve Toplumsal Araştırmalar ve Sanat İçin Vakıf (TAKSAV) işbirliğiyle 29 Eylül-5 Ekim tarihleri arasında Çağdaş Sanatlar Merkezi’nde gerçekleşiyor.",EklenmeTarihi=DateTime.Now.AddDays(0),Anasayfa=true,Onay=true,Icerik=" Çankaya Kitap Buluşması’nın ilki Çankaya Belediyesi ve Toplumsal Araştırmalar ve Sanat İçin Vakıf (TAKSAV) işbirliğiyle 29 Eylül-5 Ekim tarihleri arasında Çağdaş Sanatlar Merkezi’nde gerçekleşiyor. 1. Çankaya Kitap Buluşması 35 yayınevi ve binlerce kitaba ev sahipliği yapacak.Çankaya Belediyesi tarafından ilk kez düzenlenecek kitap fuarının okur profili yüksek bir kent olan Ankara için önemine dikkat çeken Çankaya Belediye Başkanı Alper Taşdelen, “Ankara’nın adına yakışan bir kitap fuarı yok. Bu önemli eksikliği gidermek adına bir ilke imza atarak TAKSAV işbirliği ile bu fuarı gerçekleştireceğiz” dedi.Çağdaş Sanatlar Merkezi’nin 20’nci yılını bir ilkle taçlandırmak istediklerini dile getiren Taşdelen fuara tüm Ankaralıları  ve kitap severleri davet etti. Taşdelen fuara ünlü yazarların katılacağı müjdesini de verdi. Fuarda Can, Metis, İletişim, Ayrıntı, İş Bankası, Gergedan Yayınları gibi birçok yayınevi stantlarıyla yer alacak.",Resim="5.jpg",CategoryId=5},
                new Blog(){Baslik="Fenerbahçe - Beşiktaş",Aciklama="Kadıköy'de ne üzüldüler ne sevindiler! Fenerbahçe - Beşiktaş derbisi 1-1 sona erdi",EklenmeTarihi=DateTime.Now.AddDays(0),Anasayfa=true,Onay=true,Icerik=" Spor Toto Süper Lig'de 6. haftanın kapanış maçında Fenerbahçe ile Beşiktaş derbisi 1-1 sona erdi. Ülker Stadı'nda yüksek tempoda oynanan karşılaşmada ilk ciddi pozisyon 35. dakikada yaşandı. Hasan Ali Kaldırım'ın ceza sahası dışından çektiği şut, üst direkten oyun alanına döndü. Mücadelenin 40. dakikasında ise Ryan Babel ceza alanı dışından yaptığı düzgün vuruşta topu ağlara gönderdi. İlk yarı bu skorla tamamlanırken Fenerbahçe de ikinci yarı 71. dakikada skoru dengeledi. Andre Ayew'in kafa vuruşunda meşin yuvarlak ağlarla buluştu. Mücadele 1-1 sona erdi ve taraflar sahadan 1'er puanla ayrıldı. Öte yandan Canewr Erkin maçın bitiş düdüğünün ardından Fırat Aydınus'a yaptığı itirazlar neticesinde ikinci sarı karttan kırmızı kart gördü.Bu sonuçla Fenerbahçe puanını 7'ye Beşiktaş ise 11'e yükseltti.",Resim="6.jpg",CategoryId=1}
            };
            foreach (var blog in bloglar)
            {
                context.Bloglar.Add(blog);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
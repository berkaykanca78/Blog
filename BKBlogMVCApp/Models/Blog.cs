using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BKBlogMVCApp.Models
{
    public class Blog
    {
        //Items
        public int Id { get; set; }
        [DisplayName("Başlık")]
        public string Baslik { get; set; }
        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }
        [DisplayName("Resim")]
        public string Resim { get; set; }
        [DisplayName("İçerik")]
        public string Icerik { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; }
        [DisplayName("Onay")]
        public bool Onay { get; set; }
        [DisplayName("Ana Sayfa")]
        public bool Anasayfa { get; set; }

        //Foreign Key
        [DisplayName("Kategori Adı")]
        public int CategoryId { get; set; }

        //Dolaşım İçin
        public Category Category { get; set; }

    }
}
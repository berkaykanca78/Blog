using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BKBlogMVCApp.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        public string KategoriAdi { get; set; }
        [DisplayName("Blog Sayısı")]
        public int BlogSayisi { get; set; }
    }
}
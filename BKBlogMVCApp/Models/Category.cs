using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BKBlogMVCApp.Models
{
    public class Category
    {
        //Items
        [Key]
        public int CategoryId { get; set; }
        [DisplayName("Kategori Adı")]
        public string KategoriAdi { get; set; }

        //Dolaşmak İçin
        public List<Blog> Bloglar { get; set; }
    }
}
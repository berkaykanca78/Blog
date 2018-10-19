using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BKBlogMVCApp.Models
{
    public class BlogContext:DbContext
    {
        //BlogInitializer Tanıtma
        public BlogContext():base("blogDb")
        {
            Database.SetInitializer(new BlogInitializer());
        }
        //Tabloları Ekledik,DbSet Listelere Benzer. 
        public DbSet<Blog> Bloglar { get; set; }
        public DbSet<Category> Kategoriler { get; set; }
    }
}
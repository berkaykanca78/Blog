using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BKBlogMVCApp.Models;
using PagedList;
using PagedList.Mvc;

namespace BKBlogMVCApp.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult List(int? id, string q, int? PagedNo)
        {
            int pageIndex = PagedNo ?? 1;
            var bloglar = db.Bloglar
                    .Where(i => i.Onay == true)
                    .OrderByDescending(i => i.Id)
                    .Select(i => new BlogModel()
                    {
                        Id = i.Id,
                        Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                        Aciklama = i.Aciklama,
                        EklenmeTarihi = i.EklenmeTarihi,
                        Anasayfa = i.Anasayfa,
                        Onay = i.Onay,
                        Resim = i.Resim,
                        CategoryId = i.CategoryId
                    }).AsQueryable();
            if (string.IsNullOrEmpty(q) == false)
            {
                bloglar = bloglar.Where(i => i.Baslik.Contains(q) || i.Aciklama.Contains(q));
            }

            if (id != null)
            {
                bloglar = bloglar.Where(i => i.CategoryId == id);
            }
            var liste = bloglar.ToPagedList(pageIndex, 5);
            return View(liste);
        }

        // GET: Blog
        public ActionResult Index()
        {
            var bloglar = db.Bloglar.Include(b => b.Category).OrderByDescending(i => i.EklenmeTarihi);
            return View(bloglar.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id, string q)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "CategoryId", "KategoriAdi");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Baslik,Aciklama,Resim,Icerik,CategoryId")] Blog blog, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var extension = Path.GetExtension(file.FileName);

                    if (extension == ".jpg" || extension == ".png")
                    {
                        var folder = Server.MapPath("~/img");
                        //var randomfilename = (db.Bloglar.Count() + 1).ToString();
                        var randomfilename = Path.GetRandomFileName();
                        var filename = Path.ChangeExtension(randomfilename, ".jpg");

                        blog.Resim = filename;

                        var path = Path.Combine(folder, filename);

                        file.SaveAs(path);
                    }
                }
                blog.EklenmeTarihi = DateTime.Now;
                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "CategoryId", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "CategoryId", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Aciklama,Resim,Icerik,Onay,Anasayfa,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Bloglar.Find(blog.Id);
                if (entity != null)
                {
                    entity.Baslik = blog.Baslik;
                    entity.Aciklama = blog.Aciklama;
                    entity.Resim = blog.Resim;
                    entity.Icerik = blog.Icerik;
                    entity.Onay = blog.Onay;
                    entity.Anasayfa = blog.Anasayfa;
                    entity.CategoryId = blog.CategoryId;
                    entity.EklenmeTarihi = DateTime.Now;
                    db.SaveChanges();
                    TempData["Blog"] = entity;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "CategoryId", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            var resimAd = blog.Resim;
            db.Bloglar.Remove(blog);
            var durum = db.SaveChanges();
            if (durum == 1)
            {
                if (System.IO.File.Exists(Server.MapPath("~/img/" + resimAd)))
                    System.IO.File.Delete(Server.MapPath("~/img/" + resimAd));
                Response.Write("<script>alert('Silme işlemi başarıyla gerçekleşti!')</script>");
            }
            else Response.Write("<script>alert('Bir hatayla Karşılaşıldı!')</script>");
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

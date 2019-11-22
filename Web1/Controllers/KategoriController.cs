using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web1.Data;
using Web1.Models;

namespace Web1.Controllers
{
    public class KategoriController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var db = new MyContext();
                var model = db.Kategoriler.ToList();
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Kategori model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var db = new MyContext();
                db.Kategoriler.Add(new Kategori()
                {
                    KategoriAdi = model.KategoriAdi,
                    Renk = model.Renk
                });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Bir Hata Oluştu: " + ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Duzenle(int id = 0)
        {
            try
            {
                var db = new MyContext();
                var model = db.Kategoriler.Find(id);
                if (model == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult Duzenle(Kategori model)
        {
            try
            {
                var db = new MyContext();
                var data = db.Kategoriler.Find(model.Id);
                if (data == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                data.KategoriAdi = model.KategoriAdi;
                data.Renk = model.Renk;

                db.SaveChanges();
                TempData["mesaj"] = "Güncelleme İşlemi Başarılı";
                return View(data);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Sil(int id = 0)
        {
            try
            {
                var db = new MyContext();
                var data = db.Kategoriler.Find(id);
                if (data == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(data);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult Sil(Kategori model)
        {
            try
            {
                var db = new MyContext();
                var data = db.Kategoriler.Find(model.Id);
                if (data == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                db.Kategoriler.Remove(data);
                db.SaveChanges();
                TempData["mesaj"] = $"{data.KategoriAdi} isimli kategori başarıyla silinmiştir.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Detay(int id = 0)
        {
            try
            {
                var db = new MyContext();
                var data = db.Kategoriler.Find(id);
                if (data == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(data);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
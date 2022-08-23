using ASS3_PRN_Bl5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASS3_PRN_Bl5.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Show()
        {
            List<TblMatHang> data = new List<TblMatHang>();
            List<TblMatHang> list = new List<TblMatHang>();
            TblMatHang thisProduct = new TblMatHang();
            using (var context = new MyOrderContext())
            {
                list = context.TblMatHangs.ToList();
                data = context.TblMatHangs.ToList();
            }
            ViewBag.thisPro = thisProduct;
            ViewBag.data = data;
            return View(list);
        }

        [HttpPost]
        public IActionResult Show(string code, string name, string unit, float from, float to, string img, string update, string filterName, string filterPrice, string filterImg)
        {
            List<TblMatHang> list = new List<TblMatHang>();
            List<TblMatHang> data = new List<TblMatHang>();
            TblMatHang thisProduct = new TblMatHang();
            using (var context = new MyOrderContext())
            {
                list = context.TblMatHangs.ToList();
                if (code != "0")
                {
                    data = context.TblMatHangs.Where(x => x.MaHang == code).ToList();
                    thisProduct = context.TblMatHangs.FirstOrDefault(x => x.MaHang == code);
                    if (!string.IsNullOrEmpty(update))
                    {
                        TblMatHang newPro = context.TblMatHangs.FirstOrDefault(x => x.MaHang == code);
                        newPro.Tenhang = name;
                        newPro.Dvt = unit;
                        newPro.Gia = from;
                        newPro.Image = img;
                        context.TblMatHangs.Update(newPro);
                        context.SaveChanges();
                    }
                }
                else
                {
                    data = context.TblMatHangs.ToList();
                   
                }
                if (!string.IsNullOrEmpty(filterName))
                {
                    data = context.TblMatHangs.Where(x => x.Tenhang.Contains(name)).ToList();
                }
                if(!string.IsNullOrEmpty(filterPrice))
                {
                    data = context.TblMatHangs.Where(x => x.Gia >= from && x.Gia <= to).ToList();
                }
                if (!string.IsNullOrEmpty(filterImg))
                {
                    data = context.TblMatHangs.Where(x => x.Image.Contains(img)).ToList();
                }
            }
            ViewBag.thisPro = thisProduct;
            ViewBag.data = data;
            ViewBag.code = code;
            return View(list);
        }
    }
}

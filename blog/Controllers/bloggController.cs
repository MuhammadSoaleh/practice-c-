using blogs.data;
using blogs.Models;
using Microsoft.AspNetCore.Mvc;

namespace blogs.Controllers
{
    public class bloggController : Controller
    {
        private readonly ApplicationDBContext applicationDBContext;

        public bloggController(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public IActionResult Addblog()
        {
            return View();
        }
    
        public IActionResult fetch()
        {
            return View(applicationDBContext.bloggs.ToList());
        }
        public IActionResult delete(int id)
        {
            blogg blog1 = applicationDBContext.bloggs.Find(id);
            applicationDBContext.bloggs.Remove(blog1);
            applicationDBContext.SaveChanges();
            return RedirectToAction("fetch");
        }
        public IActionResult edit(int id)
        {

            return View(applicationDBContext.bloggs.Find(id));
        }

        public IActionResult Fetchblog(int id)
        {

            return View(applicationDBContext.bloggs.Find(id));
        }
        [HttpPost]
        public IActionResult edit(blogg blog,int id)
        {
            
            applicationDBContext.bloggs.Update(blog);
            applicationDBContext.SaveChanges();
            return RedirectToAction("fetch");
        }
        [HttpPost]
        public IActionResult Addblog(blogg blg, IFormFile img)
        {
            if (img != null && img.Length>0) {
            var ff= Path.GetFileName(img.FileName);
                Random rn= new Random();
                var ii = rn.Next(1, 1000);
                var fn= ff+ii;
                var fol= Path.Combine(HttpContext.Request.PathBase.Value ,"wwwroot/uploads");
                if (!Directory.Exists(fol))
                {
                    Directory.CreateDirectory(fol);
                }
                string fp=Path.Combine(fol,fn);
                using (var a = new FileStream(fp, FileMode.Create))
                {
                    img.CopyTo(a);
                }
                var db = Path.Combine("uploads",fn);
                blg.image=db;
                applicationDBContext.bloggs.Add(blg);
                applicationDBContext.SaveChanges();
                    }
            return View();
        }
    }
}

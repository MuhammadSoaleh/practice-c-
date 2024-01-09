using blogs.data;
using blogs.Models;
using Microsoft.AspNetCore.Mvc;

namespace blogs.Controllers
{
    public class TagController : Controller
    {
        private readonly ApplicationDBContext applicationDBContext;

        public TagController(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public IActionResult AddTag()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTag(Tag tag)
        {
            var tag1 = new Tag
            {
                name = tag.name 
            }; 
            applicationDBContext.Tags.Add(tag1);
            applicationDBContext.SaveChanges();
            return View();
        }
        public IActionResult fetch()
        {
            return View(applicationDBContext.Tags.ToList());
        }
        public IActionResult delete(int id)
        {
            Tag tag = applicationDBContext.Tags.Find(id);
            applicationDBContext.Tags.Remove(tag);
            applicationDBContext.SaveChanges();
            return RedirectToAction("fetch");
        }

        public IActionResult edit(int id)
        {

            return View(applicationDBContext.Tags.Find(id));
        }
        [HttpPost]
        public IActionResult edit(Tag tag)
        {
            
            applicationDBContext.Tags.Update(tag);
            applicationDBContext.SaveChanges();
            return RedirectToAction("fetch");
        }
    }
}

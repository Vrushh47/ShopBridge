using BLL;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
namespace ShopBridge.Controllers
{
    public class HomeController : Controller
    {
        DAL.DBOperations.ItemRespository res = null;
        public HomeController()
        {
            res = new DAL.DBOperations.ItemRespository();
        }
        // GET: Home
        public ActionResult AllItemDisplay()
        {
            List<ItemModel> models = res.GetAllItems();
            return View(models);
        }
        
        [HttpPost]
        public ActionResult Add(ItemModel model)
        {
            int ID = 0;
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    // Use your file here
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        model.File.InputStream.CopyTo(memoryStream);
                        model.Photo = memoryStream.ToArray();
                    }
                }
                ID = res.AddItem(model);
                ViewBag.Id = ID;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(ItemModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    // Use your file here
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        model.File.InputStream.CopyTo(memoryStream);
                        model.Photo = memoryStream.ToArray();
                    }
                }
               int ID = res.UpdateItem(model);
               ViewBag.Id = ID;
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            res.DeleteItem(id);
            List<ItemModel> models = res.GetAllItems();
            return View("AllItemDisplay",models);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            ItemModel model = res.GetItem(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ItemModel model = res.GetItem(id);
            return View(model);
        }
    }
}
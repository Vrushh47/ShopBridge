using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
namespace DAL.DBOperations
{
    public class ItemRespository
    {

        public int AddItem(ItemModel model)
        {
            using (var context = new ShopBridgeDBEntities())
            {
                ItemMaster item = new ItemMaster()
                {
                    Id = model.Id,
                    Name=model.Name,
                    Description=model.Description,
                    Price=model.Price,
                    Photo=model.Photo

                };
                context.ItemMasters.Add(item);
                context.SaveChanges();
                return item.Id;
            }

        }
        public int UpdateItem(ItemModel model)
        {
            using (var context = new ShopBridgeDBEntities())
            {
                ItemMaster item = context.ItemMasters.Where(x => x.Id == model.Id).FirstOrDefault();

                item.Id = model.Id;
                item.Name = model.Name;
                item.Description = model.Description;
                item.Price = model.Price;
                item.Photo = model.Photo;

                context.SaveChanges();
                return item.Id;
            }

        }
        public List<ItemModel> GetAllItems()
        {
            List<ItemModel> models = new List<ItemModel>();

            using (var context = new ShopBridgeDBEntities())
            {
                 models = context.ItemMasters.Select(x=>new ItemModel()
                 {
                     Id=x.Id,
                     Name=x.Name,
                     Description=x.Description,
                     Photo=x.Photo,
                     Price=x.Price
                 }
                     ).ToList();
                
            }

            return models;
        }
        public ItemModel GetItem(int id)
        {
            ItemModel model = new ItemModel();

            using (var context = new ShopBridgeDBEntities())
            {
                model = context.ItemMasters.Where(x=>x.Id==id).Select(x => new ItemModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Photo = x.Photo,
                    Price = x.Price
                }
                    ).FirstOrDefault();

            }

            return model;
        }
        public int DeleteItem(int id)
        {
            using (var context = new ShopBridgeDBEntities())
            {
                ItemMaster item = context.ItemMasters.Where(x => x.Id == id).FirstOrDefault();
                if (item != null)
                {
                    context.ItemMasters.Remove(item);
                    context.SaveChanges();
                    return item.Id;
                }
                return 0;
            }

        }
    }
}

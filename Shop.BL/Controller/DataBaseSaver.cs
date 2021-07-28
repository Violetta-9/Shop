using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BL.Model;

namespace Shop.BL.Controller
{
     public class DataBaseSaver
     {
         public List<T> Load<T>() where T:class
         {
            using (var db = new ShopContext())
            {
                var result = db.Set<T>().ToList();
                return result;
            }
         }

        public void Save<T>(T item) where T:class
        {
            using (var db=new ShopContext())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }
        public void SaveProduct<T>(List<T> item) where T : class
        {
            using (var db = new ShopContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BL.Model;

namespace Shop.BL.Controller
{
    public class OrderController:DataBaseSaver
    {
        public  readonly int IdUser;
        public List<Food> Foods;
        public Order Orders;
        public OrderController(int iduser)
        {
            if (iduser == null)
            {
                throw new ArgumentNullException("user cannot be empty.", nameof(iduser));
            }

            IdUser = iduser;
            Foods=GetAllFood();
            Orders = new Order(IdUser); //Orders= GetAllOrder();

        }

        private Order GetAllOrder()
        {
            return Load<Order>().FirstOrDefault() ?? new Order(IdUser);
        }

        private List<Food> GetAllFood()
        {
            return Load<Food>() ?? new List<Food>();
        }

        public void Add(Food food, double quantity)
        {
            var result = Foods.FirstOrDefault(f => f.Name.ToLower() == food.Name.ToLower());
            if (result != null)
            {
                Orders.Add(result, quantity);
                Save();
            }
        }

        public void Save()
        {
            Console.WriteLine(IdUser);
            var result = Foods.FirstOrDefault(t => t.Name.ToLower() == "Banana".ToLower());
            Console.WriteLine(result.Id);
            Save<Order>(Orders);
            Console.WriteLine(IdUser);
            Console.WriteLine(result.Id);
        }
    }
}

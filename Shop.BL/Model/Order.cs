using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BL.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? Moment { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public int  FoodToOrder { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
        public int User { get; set; }
        public Order(int user)
        {
            User = user; 
            Moment = DateTime.Now;
            Foods = new List<Food>();

        }
        public Order()
        {

        }

        public void Add(Food food,double quantity)
        {
            var result = Foods.FirstOrDefault(f => f.Name.ToLower() == food.Name.ToLower());
            if (result == null)
            {
                FoodToOrder = food.Id;
                Quantity = quantity;
                Price += food.Price;

            }
            else
            {

            }
        }
    }
}

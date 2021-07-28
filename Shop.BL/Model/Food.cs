using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BL.Model
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Calories { get; set; }
        public double Price { get; set; }
      
        
        public Food() { }
        public Food(string foodName) : this(foodName, 0, 0, 0, 0, 0) { }


        public Food(string name, double proteins, double fats, double carbohydrates, double calories, double price)
        {
            #region Сheck
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("FoodName cannot be empty", nameof(name));
            }

            if (proteins < 0)
            {
                throw new Exception("Proteins cannot be less 0");
;           }
            if (fats < 0)
            {
                throw new Exception("Fats cannot be less 0");
                
            }
            if (Carbohydrates < 0)
            {
                throw new Exception("Carbohydrates cannot be less 0");
                
            }
            if (Calories < 0)
            {
                throw new Exception("Calories cannot be less 0");
                
            }
            if (Price < 0)
            {
                throw new Exception("Price cannot be less 0");

            }
#endregion

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

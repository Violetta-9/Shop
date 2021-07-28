using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BL.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get { return DateTime.Now.Year - BirdthDate.Year; } }
        public DateTime BirdthDate { get; set; }
        public string Number { get; set; }
        public string Addres { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public User()
        {
        }

        public User(string name,
                    string gender,
                    DateTime birdthdate,
                    string number,
                    string addres)
        {
            #region CheckingСonditions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentException("Gender cannot be null.", nameof(gender));
            }

            if (birdthdate < DateTime.Parse("01.01.1900") || birdthdate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth.", nameof(birdthdate));
            }

            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException("Number cannot be null or empty.", nameof(number));
            }

            if (string.IsNullOrWhiteSpace(addres))
            {
                throw new ArgumentNullException("Addres cannot be null or empty.", nameof(addres));
            }

            Name = name;

            #endregion

            Name = name;
            Gender = gender;
            BirdthDate = birdthdate;
            Number = number;
            Addres = addres;

        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}


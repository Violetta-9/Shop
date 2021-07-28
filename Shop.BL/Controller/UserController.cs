using System;
using System.Collections.Generic;
using System.Linq;
using Shop.BL.Model;


namespace Shop.BL.Controller
{
    public class UserController:DataBaseSaver
    {
        public List<User> Users { get; set; }
        public User CurrentUser { get; set; }
        public bool IsNewUser = false;
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Name cannot be empty",nameof(userName));
            }

            Users = GetAllUser();
            CurrentUser =  Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        public void SetNewUserData(string gender, DateTime birthDate, string number, string addres)
        {
            CurrentUser.Gender = gender;
            CurrentUser.BirdthDate = birthDate;
            CurrentUser.Number = number;
            CurrentUser.Addres = addres;
            Save();

        }

        public List<User> GetAllUser()
        {
           return Load<User>() ?? new List<User>();
        }

        public void Save()
        {
            Save(CurrentUser);
        }
        public void FoodMenuAdd(List<Food> foods)
        {
            SaveProduct(foods);
        }
    }
}

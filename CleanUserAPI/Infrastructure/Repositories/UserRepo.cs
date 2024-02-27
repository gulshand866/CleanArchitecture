using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepo : IUserRepo
    {
        public List<User> Users { get; set; }

        public UserRepo()
        {
            Users = new List<User>()
            {
                new User()
                {
                    Id = new Guid("9038c913-d5ad-4a03-83f1-0e9f865e2f87"),
                    Email = "admin@test.com",
                    Password = "admin123",
                    Role = "admin"
                },
                new User()
                {
                    Id = new Guid("924e1459-8161-4dd4-9742-3ae5d0f8b4ee"),
                    Email = "user@test.com",
                    Password = "user123",
                    Role = "user"
                }
            };
        }

        public User Login(Login user)
        {
            var userAvaliable = Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (userAvaliable == null)
            {
                throw new Exception("User Not Found !");
            }
            return userAvaliable;
        }
    }
}

using System;
using System.Collections.Generic;
using TestMVC.Entity;

namespace TestMVC.DAL
{
    public class UserInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var Users = new List<User>
            {
            new User("First Name 1","Last Name 1", "email1@gmail.com", DateTime.Parse("2017-01-01")),
            new User("First Name 2","Last Name 2","email2@gmail.com", DateTime.Parse("2017-01-01"))
            };

            Users.ForEach(user => context.Users.Add(user));
            context.SaveChanges();
        }
    }
}
using App.Entity;
using System;
using System.Collections.Generic;

namespace App.Context
{
    class UserInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var Users = new List<UserEntity>
            {
            new UserEntity("First Name 1","Last Name 1", "email1@gmail.com", DateTime.Parse("2017-01-01")),
            new UserEntity("First Name 2","Last Name 2","email2@gmail.com", DateTime.Parse("2017-01-01"))
            };

            Users.ForEach(user => context.Users.Add(user));
            context.SaveChanges();
        }
    }
}

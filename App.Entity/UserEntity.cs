using System;

namespace App.Entity
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public UserEntity() { }

        public UserEntity(string firstnName, string lastName, string email, DateTime dateOfBirth)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = firstnName;
            this.LastName = lastName;
            this.Email = email;
            this.DateOfBirth = dateOfBirth;
        }
    }
}

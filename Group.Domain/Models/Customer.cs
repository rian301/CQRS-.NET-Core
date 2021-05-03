using Adm.Domain.Models.Base;
using System;

namespace Adm.Domain.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public Customer()
        {

        }

        public Customer(string name, string email, DateTime createdAt)
        {
            Name = name;
            Email = email;
            CreatedAt = createdAt;
        }
    }
}

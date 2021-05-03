using Adm.Aplication.Common.AutoMapper;
using AutoMapper;
using Adm.Domain.Models;
using System;

namespace Adm.Aplication.Commands.Customers.ViewModels
{
    public class CustomerViewModel : IMap<Customer>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerViewModel, Customer>().ReverseMap();
        }
    }
}

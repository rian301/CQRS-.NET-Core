using Adm.Aplication.Commands.Customers.ViewModels;
using MediatR;

namespace Adm.Aplication.Commands.Customers.Create
{
    public class CreateCustomerCommand : IRequest<CustomerViewModel>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

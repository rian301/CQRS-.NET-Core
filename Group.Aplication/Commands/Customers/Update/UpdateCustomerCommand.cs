using Adm.Aplication.Commands.Customers.ViewModels;
using MediatR;

namespace Adm.Aplication.Commands.Customers.Update
{
   public class UpdateCustomerCommand : IRequest<CustomerViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

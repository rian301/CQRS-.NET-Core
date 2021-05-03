using Adm.Aplication.Commands.Customers.ViewModels;
using MediatR;

namespace Adm.Aplication.Requests.Custommers.GetById
{
    public class GetByIdCustomer : IRequest<CustomerViewModel>
    {
        public int Id { get; set; }
    }
}

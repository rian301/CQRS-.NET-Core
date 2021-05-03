using Adm.Aplication.Commands.Customers.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Adm.Aplication.Requests.Custommers.GetAll
{
    public class GetAllCustomer : IRequest<IEnumerable<CustomerViewModel>>
    {
    }
}

using MediatR;

namespace Adm.Aplication.Commands.Customers.Delete
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}

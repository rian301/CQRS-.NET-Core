using Adm.Infra.Context;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Adm.Aplication.Commands.Customers.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        #region Injections
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        #endregion

        #region Controller
        public DeleteCustomerCommandHandler(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        #endregion

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _dataContext.Customer.FindAsync(request.Id);

            _dataContext.Remove(result);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

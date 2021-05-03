using Adm.Aplication.Commands.Customers.ViewModels;
using Adm.Infra.Context;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Adm.Aplication.Commands.Customers.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerViewModel>
    {
        #region Injections
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        #endregion

        #region Constructors
        public UpdateCustomerCommandHandler(IMapper map, DataContext dataContext)
        {
            _mapper = map;
            _dataContext = dataContext;
        }
        #endregion

        public async Task<CustomerViewModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _dataContext.Customer.FindAsync(request.Id);

            result.Name = request.Name;

            _dataContext.Update(result);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CustomerViewModel>(result);
        }
    }
}

using Adm.Aplication.Commands.Customers.ViewModels;
using Adm.Infra.Context;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Adm.Aplication.Requests.Custommers.GetById
{
    public class GetByIdCustomerHandler : IRequestHandler<GetByIdCustomer, CustomerViewModel>
    {
        #region Injections
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        #endregion

        #region Controller
        public GetByIdCustomerHandler(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        #endregion

        public async Task<CustomerViewModel> Handle(GetByIdCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _dataContext.Customer.FindAsync(request.Id);

            return _mapper.Map<CustomerViewModel>(customer);
        }
    }
}

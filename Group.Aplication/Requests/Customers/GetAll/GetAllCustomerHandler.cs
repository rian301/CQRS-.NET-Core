using Adm.Aplication.Commands.Customers.ViewModels;
using Adm.Infra.Context;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adm.Aplication.Requests.Custommers.GetAll
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomer, IEnumerable<CustomerViewModel>>
    {
        #region Injections
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        #endregion

        #region Controller
        public GetAllCustomerHandler(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        #endregion
        public async Task<IEnumerable<CustomerViewModel>> Handle(GetAllCustomer request, CancellationToken cancellationToken)
        {
            var customers = await _dataContext.Customer.AsNoTracking().ToListAsync();

            return _mapper.Map<IEnumerable<CustomerViewModel>>(customers);
        }
    }
}

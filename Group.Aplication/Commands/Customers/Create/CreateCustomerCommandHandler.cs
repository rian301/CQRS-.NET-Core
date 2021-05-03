using Adm.Aplication.Commands.Customers.ViewModels;
using Adm.Domain.Models;
using Adm.Infra.Context;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Adm.Aplication.Commands.Customers.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerViewModel>
    {
        #region Injections
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        #endregion

        #region Constructor
        public CreateCustomerCommandHandler(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        #endregion

        public async Task<CustomerViewModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                CreatedAt = DateTime.Now
            };

            await _dataContext.Customer.AddAsync(customer);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CustomerViewModel>(customer);
        }
    }
}

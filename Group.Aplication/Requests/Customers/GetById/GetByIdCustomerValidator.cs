using Adm.Infra.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Adm.Aplication.Requests.Custommers.GetById
{
    public class GetByIdCustomerValidator : AbstractValidator<GetByIdCustomer>
    {
        protected readonly DataContext _dataContext;
        public GetByIdCustomerValidator(DataContext dataContext)
        {
            _dataContext = dataContext;

            RuleFor(x => x.Id)
                .MustAsync(CustomerNotFound)
                .WithMessage("Nenhum cliente encontrado.");
        }

        public async Task<bool> CustomerNotFound(int id, CancellationToken cancellationToken)
        {
            var result = await _dataContext.Customer.FindAsync(id);
            if (result != null)
                return true;

            return false;
        }
    }
}

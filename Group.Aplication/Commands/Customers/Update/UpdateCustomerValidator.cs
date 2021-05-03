using Adm.Infra.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Adm.Aplication.Commands.Customers.Update
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        protected readonly DataContext _dataContext;
        public UpdateCustomerValidator(DataContext dataContext)
        {
            _dataContext = dataContext;

            RuleFor(x => x.Name).NotNull()
                .NotEmpty()
                .WithMessage("Nome é requerido.");

            RuleFor(x => x.Name)
                .MustAsync(ValidateName)
                .WithMessage("O nome já esta em uso, tente outro.");
        }

        public async Task<bool> ValidateName(string name, CancellationToken cancellationToken)
        {
            return await _dataContext.Customer
                .AllAsync(x => x.Name != name.Trim());
        }
    }
}

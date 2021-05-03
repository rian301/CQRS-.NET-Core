using Adm.Api.Controllers.Base;
using Adm.Aplication.Commands.Customers.Create;
using Adm.Aplication.Commands.Customers.Delete;
using Adm.Aplication.Commands.Customers.Update;
using Adm.Aplication.Commands.Customers.ViewModels;
using Adm.Aplication.Requests.Custommers.GetAll;
using Adm.Aplication.Requests.Custommers.GetById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Adm.Api.Controllers
{
    [Route("v1/customers")]
    public class CustomerController : ApiController
    {
        #region GetAll
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCustomer()));
        }
        #endregion

        #region GetById
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetById([FromRoute] GetByIdCustomer command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion

        #region Post
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<CustomerViewModel>> Create([FromBody] CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion

        #region Put
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<CustomerViewModel>> Update([FromBody] UpdateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion

        #region Remove
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<CustomerViewModel>> Remove([FromRoute] int id)
        {
            await Mediator.Send(new DeleteCustomerCommand { Id = id });
            return Ok("Cliente excluído com sucesso!");
        }
        #endregion
    }
}

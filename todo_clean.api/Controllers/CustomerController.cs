using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_clean.api.shared.results;
using todo_clean.domain.commands.handlers;
using todo_clean.domain.commands.inputs;

namespace todo_clean.api.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerCommandHandler _handler;

        public CustomerController(CustomerCommandHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/add")]
        [ProducesResponseType(typeof(CustomErrorResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CustomSuccessResult), (int)HttpStatusCode.OK)]
        public ActionResult add([FromBody] AddCustomerCommand command)
        {
            var result = _handler.Handle(command);

            if (_handler.Notifications.Any())
                return BadRequest(new CustomErrorResult(_handler.Notifications));

            return Ok(new CustomSuccessResult(result));
        }
    }
}
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using todo_clean.api.shared.results;
using todo_clean.domain.commands.handlers;
using todo_clean.domain.commands.inputs;
using todo_clean.domain.queries.handlers;
using todo_clean.domain.queries.inputs;

namespace todo_clean.api.Controllers
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly AddCustomerCommandHandler _addCustomerCommandHandler;
        private readonly EditCustomerCommandHandler _editCustomerCommandHandler;
        private readonly GetByDocumentCustomerQueryHandler _getByDocumentCustomerQueryHandler;
        private readonly GetByIdCustomerQueryHandler _getByIdCustomerQueryHandler;
        private readonly GetAllCustomerQueryHandler _getAllCustomerQueryHandler;

        public CustomerController(
            AddCustomerCommandHandler addCustomerCommandHandler,
            EditCustomerCommandHandler editCustomerCommandHandler,
            GetByDocumentCustomerQueryHandler getByDocumentQueryHandler,
            GetByIdCustomerQueryHandler getByIdCustomerQueryHandler,
            GetAllCustomerQueryHandler getAllQueryHandler)
        {
            _addCustomerCommandHandler = addCustomerCommandHandler;
            _editCustomerCommandHandler = editCustomerCommandHandler;
            _getByDocumentCustomerQueryHandler = getByDocumentQueryHandler;
            _getByIdCustomerQueryHandler = getByIdCustomerQueryHandler;
            _getAllCustomerQueryHandler = getAllQueryHandler;
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(CustomErrorResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CustomSuccessResult), (int)HttpStatusCode.OK)]
        public ActionResult add([FromBody] AddCustomerCommand command)
        {
            var result = _addCustomerCommandHandler.Handle(command);

            if (_addCustomerCommandHandler.Notifications.Any())
                return BadRequest(new CustomErrorResult(_addCustomerCommandHandler.Notifications));

            return Ok(new CustomSuccessResult(result));
        }

        [HttpPost]
        [Route("edit")]
        [ProducesResponseType(typeof(CustomErrorResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CustomSuccessResult), (int)HttpStatusCode.OK)]
        public ActionResult edit([FromBody] EditCustomerCommand command)
        {
            var result = _editCustomerCommandHandler.Handle(command);

            if (_editCustomerCommandHandler.Notifications.Any())
                return BadRequest(new CustomErrorResult(_editCustomerCommandHandler.Notifications));

            return Ok(new CustomSuccessResult(result));
        }

        [HttpGet]
        [Route("get")]
        [ProducesResponseType(typeof(CustomErrorResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CustomSuccessResult), (int)HttpStatusCode.OK)]
        public ActionResult get([FromQuery] string id, [FromQuery] string documentNumber)
        {
            if (id != null)
            {
                var result = _getByIdCustomerQueryHandler.Handle(new GetByIdCustomerQuery(id));

                if (_getByIdCustomerQueryHandler.Notifications.Any())
                    return BadRequest(new CustomErrorResult(_getByIdCustomerQueryHandler.Notifications));

                return Ok(new CustomSuccessResult(result));
            }
            else
            {
                var result = _getByDocumentCustomerQueryHandler.Handle(new GetByDocumentCustomerQuery(documentNumber));

                if (_getByDocumentCustomerQueryHandler.Notifications.Any())
                    return BadRequest(new CustomErrorResult(_getByDocumentCustomerQueryHandler.Notifications));

                return Ok(new CustomSuccessResult(result));
            }
        }

        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(typeof(CustomErrorResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CustomSuccessResult), (int)HttpStatusCode.OK)]
        public ActionResult getAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _getAllCustomerQueryHandler.Handle(new GetAllCustomerQuery(page, pageSize));

            if (_getAllCustomerQueryHandler.Notifications.Any())
                return BadRequest(new CustomErrorResult(_getAllCustomerQueryHandler.Notifications));

            return Ok(new CustomSuccessResult(result));
        }
    }
}
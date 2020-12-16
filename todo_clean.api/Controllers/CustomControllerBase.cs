using System.Collections.Generic;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using todo_clean.api.shared.results;

namespace todo_clean.api.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        public ActionResult Success(object result)
        {
            return base.Ok(new CustomSuccessResult(result));
        }

        public ActionResult Fail(IEnumerable<Notification> notifications)
        {
            return base.BadRequest(new CustomErrorResult(notifications));
        }
    }
}
using System.Collections.Generic;
using Flunt.Notifications;

namespace todo_clean.api.shared.results
{
    public class CustomErrorResult : CustomResultBase
    {
        public IEnumerable<Notification> errors { get; set; }

        public CustomErrorResult(IEnumerable<Notification> errors)
        {
            this.success = false;
            this.errors = errors;
        }
    }
}
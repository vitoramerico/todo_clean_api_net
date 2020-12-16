using System.Collections.Generic;
using Flunt.Notifications;

namespace todo_clean.api.shared.results
{
    public class CustomErrorResult : CustomResultBase
    {
        public IEnumerable<Notification> result { get; set; }

        public CustomErrorResult(IEnumerable<Notification> result)
        {
            this.success = false;
            this.result = result;
        }
    }
}
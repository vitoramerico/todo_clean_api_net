using System.Collections.Generic;
using Flunt.Notifications;

namespace todo_clean.api.shared.results
{
    public class CustomErrorResult : CustomResultBase
    {
        public IEnumerable<Notification> data { get; set; }

        public CustomErrorResult(IEnumerable<Notification> data)
        {
            this.success = false;
            this.data = data;
        }
    }
}
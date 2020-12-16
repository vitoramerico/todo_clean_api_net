using todo_clean.shared.commands;

namespace todo_clean.domain.commands.results
{
    public class AddCustomerCommandResult : ICommandResult
    {
        public string id { get; set; }
        public AddCustomerCommandResult(string id)
        {
            this.id = id;
        }
    }
}
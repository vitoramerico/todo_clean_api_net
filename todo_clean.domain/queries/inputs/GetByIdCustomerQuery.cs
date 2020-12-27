using todo_clean.shared.queries;

namespace todo_clean.domain.queries.inputs
{
    public class GetByIdCustomerQuery : IQuery
    {
        public string id { get; private set; }

        public GetByIdCustomerQuery(string id)
        {
            this.id = id;
        }
    }
}
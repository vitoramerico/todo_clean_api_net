using todo_clean.shared.queries;

namespace todo_clean.domain.queries.inputs
{
    public class GetAllCustomerQuery : IQuery
    {
        public int page { get; set; }

        public int pageSize { get; set; }

        public GetAllCustomerQuery(int page, int pageSize)
        {

            this.page = page > 0 ? page : 1;
            this.pageSize = pageSize > 0 ? pageSize : 50;
        }
    }
}
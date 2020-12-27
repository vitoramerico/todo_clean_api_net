using todo_clean.shared.queries;

namespace todo_clean.domain.queries.inputs
{
    public class GetByDocumentCustomerQuery : IQuery
    {
        public string documentNumber { get; private set; }

        public GetByDocumentCustomerQuery(string documentNumber)
        {
            this.documentNumber = documentNumber;
        }
    }
}
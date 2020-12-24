using MongoDB.Driver;
using todo_clean.domain.entities;
using todo_clean.infra.context;

namespace todo_clean.infra.datasorces
{
    public class CustomerDataSource : ICustomerDataSource
    {
        private readonly MongoDbContext _context;

        public CustomerDataSource(MongoDbContext context)
        {
            _context = context;
        }

        public bool checkDocumentExists(string documentNumber)
        {
            var result = _context.Customer.CountDocuments(v => v.document.number == documentNumber);

            return result > 0;
        }

        public void save(CustomerEntity customerEntity)
        {
            _context.Customer.InsertOne(customerEntity);
        }
    }
}
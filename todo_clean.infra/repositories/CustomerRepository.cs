using todo_clean.domain.entities;
using todo_clean.domain.repositories;
using todo_clean.infra.datasorces;

namespace todo_clean.infra.repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerDataSource _customerDataSource;

        public CustomerRepository(ICustomerDataSource customerDataSource)
        {
            _customerDataSource = customerDataSource;
        }

        public bool checkDocumentExists(string documentNumber)
        {
            return _customerDataSource.checkDocumentExists(documentNumber);
        }

        public void save(CustomerEntity customerEntity)
        {
            _customerDataSource.save(customerEntity);
        }
    }
}
using todo_clean.domain.entities;

namespace todo_clean.domain.repositories
{
    public interface ICustomerRepository
    {
        void save(CustomerEntity customerEntity);
        bool checkDocumentExists(string documentNumber);
    }
}
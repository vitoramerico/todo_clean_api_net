using todo_clean.domain.entities;

namespace todo_clean.infra.datasorces
{
    public interface ICustomerDataSource
    {
        bool checkDocumentExists(string documentNumber);
        void save(CustomerEntity customerEntity);
    }
}
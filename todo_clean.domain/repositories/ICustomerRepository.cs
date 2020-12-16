namespace todo_clean.domain.repositories
{
    public interface ICustomerRepository
    {
        bool checkDocumentExists(string documentNumber);
    }
}
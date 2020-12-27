using System;
using System.Collections.Generic;
using todo_clean.domain.entities;

namespace todo_clean.domain.repositories
{
    public interface ICustomerRepository
    {
        void save(CustomerEntity customerEntity);
        void update(CustomerEntity customerEntity);
        bool checkDocumentExists(string documentNumber);
        bool checkEmailExists(string emailAddress);
        CustomerEntity getById(string id);
        CustomerEntity getByDocument(string documentNumber);
        List<CustomerEntity> getAll(int page, int pageSize);
    }
}
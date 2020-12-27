using System;
using System.Collections.Generic;
using todo_clean.domain.entities;

namespace todo_clean.infra.datasorces
{
    public interface ICustomerDataSource
    {
        void save(CustomerEntity customerEntity);
        void update(CustomerEntity customerEntity);
        CustomerEntity getById(string id);
        CustomerEntity getByDocument(string documentNumber);
        List<CustomerEntity> getAll(int page, int pageSize);
        bool checkDocumentExists(string documentNumber);
        bool checkEmailExists(string emailAddress);
    }
}
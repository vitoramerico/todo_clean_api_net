using System;
using System.Collections.Generic;
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
        public void save(CustomerEntity customerEntity)
        {
            _customerDataSource.save(customerEntity);
        }

        public CustomerEntity getByDocument(string documentNumber)
        {
            return _customerDataSource.getByDocument(documentNumber);
        }

        public bool checkDocumentExists(string documentNumber)
        {
            return _customerDataSource.checkDocumentExists(documentNumber);
        }

        public bool checkEmailExists(string emailAddress)
        {
            return _customerDataSource.checkEmailExists(emailAddress);
        }

        public List<CustomerEntity> getAll(int page, int pageSize)
        {
            return _customerDataSource.getAll(page, pageSize);
        }

        public void update(CustomerEntity customerEntity)
        {
            _customerDataSource.update(customerEntity);
        }

        public CustomerEntity getById(string id)
        {
            return _customerDataSource.getById(id);
        }


    }
}
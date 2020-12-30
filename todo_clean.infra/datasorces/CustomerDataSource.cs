using System;
using System.Collections.Generic;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using todo_clean.domain.entities;
using todo_clean.infra.context;
using todo_clean.infra.models;
using todo_clean.infra.profiles;

namespace todo_clean.infra.datasorces
{
    public class CustomerDataSource : ICustomerDataSource
    {
        private readonly MongoDbContext _context;

        private readonly IMapper _mapper;

        public CustomerDataSource(MongoDbContext context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<CustomerProfile>()).CreateMapper();
        }

        public bool checkDocumentExists(string documentNumber)
        {
            var result = _context.Customer.CountDocuments(v => v.documentNumber == documentNumber);

            return result > 0;
        }

        public bool checkEmailExists(string emailAddress)
        {
            var result = _context.Customer.CountDocuments(v => v.emailAddress == emailAddress);

            return result > 0;
        }

        public List<CustomerEntity> getAll(int page, int pageSize)
        {
            var result = _context.Customer.Find<CustomerModel>(v => true).Skip((page - 1) * pageSize).Limit(pageSize).ToList();

            return _mapper.Map<List<CustomerEntity>>(result);
        }

        public CustomerEntity getById(string id)
        {
            if (Guid.TryParse(id, out var newGuid))
            {
                var result = _context.Customer.Find<CustomerModel>(v => v.id == newGuid).FirstOrDefault();

                if (result == null) return null;

                return _mapper.Map<CustomerEntity>(result);
            }
            else
                return null;
        }

        public CustomerEntity getByDocument(string documentNumber)
        {
            var result = _context.Customer.Find<CustomerModel>(c => c.documentNumber == documentNumber).FirstOrDefault();

            return _mapper.Map<CustomerEntity>(result);
        }

        public void save(CustomerEntity customerEntity)
        {
            var customerModel = _mapper.Map<CustomerModel>(customerEntity);

            _context.Customer.InsertOne(customerModel);
        }

        public void update(CustomerEntity customerEntity)
        {
            var customerModel = _mapper.Map<CustomerModel>(customerEntity);

            _context.Customer.ReplaceOne(v => v.id == customerEntity.id, customerModel);
        }
    }
}
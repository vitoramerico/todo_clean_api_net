using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using todo_clean.domain.queries.inputs;
using todo_clean.domain.queries.results;
using todo_clean.domain.repositories;
using todo_clean.shared.queries;

namespace todo_clean.domain.queries.handlers
{
    public class GetAllCustomerQueryHandler : Notifiable, IQueryHandler<GetAllCustomerQuery, List<CustomerQueryResult>>
    {
        public readonly ICustomerRepository _customerRepository;

        public GetAllCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<CustomerQueryResult> Handle(GetAllCustomerQuery query)
        {
            var result = _customerRepository.getAll(query.page, query.pageSize);

            if (result == null)
            {
                AddNotification("GetAllCustomerQueryHandler", "Erro ao buscar dados");
                return null;
            }

            return result.Select(v => new CustomerQueryResult(
                v.id.ToString(),
                v.name,
                v.birthDate,
                v.document.number,
                v.address.street,
                v.address.number,
                v.address.neighborhood,
                v.address.city,
                v.address.state,
                v.address.zipCode,
                v.email.address
                )).ToList();
        }
    }
}
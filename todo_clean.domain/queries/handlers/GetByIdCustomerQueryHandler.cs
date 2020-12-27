using Flunt.Notifications;
using todo_clean.domain.queries.inputs;
using todo_clean.domain.queries.results;
using todo_clean.domain.repositories;
using todo_clean.shared.queries;

namespace todo_clean.domain.queries.handlers
{
    public class GetByIdCustomerQueryHandler : Notifiable, IQueryHandler<GetByIdCustomerQuery, CustomerQueryResult>
    {
        public readonly ICustomerRepository _customerRepository;

        public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerQueryResult Handle(GetByIdCustomerQuery query)
        {
            var result = _customerRepository.getById(query.id);

            if (result == null)
            {
                AddNotification("Id", "Registro não encontrado");
                return null;
            }

            return new CustomerQueryResult(
                result.id.ToString(),
                result.name,
                result.birthDate,
                result.document.number,
                result.address.street,
                result.address.number,
                result.address.neighborhood,
                result.address.city,
                result.address.state,
                result.address.zipCode,
                result.email.address
                );
        }
    }
}
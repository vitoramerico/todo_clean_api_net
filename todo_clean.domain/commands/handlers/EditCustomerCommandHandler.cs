using Flunt.Notifications;
using todo_clean.domain.commands.inputs;
using todo_clean.domain.commands.results;
using todo_clean.domain.entities;
using todo_clean.domain.repositories;
using todo_clean.domain.value_objects;
using todo_clean.shared.commands;

namespace todo_clean.domain.commands.handlers
{
    public class EditCustomerCommandHandler : Notifiable, ICommandHandler<EditCustomerCommand>
    {
        public readonly ICustomerRepository _customerRepository;

        public EditCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ICommandResult Handle(EditCustomerCommand command)
        {
            var oldCustomer = _customerRepository.getById(command.id);

            // Verificar se existe o cliente
            if (oldCustomer == null)
            {
                AddNotification("Customer", "Cliente não encontrado");
                return null;
            }

            // Gerar o novo cliente
            var document = new DocumentVo(command.documentNumber);
            var email = new EmailVo(command.emailAddress);
            var address = new AddressVo(
                command.addressStreet,
                command.addressNumber,
                command.addressNeighborhood,
                command.addressCity,
                command.addressState,
                command.addressZipCode
            );
            var customer = new CustomerEntity(
                command.name,
                command.birthDate,
                document,
                address,
                email,
                oldCustomer.createAt,
                id: oldCustomer.id);

            // Adicionar as notificação
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(address.Notifications);
            AddNotifications(customer.Notifications);

            if (this.Invalid)
                return null;

            // altera
            _customerRepository.update(customer);

            return new AddCustomerCommandResult(customer.id.ToString());
        }
    }
}
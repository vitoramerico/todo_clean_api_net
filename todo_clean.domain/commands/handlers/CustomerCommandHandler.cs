using Flunt.Notifications;
using todo_clean.domain.commands.inputs;
using todo_clean.domain.commands.results;
using todo_clean.domain.entities;
using todo_clean.domain.repositories;
using todo_clean.domain.value_objects;
using todo_clean.shared.commands;

namespace todo_clean.domain.commands.handlers
{
    public class CustomerCommandHandler : Notifiable, ICommandHandler<AddCustomerCommand>
    {
        //public readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler()
        {
            //_customerRepository = customerRepository;
        }

        public ICommandResult Handle(AddCustomerCommand command)
        {
            // Verificar se o CPF já existe
            /*if (_customerRepository.checkDocumentExists(command.documentNumber))
            {
                AddNotification("Document", "Este CPF já está em uso!");
                return null;
            }*/

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
            var customer = new CustomerEntity(command.name, command.birthDate, document, address, email);

            // Adicionar as notificação
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(address.Notifications);
            AddNotifications(customer.Notifications);

            if (this.Invalid)
                return null;

            // Inserir no banco
            //_customerRepository.Save(customer);

            // Enviar E-mail de boas vindas     
            /*_emailService.Send(
                customer.Name.ToString(),
                customer.Email.Address,
                string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name),
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name));*/

            return new AddCustomerCommandResult("1");
        }
    }
}
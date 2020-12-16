using Flunt.Validations;
using todo_clean.shared.value_objects;

namespace todo_clean.domain.value_objects
{
    public class EmailVo : ValueObjectBase
    {
        public string address { get; private set; }

        public EmailVo(string address)
        {
            this.address = address;

            AddNotifications(new Contract()
                .IsEmail(address, "EmailVo.address", "E-mail inválido")
            );
        }
    }
}
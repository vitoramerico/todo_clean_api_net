using Flunt.Validations;
using todo_clean.shared.value_objects;

namespace todo_clean.domain.value_objects
{
    public class AddressVo : ValueObjectBase
    {
        public string street { get; private set; }
        public string number { get; private set; }
        public string neighborhood { get; private set; }
        public string city { get; private set; }
        public string state { get; private set; }
        public string zipCode { get; private set; }

        public AddressVo(string street, string number, string neighborhood, string city, string state, string zipCode)
        {
            this.street = street;
            this.number = number;
            this.neighborhood = neighborhood;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;

             AddNotifications(new Contract()
                .IsNotNullOrEmpty(street, "AddressVo.street", "Rua é obrigatória")
                .IsNotNullOrEmpty(neighborhood, "AddressVo.neighborhood", "Bairro é obrigatório")
                .IsNotNullOrEmpty(city, "AddressVo.city", "Cidade é obrigatório")
                .IsNotNullOrEmpty(state, "AddressVo.state", "Estado é obrigatório")
            );
        }
    }
}
using System;
using Flunt.Validations;
using todo_clean.domain.value_objects;
using todo_clean.shared.entities;

namespace todo_clean.domain.entities
{
    public class CustomerEntity : BaseEntity
    {
        public string name { get; private set; }
        public DateTime? birthDate { get; private set; }
        public DocumentVo document { get; private set; }
        public AddressVo address { get; private set; }
        public EmailVo email { get; private set; }

        public CustomerEntity(DateTime createAt, Guid? id = null) : base(createAt: createAt)
        {
        }

        public CustomerEntity(
            string name,
            DateTime? birthDate,
            DocumentVo document,
            AddressVo address,
            EmailVo email,
            DateTime createAt,
            Guid? id = null) : base(id: id, createAt: createAt)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.document = document;
            this.address = address;
            this.email = email;

            AddNotifications(new Contract()
                .IsNotNullOrEmpty(name, "CustomerEntity.name", "Nome é obrigatório")
            );
        }
    }
}
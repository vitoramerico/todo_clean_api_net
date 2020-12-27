using System;
using MongoDB.Bson.Serialization.Attributes;
using todo_clean.domain.value_objects;

namespace todo_clean.infra.models
{
    public class CustomerModel
    {
        [BsonId]
        public Guid id { get; private set; }
        public string name { get; private set; }
        public DateTime? birthDate { get; private set; }
        public string documentNumber { get; private set; }
        public string emailAddress { get; private set; }
        public AddressVo address { get; private set; }
        public DateTime createAt { get; private set; }
        public DateTime updateAt { get; private set; }
    }
}
using System;

namespace todo_clean.domain.queries.results
{
    public class CustomerQueryResult
    {
        public string id { get; private set; }
        public string name { get; private set; }
        public DateTime? birthDate { get; private set; }
        public string documentNumber { get; private set; }
        public string addressStreet { get; private set; }
        public string addressNumber { get; private set; }
        public string addressNeighborhood { get; private set; }
        public string addressCity { get; private set; }
        public string addressState { get; private set; }
        public string addressZipCode { get; private set; }
        public string emailAddress { get; private set; }

        public CustomerQueryResult(
            string id,
            string name,
            DateTime? birthDate,
            string documentNumber,
            string addressStreet,
            string addressNumber,
            string addressNeighborhood,
            string addressCity,
            string addressState,
            string addressZipCode,
            string emailAddress)
        {
            this.id = id;
            this.name = name;
            this.birthDate = birthDate;
            this.documentNumber = documentNumber;
            this.addressStreet = addressStreet;
            this.addressNumber = addressNumber;
            this.addressNeighborhood = addressNeighborhood;
            this.addressCity = addressCity;
            this.addressState = addressState;
            this.addressZipCode = addressZipCode;
            this.emailAddress = emailAddress;
        }
    }
}
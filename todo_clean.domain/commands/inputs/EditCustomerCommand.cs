using System;
using todo_clean.shared.commands;

namespace todo_clean.domain.commands.inputs
{
    public class EditCustomerCommand : ICommand
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime? birthDate { get; set; }
        public string documentNumber { get; set; }
        public string addressStreet { get; set; }
        public string addressNumber { get; set; }
        public string addressNeighborhood { get; set; }
        public string addressCity { get; set; }
        public string addressState { get; set; }
        public string addressZipCode { get; set; }
        public string emailAddress { get; set; }
    }
}
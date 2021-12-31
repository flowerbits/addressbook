using System;

namespace AddressbookServer.Models
{
    public class EntryModel : IBaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

    }
}

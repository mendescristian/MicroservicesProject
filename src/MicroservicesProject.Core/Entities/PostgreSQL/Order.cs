using MicroservicesProject.Core.Entities.PostgreSQL.Common;
using MicroservicesProject.Core.Enums;

namespace MicroservicesProject.Core.Entities.PostgreSQL
{
    public class Order : EntityBase
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        // BillingAddress
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        // Payment
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public string PixCopyPaste { get; set; }
        public string PaymentUrl { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
    }
}

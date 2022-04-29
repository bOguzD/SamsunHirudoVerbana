using System;
using System.Collections.Generic;

namespace SamsunHirudoVerbana.Data
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int OrderNumber { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public DateTimeOffset? ShippingDate { get; set; }
        public int Status { get; set; }
        public bool IsCancelled { get; set; }
        public int AddressId { get; set; }
        public int? ShippingId { get; set; }
        public bool IsPaid { get; set; }
        public DateTimeOffset? PaymentDate { get; set; }
        public string? Note { get; set; }
        public DateTimeOffset? EstimatedTimeOfArrival { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FakeXieCheng.API.Models
{
    public enum OrdersState
    {
        Pending,
        Processing,
        Completed,
        Declined,
        Cancelled,
        Refund
    }
    public class Order
    {
        [Key]
        public Guid Id {get;set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<LineItem> OrderItems { get; set; }

        public OrdersState State { get; set; }

        public DateTime CreateDateUtc { get; set; }

        public string TransactionMetaData { get; set; }
    }
}

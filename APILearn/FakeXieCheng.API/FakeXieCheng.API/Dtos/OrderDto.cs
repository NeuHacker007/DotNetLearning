using System;
using System.Collections.Generic;

namespace FakeXieCheng.API.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public ICollection<LineItemDto> OrderItems { get; set; }

        public string State { get; set; }

        public DateTime CreateDateUtc { get; set; }

        public string TransactionMetaData { get; set; }
    }
}

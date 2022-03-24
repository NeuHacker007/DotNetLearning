using FakeXieCheng.API.Models;
using System;
using System.Collections.Generic;

namespace FakeXieCheng.API.Dtos
{
    public class ShoppingCartDto
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public ICollection<LineItem> ShoppingCartItems { get; set; }
    }
}

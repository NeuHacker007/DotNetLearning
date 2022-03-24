﻿using FakeXieCheng.API.Models;
using System;

namespace FakeXieCheng.API.Dtos
{
    public class LineItemDto
    {
        public int Id { get; set; }

        public Guid TouristRouteId { get; set; }
        public TouristRouteDto TouristRoute { get; set; }

        public Guid? ShoppingCartId { get; set; }

        //public Guid? OrderId { get; set; }
        public decimal OriginalPrice { get; set; }
        public double? DiscountPresent { get; set; }
    }
}

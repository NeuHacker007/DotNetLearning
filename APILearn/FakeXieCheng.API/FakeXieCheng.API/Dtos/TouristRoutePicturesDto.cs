﻿using System;

namespace FakeXieCheng.API.Dtos
{
    public class TouristRoutePicturesDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        
        public Guid TouristRouteId { get; set; }
    }
}

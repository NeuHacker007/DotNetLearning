using System;
using System.Collections.Generic;

namespace Eva.Dtos
{
    public class NewRentalDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }

        public DateTime DateTime { get; set; }
        public DateTime RentalTime { get; set; }

        public DateTime? ReturnTime { get; set; }


    }
}
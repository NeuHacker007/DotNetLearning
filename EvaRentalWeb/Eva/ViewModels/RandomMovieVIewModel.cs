using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eva.Models;

namespace Eva.ViewModels
{
    public class RandomMovieVIewModel
    {
        public Movie movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
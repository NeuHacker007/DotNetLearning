using JooleMarketPlace.WebAPI.Models;
using System.Collections.Generic;

namespace JooleMarketPlace.WebAPI.Interfaces
{
    interface IProductRepository : IRepository<Product>
    {
        List<Product> GetCompareProducts(List<string> productIds);
    }
}

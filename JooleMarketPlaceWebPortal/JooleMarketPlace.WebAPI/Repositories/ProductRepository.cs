using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using JooleMarketPlace.WebAPI.Interfaces;
using JooleMarketPlace.WebAPI.Models;


namespace JooleMarketPlace.WebAPI.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public List<Product> GetCompareProducts(List<string> productIds)
        {
            throw new NotImplementedException();
        }
    }
}
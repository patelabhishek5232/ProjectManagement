

using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Context;
using ProductManagement.API.Models;
using ProductManagement.API.Repository;
using System.Data;

namespace ProductManagement.Services
{
    public class ProductServices : Repository<Product>, IProductService
    {
        public ProductDbContext _dbContext { get; set; }
        public ProductServices(ProductDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                product.IsActive = false;
                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<ProductDetails>> RetrieveProductDetails()
        {
            return await _dbContext
        .Set<ProductDetails>()
        .FromSqlRaw("EXEC sp_retrieveProductDetails")
        .ToListAsync();
            //await _dbContext.Database.ExecuteSqlRaw("EXEC sp_retrieveProductDetails");
        }

    }
    public interface IProductService : IRepository<Product>
    {
        Task<bool> SoftDelete(int id);
        Task<List<ProductDetails>> RetrieveProductDetails();
    }
}

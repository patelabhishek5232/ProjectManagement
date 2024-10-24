

using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Context;
using ProductManagement.API.Models;
using ProductManagement.API.Repository;
using System.Data;

namespace ProductManagement.Services
{
    public class CategoryService : Repository<Category>, ICategoryService
    {
        public ProductDbContext _dbContext { get; set; }
        public CategoryService(ProductDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        
    }
    public interface ICategoryService : IRepository<Category>
    {
    }
}

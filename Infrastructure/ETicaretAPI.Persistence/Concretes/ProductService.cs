using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence.Concretes;

public class ProductService : IProductService
{
    public List<Product> GetProducts() => new()
    {
        new()
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            Name = "Product",
            Price = 100,
            Stock = 10
        },
        new()
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            Name = "Product 2",
            Price = 200,
            Stock = 8
        }
    };
}
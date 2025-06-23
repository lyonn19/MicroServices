using Microsoft.EntityFrameworkCore;
using Products.Domain;

namespace Products.Infrastructure;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
    public DbSet<Product> Books => Set<Product>();
}
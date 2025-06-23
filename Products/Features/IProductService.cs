namespace Products.Features;

public interface IProductService
{
    public Task<ProductModel> GetProduct(int id);
    public Task<int> AddProduct(ProductModel product);
}

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
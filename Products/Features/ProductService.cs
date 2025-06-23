namespace Products.Features;

public class ProductService : IProductService
{
    public async Task<ProductModel> GetProduct(int id)
    {
        return await Task.FromResult(new ProductModel() { Id = id });
    }

    public async Task<int> AddProduct(ProductModel productModel)
    {
        var products = new List<ProductModel> { productModel };

        return products.Last().Id;      
    }
    
}
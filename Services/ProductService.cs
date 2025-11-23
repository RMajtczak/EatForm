using AutoMapper;
using EatForm.Entities;
using EatForm.Models;

namespace EatForm;

public interface IProductService
{
    IEnumerable<ProductDto> GetAllProducts();
    ProductDto GetProductsByIds(int id);
    int CreateProduct(CreateProductDto dto);
    void UpdateProduct(CreateProductDto dto, int id);
    void DeleteProduct(int id);
}
public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly EatFormDbContext _dbContext;
    
    public ProductService(IMapper mapper, EatFormDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    
    public IEnumerable<ProductDto> GetAllProducts()
    {
        var products = _dbContext.Products.ToList();
        var productDtos = _mapper.Map<List<ProductDto>>(products);
        return productDtos;
    }
    
    public ProductDto GetProductsByIds(int id)
    {
        var products = _dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (products == null)
            throw new Exception("Product not found");
        var productDtos = _mapper.Map<ProductDto>(products);
        return productDtos;
    }
    
    public int CreateProduct(CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        
        return product.Id;
    }
    
    public void UpdateProduct(CreateProductDto dto, int id)
    {
        var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            throw new Exception("Product not found");
        
        _mapper.Map(dto, product);
        _dbContext.SaveChanges();
    }
    
    public void DeleteProduct(int id)
    {
        var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            throw new Exception("Product not found");
        
        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();
    }
}
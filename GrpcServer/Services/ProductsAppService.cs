using Grpc.Core;
using GrpcServer.Models;
using static GrpcServer.ProductsService;

namespace GrpcServer.Services
{
    public class ProductsService : ProductsServiceBase
    {
        public AppDbContext dbContext;
        public ProductsService(AppDbContext DBContext)
        {
            dbContext = DBContext;
        }

        #region GetAll
        public override async Task<Products> GetAll(Empty request, ServerCallContext context)
        {
            Products response = new Products();
            var products = from prd in dbContext.products
                           select new Product()
                           {
                               ProductRowId = prd.ProductRowId,
                               ProductId = prd.ProductId,
                               ProductName = prd.ProductName,
                               CategoryName = prd.CategoryName,
                               Manufacturer = prd.Manufacturer,
                               Price = prd.Price
                           };
            response.Items.AddRange(products.ToArray());
            return await Task.FromResult(response);
        }
        #endregion

        #region GetById
        public override Task<Product> GetById(ProductRowIdFilter request, ServerCallContext context)
        {
            var product = dbContext.products.Find(request.ProductRowId);
            var searchedProduct = new Product()
            {
                ProductRowId = product.ProductRowId,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryName = product.CategoryName,
                Manufacturer = product.Manufacturer,
                Price = product.Price
            };
            return Task.FromResult(searchedProduct);
        }
        #endregion



    }
}

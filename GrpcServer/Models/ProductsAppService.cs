using Grpc.Core;
using static GrpcServer.ProductsService;

namespace GrpcServer.Models
{
    public class ProductsAppService : ProductsServiceBase
    {
        public AppDbContext dbContext;
        public ProductsAppService(AppDbContext DBContext)
        {
            dbContext = DBContext;
        }

        #region GetAll
        public override Task<Products> GetAll(Empty request, ServerCallContext context)
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
            return Task.FromResult(response);
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

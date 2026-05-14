using Inventory.Repository.Paging;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.ProductViewModel;

namespace Inventory.Repository.ProductService
{
    public class ProductRepo : IProductRepo
    {
        public readonly ApplicationDbContext _applicationDbContext;

        public ProductRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<ProductListViewModel>> GetAll(int pageNumber, int pageSize)
        {
            var ProductList = _applicationDbContext.Products;
            var ProductListviewModel = ProductList.ProductListToProductListViewModel().AsQueryable();
            return await PaginatedList<ProductListViewModel>.CreateAsync(ProductListviewModel, pageSize, pageNumber);
        }
    }
}

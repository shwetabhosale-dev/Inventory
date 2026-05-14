using Inventory.Repository.Paging;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.ProductViewModel;

namespace Inventory.Repository.ProductTypeService
{
    public class ProductTypeRepo : IProductTypeRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductTypeRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<ProductTypeListViewModel>> GetAll(int pageNumber, int pageSize)
        {
            var ProductType = _applicationDbContext.ProductTypes;
            var ProductTypeListViewModel = ProductType.ProductTypeToProductTypeListViewModel().AsQueryable();
            return await PaginatedList<ProductTypeListViewModel>.CreateAsync(ProductTypeListViewModel, pageNumber, pageSize);
        }
    }
}

using Inventory.ViewModel.ProductViewModel;

namespace Inventory.Repository.ProductService
{
    public interface IProductRepo
    {
        Task<IEnumerable<ProductListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}

using Inventory.ViewModel.ProductViewModel;

namespace Inventory.Repository.ProductTypeService
{
    public interface IProductTypeRepo
    {
        Task<IEnumerable<ProductTypeListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}

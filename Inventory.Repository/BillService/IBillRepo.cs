using Inventory.ViewModel.BillViewModel;

namespace Inventory.Repository.BillService
{
    public interface IBillRepo
    {
        Task <IEnumerable<BillListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}

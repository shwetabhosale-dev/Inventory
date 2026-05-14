using Inventory.Repository.Paging;
using Inventory.ViewModel.BillViewModel;
using Inventory.ViewModel.Mapping;

namespace Inventory.Repository.BillService
{
    public class BillRepo : IBillRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BillRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<BillListViewModel>> GetAll(int pageNumber, int pageSize)
        {
            var BillList = _applicationDbContext.Bills;
            var BillListViewModel = BillList.BillModelToBillListViewModel().AsQueryable();
            return await PaginatedList<BillListViewModel>.CreateAsync(BillListViewModel, pageNumber, pageSize);
        }
    }
}

using Inventory.Repository.Paging;
using Inventory.ViewModel.CustomerViewModel;
using Inventory.ViewModel.Mapping;

namespace Inventory.Repository.CustomerTypeService
{
    public class CustomerTypeRepo : ICustomerTypeRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerTypeRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<PaginatedList<CustomerTypeListViewModel>> GetAll(int pageNumber, int pageSize)
        {
            var customerTypeList = _applicationDbContext.CustomerTypes;
            var customerTypeListViewModels = customerTypeList.CustomerTypeModelToCustomerTypeListViewModel().AsQueryable();
            return await PaginatedList<CustomerTypeListViewModel>.CreateAsync(customerTypeListViewModels, pageNumber, pageSize);
        }
    }
}

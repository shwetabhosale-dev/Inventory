using Inventory.Repository.Paging;
using Inventory.ViewModel.CustomerViewModel;
using Inventory.ViewModel.Mapping;

namespace Inventory.Repository.CustomerService
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Paging.PaginatedList<CustomerListViewModel>> GetAll(int pageNumber, int pageSize)
        {
            var customerList = _applicationDbContext.Customers;
            var customerListViewModel = customerList.CustomerModelToCustomerListViewModel().AsQueryable();
            return await PaginatedList<CustomerListViewModel>.CreateAsync(customerListViewModel, pageNumber, pageSize);
        }
    }
}

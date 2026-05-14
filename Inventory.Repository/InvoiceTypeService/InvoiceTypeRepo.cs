using Inventory.Repository.Paging;
using Inventory.ViewModel.InvoiceViewModel;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Repository.InvoiceTypeService
{
    public class InvoiceTypeRepo : IInvoiceTypeRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public InvoiceTypeRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<PaginatedList<InvoiceTypeListViewModel>> GetAll(int pageNumber, int pageSize)
        {
            var InvoiceTypeList = _applicationDbContext.InvoiceTypes;
            var InvoiceTypeListViewModel = InvoiceTypeList.InvoiceTypeModelToInvoiceTypeListViewModel().AsQueryable();
            return await PaginatedList<InvoiceTypeListViewModel>.CreateAsync(InvoiceTypeListViewModel, pageNumber, pageSize);
        }
    }
}

using Inventory.Repository.Paging;
using Inventory.ViewModel.InvoiceViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Repository.InvoiceTypeService
{
    public interface IInvoiceTypeRepo
    {
        Task<PaginatedList<InvoiceTypeListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}

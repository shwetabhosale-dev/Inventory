using Inventory.Repository.Paging;
using Inventory.ViewModel.InvoiceViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Repository.InvoiceService
{
    public interface IInvoiceRepo
    {
        Task<PaginatedList<InvoiceListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}

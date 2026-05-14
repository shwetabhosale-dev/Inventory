using Inventory.Repository.Paging;
using Inventory.ViewModel.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Repository.ProductService
{
    public interface IProductRepo
    {
        Task<IEnumerable<ProductListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}

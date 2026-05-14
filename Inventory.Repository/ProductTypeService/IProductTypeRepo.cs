using Inventory.ViewModel.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Repository.ProductTypeService
{
    public interface IProductTypeRepo
    {
        Task<IEnumerable<ProductTypeListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}

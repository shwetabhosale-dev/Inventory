using Inventory.ViewModel.BillViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Repository.BillTypeService
{
    public interface IBillTypeRepo
    {
        Task<IEnumerable<BillTypeListViewModel>> GetAll(int pageNumber, int pageSize);
    }
}

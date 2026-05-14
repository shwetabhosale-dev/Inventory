using Inventory.Repository.Paging;
using Inventory.ViewModel.BillViewModel;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Repository.BillTypeService
{
    public class BillTypeRepo : IBillTypeRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BillTypeRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<BillTypeListViewModel>> GetAll(int pageNumber, int pageSize)
        {
            var BillType = _applicationDbContext.BillTypes;
            var BillTypeListViewModel = BillType.BillTypeModelToBillTypeListViewModel().AsQueryable();
            return await PaginatedList<BillTypeListViewModel>.CreateAsync(BillTypeListViewModel, pageNumber, pageSize);
        }
    }
}

using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.BillViewModel;
using Inventory.ViewModel.Mapping;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Inventory.Repository.BillTypeService
{
    public class BillTypeRepo : IBillTypeRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BillTypeRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //public async Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageNumber, int pageSize)
        //{
        //    var billTypesQuery = _applicationDbContext.BillTypes
        //        .Select(bt => new BillTypeListViewModel
        //        {
        //            BillTypeId = bt.BillTypeId,
        //            BillTypeName = bt.BillTypeName,
        //            Description = bt.Description
        //        });
        //    return await PaginatedList<BillTypeListViewModel>.CreateAsync(billTypesQuery, pageNumber, pageSize);
        //}

        public async Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageNumber - 1) * pageSize;

                var modelList = await _applicationDbContext.BillTypes
                    .Skip(excludeRecords)
                    .Take(pageSize)
                    .ToListAsync();

                int totalCount = await _applicationDbContext.BillTypes.CountAsync();

                var billTypes = modelList
                    .BillTypeModelToBillTypeListViewModel()
                    .ToList();

                return new PaginatedList<BillTypeListViewModel>
                (
                    billTypes,
                    totalCount,
                    pageNumber,
                    pageSize
                );
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching bill types.", ex);
            }
        }

        public async Task Add(BillTypeListViewModel viewModel)
        {
            var billType = new BillType
            {
                BillTypeName = viewModel.BillTypeName,
                Description = viewModel.Description
            };
            await _applicationDbContext.BillTypes.AddAsync(billType);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(BillTypeListViewModel viewModel)
        {
            var billType = await _applicationDbContext.BillTypes.FindAsync(viewModel.BillTypeId);
            if (billType != null)
            {
                billType.BillTypeName = viewModel.BillTypeName;
                billType.Description = viewModel.Description;
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(int billTypeId)
        {
            var billType = await _applicationDbContext.BillTypes.FindAsync(billTypeId);
            if (billType != null)
            {
                _applicationDbContext.BillTypes.Remove(billType);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<BillTypeListViewModel> GetById(int billTypeId)
        {
            var billType = await _applicationDbContext.BillTypes.FindAsync(billTypeId);
            if (billType != null)
            {
                return new BillTypeListViewModel(billType);
            }
            throw new Exception("BillType not found");
        }

        public async Task AddByStoredProcedure(BillTypeListViewModel viewModel)
        {
            var parameters = new[]
            {
                new SqlParameter("@BillTypeName", viewModel.BillTypeName),
                new SqlParameter("@Description", viewModel.Description)
            };

            await _applicationDbContext.Database.ExecuteSqlRawAsync(
                "EXEC Add_Bill_Type @BillTypeName, @Description", parameters);
        }
    }
}

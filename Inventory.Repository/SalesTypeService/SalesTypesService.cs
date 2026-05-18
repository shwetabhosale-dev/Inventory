using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.SalesViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Inventory.ViewModel.Mapping;

namespace Inventory.Repository.SalesTypeService
{
    public class SalesTypesService : ISalesTypeService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SalesTypesService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<PaginatedList<SalesTypeListViewModel>> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageNumber - 1) * pageSize;

                var modelList = await _applicationDbContext.SalesTypes
                    .Skip(excludeRecords)
                    .Take(pageSize)
                    .ToListAsync();

                int totalCount = await _applicationDbContext.SalesTypes.CountAsync();

                var salesTypes = modelList
                    .SalesTypeToSalesTypeListViewModel()
                    .ToList();

                return new PaginatedList<SalesTypeListViewModel>
                (
                    salesTypes,
                    totalCount,
                    pageNumber,
                    pageSize
                );
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching sales types.", ex);
            }
        }

        public async Task Add(SalesTypeListViewModel viewModel)
        {
            var saleType = new SalesType
            {

                SalesTypeName = viewModel.SalesTypeName,
                Description = viewModel.Description
            };
            await _applicationDbContext.SalesTypes.AddAsync(saleType);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task AddByStoredProcedure(SalesTypeListViewModel viewModel)
        {
            var parameters = new[]
            {
                new SqlParameter("@SalesTypeName", viewModel.SalesTypeName),
                new SqlParameter("@Description", viewModel.Description)
            };

            await _applicationDbContext.Database.ExecuteSqlRawAsync(
                "EXEC Add_Sales_Type @SalesTypeName, @Description", parameters);
        }

        public async Task Delete(int SalesTypeId)
        {
            var saletype = await _applicationDbContext.SalesTypes.FindAsync(SalesTypeId);
            if (saletype != null)
            {
                _applicationDbContext.SalesTypes.Remove(saletype);
                await _applicationDbContext.SaveChangesAsync();
            }
        }


        public async Task<SalesTypeListViewModel> GetById(int SalesTypeId)
        {
            var salestype = await _applicationDbContext.SalesTypes.FindAsync(SalesTypeId);
            if (salestype != null)
            {
                return new SalesTypeListViewModel(salestype);
            }
            throw new Exception("SalesType not found");
        }

        public async Task Update(SalesTypeListViewModel viewModel)
        {
            var saletype = await _applicationDbContext.SalesTypes.FindAsync(viewModel.SalesTypeId);
            if (saletype != null)
            {
                saletype.SalesTypeName = viewModel.SalesTypeName;
                saletype.Description = viewModel.Description;
                await _applicationDbContext.SaveChangesAsync();
            }
        }
    }
}

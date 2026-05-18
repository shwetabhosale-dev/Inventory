using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.InvoiceViewModel;
using Inventory.ViewModel.Mapping;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                int excludeRecords = (pageNumber - 1) * pageSize;

                var modelList = await _applicationDbContext.InvoiceTypes
                    .Skip(excludeRecords)
                    .Take(pageSize)
                    .ToListAsync();

                int totalCount = await _applicationDbContext.InvoiceTypes.CountAsync();

                var invoiceTypes = modelList
                    .InvoiceTypeToInvoiceTypeListViewModels()
                    .ToList();

                return new PaginatedList<InvoiceTypeListViewModel>
                (
                    invoiceTypes,
                    totalCount,
                    pageNumber,
                    pageSize
                );
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching invoice types.", ex);
            }
        }

        public async Task Add(InvoiceTypeListViewModel viewModel)
        {
            var invoiceType = new InvoiceType
            {
                InvoiceTypeName = viewModel.InvoiceTypeName,
                Description = viewModel.Description
            };
            await _applicationDbContext.InvoiceTypes.AddAsync(invoiceType);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task AddByStoredProcedure(InvoiceTypeListViewModel viewModel)
        {
            var parameters = new[]
            {
                new SqlParameter("@InvoiceTypeName", viewModel.InvoiceTypeName),
                new SqlParameter("@Description", viewModel.Description)
            };

            await _applicationDbContext.Database.ExecuteSqlRawAsync(
                "EXEC Add_Invoice_Type @InvoiceTypeName, @Description", parameters);
        }

        public async Task Delete(int invoiceTypeId)
        {
            var invoiceType = await _applicationDbContext.InvoiceTypes.FindAsync(invoiceTypeId);
            if (invoiceType != null)
            {
                _applicationDbContext.InvoiceTypes.Remove(invoiceType);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<InvoiceTypeListViewModel> GetById(int invoiceTypeId)
        {
            var invoiceType = await _applicationDbContext.InvoiceTypes.FindAsync(invoiceTypeId);
            if (invoiceType != null)
            {
                return new InvoiceTypeListViewModel(invoiceType);
            }
            throw new Exception("InvoiceType not found");
        }

        public async Task Update(InvoiceTypeListViewModel viewModel)
        {
            var invoiceType = await _applicationDbContext.InvoiceTypes.FindAsync(viewModel.InvoiceTypeId);
            if (invoiceType != null)
            {

                invoiceType.InvoiceTypeName = viewModel.InvoiceTypeName;
                invoiceType.Description = viewModel.Description;
                await _applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
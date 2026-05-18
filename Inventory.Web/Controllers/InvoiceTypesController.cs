using Inventory.Repository.InvoiceTypeService;
using Inventory.ViewModel.InvoiceViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class InvoiceTypesController : Controller
    {
        private readonly IInvoiceTypeRepo _invoiceTypeRepo;

        public InvoiceTypesController(IInvoiceTypeRepo invoiceTypeRepo)
        {
            _invoiceTypeRepo = invoiceTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var invoiceTypes = await _invoiceTypeRepo.GetAll(pageNumber, pageSize);
            return View(invoiceTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceTypeListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _invoiceTypeRepo.Add(viewModel);
                //await _invoiceTypeRepo.AddByStoredProcedure(viewModel);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int invoiceTypeId)
        {
            var invoiceType = await _invoiceTypeRepo.GetById(invoiceTypeId);
            return View(invoiceType);
        }

        [HttpPost]
        public async Task<IActionResult> Update(InvoiceTypeListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _invoiceTypeRepo.Update(viewModel);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int invoiceTypeId)
        {
            await _invoiceTypeRepo.Delete(invoiceTypeId);
            return RedirectToAction("Index");
        }    
    }
}

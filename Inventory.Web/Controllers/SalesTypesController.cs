using Inventory.Repository.SalesTypeService;
using Inventory.ViewModel.SalesViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class SalesTypesController : Controller
    {
        private readonly ISalesTypeService _salesTypeService;

        public SalesTypesController(ISalesTypeService salesTypeService)
        {
            _salesTypeService = salesTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var salesTypes = await _salesTypeService.GetAll(pageNumber, pageSize);
            return View(salesTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalesTypeListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _salesTypeService.Add(viewModel);
                //await _salesTypeService.AddByStoredProcedure(viewModel);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int salesTypeId)
        {
            var salesType = await _salesTypeService.GetById(salesTypeId);
            return View(salesType);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SalesTypeListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _salesTypeService.Update(viewModel);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int salesTypeId)
        {
            await _salesTypeService.Delete(salesTypeId);
            return RedirectToAction("Index");
        }
    }
}

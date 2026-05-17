using Inventory.Repository.BillTypeService;
using Inventory.ViewModel.BillViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class BillTypeController : Controller
    {
        private readonly IBillTypeRepo _billTypeRepo;

        public BillTypeController(IBillTypeRepo billTypeRepo)
        {
            _billTypeRepo = billTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var billTypes = await _billTypeRepo.GetAll(pageNumber, pageSize);
            return View(billTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BillTypeListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //await _billTypeRepo.Add(viewModel);
                await _billTypeRepo.AddByStoredProcedure(viewModel);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int billTypeId)
        {
            var billType = await _billTypeRepo.GetById(billTypeId);
            return View(billType);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BillTypeListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _billTypeRepo.Update(viewModel);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int billTypeId)
        {
            await _billTypeRepo.Delete(billTypeId);
            return RedirectToAction("Index");
        }
    }
}

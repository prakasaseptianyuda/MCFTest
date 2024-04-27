using MCF.Web.Models;
using MCF.Web.Services.IServices;
using MCF.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MCF.Web.Controllers
{
    [Authorize]
    public class TrBpkbController : Controller
    {
        private readonly IBpkbService _bpkbService;
        private readonly IStorageLocationService _storageLocationService;

        public TrBpkbController(IBpkbService bpkbService,IStorageLocationService storageLocationService)
        {
            _bpkbService = bpkbService;
            _storageLocationService = storageLocationService;
        }
        public async Task<IActionResult> Index()
        {
            List<TrBpkbDto>? list = new();

            ResponseDto? response = await _bpkbService.GetAllTrBpkb();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<TrBpkbDto>>(response.Result?.ToString());
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public async Task<IActionResult> TrBpkbCreate() {

            ViewBag.StorageLocations = await GetDropdownLocation();

            return View();
		}

        [HttpPost]
        public async Task<IActionResult> TrBpkbCreate(TrBpkbDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _bpkbService.Create(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "data created successfuly!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;

                    ViewBag.StorageLocations = await GetDropdownLocation();
                }
            }
            return View(model);
        }

        public async Task<IActionResult> TrBpkbEdit(string agreementNumber)
        {
            ResponseDto? response = await _bpkbService.GetTrBpkbById(agreementNumber);

            if (response != null && response.IsSuccess)
            {
                ViewBag.StorageLocations = await GetDropdownLocation();
                TrBpkbDto? model = JsonConvert.DeserializeObject<TrBpkbDto>(response.Result.ToString());
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> TrBpkbEdit(TrBpkbDto trBpkbDto)
        {
            ResponseDto? response = await _bpkbService.Update(trBpkbDto);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "data updated successfuly!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
				ViewBag.StorageLocations = await GetDropdownLocation();
			}
            return View(trBpkbDto);
        }

        [NonAction]
        private async Task<List<SelectListItem>> GetDropdownLocation() {

            ResponseDto? response = await _storageLocationService.GetAllStorageLocation();
            var storageLocations = JsonConvert.DeserializeObject<List<StorageLocationDto>>(response.Result.ToString());

            var storageLocationList = new List<SelectListItem>();

            foreach (var item in storageLocations)
            {
                storageLocationList.Add(new SelectListItem { Text = item.LocationName, Value = item.LocationId });
            }

            return storageLocationList;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Task4Linkerp.Models.Srvices;
using Task4Linkerp.Models;
using Task4Linkerp.ViewModel.Region;

namespace Task4Linkerp.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRepository<Region> _regionRepository;
        private readonly IRepository<City> _cityRepository;
      

        public RegionController(IRepository<Region> regionRepository, IRepository<City> cityRepository)
        {
            _regionRepository = regionRepository;
            _cityRepository= cityRepository;
           
        }
        public IActionResult Index(string? searchString)
        {
            IEnumerable<Region> regions =_regionRepository.GetAll();
            List<AllRegionsViewModel> allRegions = new List<AllRegionsViewModel>();
            foreach(var region in regions)
            {
                allRegions.Add(new AllRegionsViewModel(region.Id,region.Code, region.NameEN, region.NameAR));
            }


            return View(allRegions);
        }
        public IActionResult Create()
        {
            ViewBag.Cities = _cityRepository.GetAll();

            return View();
        }
        [HttpPost]

        public IActionResult Create(AddRegionVeiwModel addRegionVeiwModel)
        {


            try
            {
                Region region = new Region(addRegionVeiwModel.Code, addRegionVeiwModel.NameEN, addRegionVeiwModel.NameAR, addRegionVeiwModel.CityId);
                _regionRepository.Create(region);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(addRegionVeiwModel);
            }

        }
        public IActionResult Details(int id)
        {


            try
            {
                Region? region = _regionRepository.GetById(id);
                if (region != null)
                {
                    ViewBag.City = region.City;
                    return View(new DetailsRegionViewModel(region.Id, region.Code, region.NameEN, region.NameAR));
                }
                    
               
                return View(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }

        }
       
        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
                return View(id);

            try
            {
                Region? region= _regionRepository.GetById(id);
                if (region != null)
                    return View(region);
                return View(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }
        }
        [HttpPost]
        public IActionResult Edit(Region region)
        {
            try
            {
                _regionRepository.Update(region);
                  return RedirectToAction("Index");
               
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(region);
            }
        }
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }
            try
            {
                _regionRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }

        }
    }
}

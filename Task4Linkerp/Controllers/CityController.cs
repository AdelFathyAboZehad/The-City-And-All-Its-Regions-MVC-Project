using Microsoft.AspNetCore.Mvc;
using Task4Linkerp.Models.Srvices;
using Task4Linkerp.Models;
using Task4Linkerp.ViewModel.City;

namespace Task4Linkerp.Controllers
{
    public class CityController : Controller
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Region> _regionRepository;

        public CityController(IRepository<City> cityRepository,IRepository<Region> regionRepository)
        {
            _cityRepository = cityRepository;
            _regionRepository = regionRepository;
        }

        public async Task<IActionResult> Index(string? searchString)
        {

           var cities = await _cityRepository.FilterByAsync(searchString);
            var cityViewModels=new List<AllCitiesViewModel>();

            foreach(var city in cities)
            {
                cityViewModels.Add(new AllCitiesViewModel(city.Id, city.Code, city.NameEN,city.NameAR));
            }

            return View(cityViewModels);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CityViewModel cityViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(cityViewModel);
            }

            try
            {
                City city=new City(cityViewModel.Code,cityViewModel.NameEN,cityViewModel.NameAR,cityViewModel.Active,cityViewModel.Notes);

                _cityRepository.Create(city);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cityViewModel);
            }

        }
        public IActionResult Details(int id)
        {
            if (!ModelState.IsValid)
                return View(id);
            try
            {
                City? city = _cityRepository.GetById(id);
                if (city != null)
                {
                    ViewBag.Regions = city.Regions;
                    DetailsCityViewModel detailsCityViewModel = new DetailsCityViewModel(city.Id,city.Code, city.NameEN, city.NameAR, city.Active, city.Notes);
                    return View(detailsCityViewModel);  
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
                City? city = _cityRepository.GetById(id);
                if (city != null)
                    return View(city);
                
                return View(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }
        }
        [HttpPost]
        public IActionResult Edit(City city)
        {

            if (!ModelState.IsValid)
                return View(city);
            try
            {
                _cityRepository.Update(city);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(city);
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
                _cityRepository.Delete(id);
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

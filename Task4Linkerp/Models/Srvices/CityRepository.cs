using Microsoft.EntityFrameworkCore;
namespace Task4Linkerp.Models.Srvices
{
    public class CityRepository:IRepository<City>
    {
        private readonly DBContext _context;

        public CityRepository(DBContext context)
        {
            _context = context;
        }
        public IEnumerable<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        public City? GetById(int id)
        {
            return _context.Cities.Include(x => x.Regions).FirstOrDefault(_c => _c.Id == id);
        }
        public City Create(City item)
        {
            _context.Cities.Add(item);
            _context.SaveChanges();
            return item;
        }
        public bool Update(City item)
        {

            _context.Cities.Update(item);
            _context.SaveChanges();
            return true;

        }

        public bool Delete(int id)
        {
            var cat = _context.Cities.FirstOrDefault(c => c.Id == id);
            _context.Cities.Remove(cat);
            _context.SaveChanges();
            return true;

        }

        public Task<IEnumerable<City>> FilterByAsync(string? filter = null, int? code = null)
        {

            IEnumerable<City> FilterCitiesQuery =
                _context.Cities.Include(x => x.Regions)
                .Where(a => filter == null || a.NameEN.ToLower().Contains(filter.ToLower()) ||a.NameAR.ToLower().Contains(filter.ToLower()));

            return Task.FromResult(FilterCitiesQuery);

        }
    }
}

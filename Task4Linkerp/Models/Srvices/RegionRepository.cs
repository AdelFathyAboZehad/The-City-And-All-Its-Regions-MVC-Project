using Microsoft.EntityFrameworkCore;

namespace Task4Linkerp.Models.Srvices
{
    public class RegionRepository : IRepository<Region>
    {
        private readonly DBContext _context;

        public RegionRepository(DBContext context)
        {
            _context = context;
        }
        public IEnumerable<Region> GetAll()
        {
            return _context.Regions.ToList();
        }
        public Region? GetById(int id)
        {
            return _context.Regions.Include(c=>c.City).FirstOrDefault(_c => _c.Id == id);
        }
        public Region Create(Region item)
        {
            _context.Regions.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool Delete(int id)
        {
            var cat = _context.Regions.FirstOrDefault(c => c.Id == id);
            _context.Regions.Remove(cat);
            _context.SaveChanges();
            return true;
        }
        public bool Update(Region item)
        {
            _context.Regions.Update(item);
            _context.SaveChanges();
            return true;
        }
        public Task<IEnumerable<Region>> FilterByAsync(string? filter = null, int? code = null)
        {

            IEnumerable<Region> FilterCitiesQuery =
                _context.Regions.Where(a => filter == null || a.NameEN.ToLower().Contains(filter.ToLower()) || a.NameAR.ToLower().Contains(filter.ToLower()));

            return Task.FromResult(FilterCitiesQuery);

        }
    }
}

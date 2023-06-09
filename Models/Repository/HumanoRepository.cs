using DemoDotnetApi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoDotnetApi.Models.Repository
{
    public class HumanoRepository : IHumanoRepository
    {
        protected readonly DemoContext _context;
        public HumanoRepository(DemoContext context) => _context = context;

        public async Task<Humano> CreateHumanoAsync(Humano humano)
        {
            await _context.Set<Humano>().AddAsync(humano);
            await _context.SaveChangesAsync();
            return humano;
        }

        public async Task<bool> DeleteHumanoAsync(Humano humano)
        {
            //var entity = await GetByIdAsync(id);
            if (humano is null)
            {
                return false;
            }

            _context.Set<Humano>().Remove(humano);
            await _context.SaveChangesAsync();

            return true;
        }

        public Humano GetHumanoById(int id)
        {   
            return _context.Humanos.Find(id);
        }

        public IEnumerable<Humano> GetHumanos()
        {
            return _context.Humanos.ToList();
        }

        public async Task<bool> UpdateHumanoAsync(Humano humano)
        {
            _context.Entry(humano).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

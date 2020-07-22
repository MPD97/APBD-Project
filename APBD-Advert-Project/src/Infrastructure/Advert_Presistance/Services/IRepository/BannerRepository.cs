using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advert.Database.Contexts;
using Advert.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Advert.Presistance.Services.IRepository
{
    public class BannerRepository : IBannerRepository
    {
        private readonly AdvertContext _context;

        public BannerRepository(AdvertContext context)
        {
            _context = context;
        }

        public IEnumerable<Banner> GetAll()
        {
            return _context.Banners.AsEnumerable();
        }

        public async Task<Banner> FindByIdAsync(int id)
        {
            return await _context.Banners.SingleOrDefaultAsync(b => b.IdAdvertisment == id);
        }

        public async Task Insert(Banner banner)
        {
            await _context.Banners.AddAsync(banner);
        }

        public async Task Insert(IEnumerable<Banner> banners)
        {
            await _context.Banners.AddRangeAsync(banners);
        }

        public async Task<bool> Delete(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner == null) return false;

            _context.Banners.Remove(banner);
            return true;
        }

        public void Update(Banner banner)
        {
            _context.Entry(banner).State = EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
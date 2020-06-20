using Advert.Database.DTOs.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Advert.Database.Contexts;
using Advert.Database.Entities;

namespace Advert.Presistance.Services.IBannerQuery
{
    public class BannerQueryService : IBannerQueryService
    {
        private readonly AdvertContext _context;

        public BannerQueryService(AdvertContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Banner>> GetAllAsync(int id)
        {
            return await _context.Banners.ToArrayAsync();
        }

        public async Task<Banner> GetAsync(int id)
        {
            return await _context.Banners.FirstOrDefaultAsync(b => b.IdAdvertisment == id);
        }
    }
}

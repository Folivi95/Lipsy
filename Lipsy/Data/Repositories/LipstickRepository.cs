using Lipsy.Interfaces;
using Lipsy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lipsy.Data.Repositories
{
    public class LipstickRepository : ILipstickRepository
    {
        private readonly AppDbContext appDbContext;
        public LipstickRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Lipstick> Lipsticks => appDbContext.Lipsticks.Include(c => c.Category);
        public IEnumerable<Lipstick> PreferredLipsticks { get => appDbContext.Lipsticks.Where(p => p.IsPreferredLipstick).Include(c => c.Category); }

        public Lipstick GetLipstickById(int LipstickId)
        {
            return appDbContext.Lipsticks.FirstOrDefault(p => p.LipstickId == LipstickId);
        }
    }
}

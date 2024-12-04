using Conway.InterimPods.Core.Abstractions;
using Conway.InterimPods.Core.Entities;
using Conway.InterimPods.Core.Interfaces;
using Conway.InterimPods.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Conway.InterimPods.Infrastructure.Repositories
{
    public class PodScanRepository : IPodScanRepository
    {
        private readonly PodScansDbContext _context;
        //private readonly IAppLogger<PoDScanRepository>
        //_appLogger;

        public PodScanRepository(
            PodScansDbContext context
            //IAppLogger<PoDScanService<PodScan>> appLogger
            )
        {
            _context = context;
            //_appLogger = appLogger;
        }

        public async Task<PodScan?> GetPodScanByIdAsync(int id)
        {
            return await _context.PodScans.FirstOrDefaultAsync(scan => scan.Id == id);
        }

        public async Task<IEnumerable<PodScan>> GetAllPodScansAsync()
        {
            return await _context.PodScans.ToListAsync();
        }

        public async Task<IEnumerable<PodScan>> FindPodScansAsync(Expression<Func<PodScan, bool>> predicate)
        {
            return await _context.PodScans.Where(predicate).ToListAsync();
        }

        public async Task<PodScan> AddPodScanAsync(PodScan entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
                //throw new NotImplementedException("Can't add PodScans from here!");
            }
            catch (Exception ex)
            {
                throw new RepositoryException("An error occurred accessing the database", ex);
            }

        }

        public async Task<PodScan> UpdatePodScanAsync(PodScan entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
                //throw new NotImplementedException("Can't update PodScans from here!");
            }
            catch (Exception ex)
            {
                throw new RepositoryException("An error occurred accessing the database", ex);
            }

        }

        public async Task<bool> DeletePodScanAsync(PodScan entity)
        {
            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _context.Attach(entity);
                }
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
                //throw new NotImplementedException("Can't delete PodScans from here!");
            }
            catch (Exception ex)
            {
                throw new RepositoryException("An error occurred accessing the database.", ex);
            }
        }

    }
}

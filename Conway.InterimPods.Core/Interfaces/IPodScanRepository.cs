using Conway.InterimPods.Core.Entities;
using System.Linq.Expressions;

namespace Conway.InterimPods.Core.Interfaces
{
    public interface IPodScanRepository
    {
        Task<IEnumerable<PodScan>> GetAllPodScansAsync();

        Task<IEnumerable<PodScan>> FindPodScansAsync(Expression<Func<PodScan, bool>> predicate);

        Task<PodScan> AddPodScanAsync(PodScan item);

        Task<PodScan> UpdatePodScanAsync(PodScan item);

        Task<bool> DeletePodScanAsync(PodScan item);

        Task<PodScan?> GetPodScanByIdAsync(int itemId);
    }
}

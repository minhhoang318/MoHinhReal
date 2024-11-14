using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INCCService
    {
        Task<IEnumerable<NCCDTO>> GetAllNCCAsync();
        Task<NCCDTO> GetNCCByIdAsync(int id);
        Task AddNCCAsync(NCCDTO nccDto);
        Task UpdateNCCAsync(int id, NCCDTO nccDto);
        Task DeleteNCCAsync(int id);
    }
}

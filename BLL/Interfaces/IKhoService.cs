using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IKhoService
    {
        Task<IEnumerable<KhoDTO>> GetAllKhoAsync();
        Task<KhoDTO> GetKhoByIdAsync(int id);
        Task AddKhoAsync(KhoDTO khoDto);
        Task UpdateKhoAsync(int id, KhoDTO khoDto);
        Task DeleteKhoAsync(int id);
    }
}

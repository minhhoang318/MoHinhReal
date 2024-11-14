using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICTDonNhapService
    {
        Task<IEnumerable<CTDonNhapDTO>> GetAllCTDonNhapAsync();
        Task<CTDonNhapDTO> GetCTDonNhapByIdAsync(int id);
        Task AddCTDonNhapAsync(CTDonNhapDTO ctDonNhapDto);
        Task UpdateCTDonNhapAsync(int id, CTDonNhapDTO ctDonNhapDto);
        Task DeleteCTDonNhapAsync(int id);
    }
}

using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDonNhapService
    {
        Task<IEnumerable<DonNhapDTO>> GetAllDonNhapAsync();
        Task<DonNhapDTO> GetDonNhapByIdAsync(int id);
        Task AddDonNhapAsync(DonNhapDTO donNhapDto);
        Task UpdateDonNhapAsync(int id, DonNhapDTO donNhapDto);
        Task DeleteDonNhapAsync(int id);
    }
}

using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDonHangService
    {
        Task<IEnumerable<DonHangDTO>> GetAllDonHangAsync();
        Task<DonHangDTO> GetDonHangByIdAsync(int id);
        Task AddDonHangAsync(DonHangDTO donHangDto);
        Task UpdateDonHangAsync(int id, DonHangDTO donHangDto);
        Task DeleteDonHangAsync(int id);
    }
}

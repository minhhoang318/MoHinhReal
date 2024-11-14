using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICTDonHangService
    {
        Task<IEnumerable<CTDonHangDTO>> GetAllCTDonHangAsync();
        Task<CTDonHangDTO> GetCTDonHangByIdAsync(int id);
        Task AddCTDonHangAsync(CTDonHangDTO ctDonHangDto);
        Task UpdateCTDonHangAsync(int id, CTDonHangDTO ctDonHangDto);
        Task DeleteCTDonHangAsync(int id);
    }
}

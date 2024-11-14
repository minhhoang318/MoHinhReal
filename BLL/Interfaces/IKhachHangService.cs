using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IKhachHangService
    {
        Task<IEnumerable<KhachHangDTO>> GetAllKhachHangAsync();
        Task<KhachHangDTO> GetKhachHangByIdAsync(int id);
        Task AddKhachHangAsync(KhachHangDTO khachHangDto);
        Task UpdateKhachHangAsync(int id, KhachHangDTO khachHangDto);
        Task DeleteKhachHangAsync(int id);
    }
}

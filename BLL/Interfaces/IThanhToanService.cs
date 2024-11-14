using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IThanhToanService
    {
        Task<IEnumerable<ThanhToanDTO>> GetAllThanhToanAsync();
        Task<ThanhToanDTO> GetThanhToanByIdAsync(int id);
        Task AddThanhToanAsync(ThanhToanDTO thanhToanDto);
        Task UpdateThanhToanAsync(int id, ThanhToanDTO thanhToanDto);
        Task DeleteThanhToanAsync(int id);
    }
}

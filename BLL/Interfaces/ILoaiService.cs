using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILoaiService
    {
        Task<IEnumerable<LoaiDTO>> GetAllLoaiAsync();
        Task<LoaiDTO> GetLoaiByIdAsync(int id);
        Task AddLoaiAsync(LoaiDTO loaiDto);
        Task UpdateLoaiAsync(int id, LoaiDTO loaiDto);
        Task DeleteLoaiAsync(int id);
    }
}

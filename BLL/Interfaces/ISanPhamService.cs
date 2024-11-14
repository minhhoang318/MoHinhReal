using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISanPhamService
    {
        Task<IEnumerable<SanPhamDTO>> GetAllSanPhamAsync();
        Task<SanPhamDTO> GetSanPhamByIdAsync(int id);
        Task AddSanPhamAsync(SanPhamDTO sanPhamDto);
        Task UpdateSanPhamAsync(int id, SanPhamDTO sanPhamDto);
        Task DeleteSanPhamAsync(int id);
    }
}

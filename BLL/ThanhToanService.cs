using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class ThanhToanService : IThanhToanService
    {
        private readonly IThanhToanRepository _thanhToanRepository;

        public ThanhToanService(IThanhToanRepository thanhToanRepository)
        {
            _thanhToanRepository = thanhToanRepository;
        }

        public async Task<IEnumerable<ThanhToanDTO>> GetAllThanhToanAsync()
        {
            var thanhToanList = await _thanhToanRepository.GetAllAsync();
            return thanhToanList.Select(tt => new ThanhToanDTO
            {
                ThanhToanID = tt.ThanhToanID,
                DonHangID = tt.DonHangID,
                PhuongThuc = tt.PhuongThuc,
                NgayThanhToan = tt.NgayThanhToan
            }).ToList();
        }

        public async Task<ThanhToanDTO> GetThanhToanByIdAsync(int id)
        {
            var thanhToan = await _thanhToanRepository.GetByIdAsync(id);
            if (thanhToan == null) return null;

            return new ThanhToanDTO
            {
                ThanhToanID = thanhToan.ThanhToanID,
                DonHangID = thanhToan.DonHangID,
                PhuongThuc = thanhToan.PhuongThuc,
                NgayThanhToan = thanhToan.NgayThanhToan
            };
        }

        public async Task AddThanhToanAsync(ThanhToanDTO thanhToanDto)
        {
            var thanhToan = new ThanhToan
            {
                DonHangID = thanhToanDto.DonHangID,
                PhuongThuc = thanhToanDto.PhuongThuc,
                NgayThanhToan = thanhToanDto.NgayThanhToan
            };
            await _thanhToanRepository.AddAsync(thanhToan);
            await _thanhToanRepository.SaveAsync();
        }

        public async Task UpdateThanhToanAsync(int id, ThanhToanDTO thanhToanDto)
        {
            var thanhToan = await _thanhToanRepository.GetByIdAsync(id);
            if (thanhToan == null) return;

            thanhToan.PhuongThuc = thanhToanDto.PhuongThuc;
            thanhToan.NgayThanhToan = thanhToanDto.NgayThanhToan;

            _thanhToanRepository.Update(thanhToan);
            await _thanhToanRepository.SaveAsync();
        }

        public async Task DeleteThanhToanAsync(int id)
        {
            var thanhToan = await _thanhToanRepository.GetByIdAsync(id);
            if (thanhToan == null) return;

            _thanhToanRepository.Delete(thanhToan);
            await _thanhToanRepository.SaveAsync();
        }
    }
}

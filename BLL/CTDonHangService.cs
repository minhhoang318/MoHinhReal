using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class CTDonHangService : ICTDonHangService
    {
        private readonly ICTDonHangRepository _ctDonHangRepository;

        public CTDonHangService(ICTDonHangRepository ctDonHangRepository)
        {
            _ctDonHangRepository = ctDonHangRepository;
        }

        public async Task<IEnumerable<CTDonHangDTO>> GetAllCTDonHangAsync()
        {
            var ctDonHangList = await _ctDonHangRepository.GetAllAsync();
            return ctDonHangList.Select(ct => new CTDonHangDTO
            {
                CTDonHangID = ct.CTDonHangID,
                DonHangID = ct.DonHangID,
                SanPhamID = ct.SanPhamID,
                SoLuong = ct.SoLuong,
                GiaBan = ct.GiaBan
            }).ToList();
        }

        public async Task<CTDonHangDTO> GetCTDonHangByIdAsync(int id)
        {
            var ctDonHang = await _ctDonHangRepository.GetByIdAsync(id);
            if (ctDonHang == null) return null;

            return new CTDonHangDTO
            {
                CTDonHangID = ctDonHang.CTDonHangID,
                DonHangID = ctDonHang.DonHangID,
                SanPhamID = ctDonHang.SanPhamID,
                SoLuong = ctDonHang.SoLuong,
                GiaBan = ctDonHang.GiaBan
            };
        }

        public async Task AddCTDonHangAsync(CTDonHangDTO ctDonHangDto)
        {
            var ctDonHang = new CTDonHang
            {
                DonHangID = ctDonHangDto.DonHangID,
                SanPhamID = ctDonHangDto.SanPhamID,
                SoLuong = ctDonHangDto.SoLuong,
                GiaBan = ctDonHangDto.GiaBan
            };
            await _ctDonHangRepository.AddAsync(ctDonHang);
            await _ctDonHangRepository.SaveAsync();
        }

        public async Task UpdateCTDonHangAsync(int id, CTDonHangDTO ctDonHangDto)
        {
            var ctDonHang = await _ctDonHangRepository.GetByIdAsync(id);
            if (ctDonHang == null) return;

            ctDonHang.SoLuong = ctDonHangDto.SoLuong;
            ctDonHang.GiaBan = ctDonHangDto.GiaBan;

            _ctDonHangRepository.Update(ctDonHang);
            await _ctDonHangRepository.SaveAsync();
        }

        public async Task DeleteCTDonHangAsync(int id)
        {
            var ctDonHang = await _ctDonHangRepository.GetByIdAsync(id);
            if (ctDonHang == null) return;

            _ctDonHangRepository.Delete(ctDonHang);
            await _ctDonHangRepository.SaveAsync();
        }
    }
}

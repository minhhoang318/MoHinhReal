using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class CTDonNhapService : ICTDonNhapService
    {
        private readonly ICTDonNhapRepository _ctDonNhapRepository;

        public CTDonNhapService(ICTDonNhapRepository ctDonNhapRepository)
        {
            _ctDonNhapRepository = ctDonNhapRepository;
        }

        public async Task<IEnumerable<CTDonNhapDTO>> GetAllCTDonNhapAsync()
        {
            var ctDonNhapList = await _ctDonNhapRepository.GetAllAsync();
            return ctDonNhapList.Select(ct => new CTDonNhapDTO
            {
                CTDonNhapID = ct.CTDonNhapID,
                DonNhapID = ct.DonNhapID,
                SanPhamID = ct.SanPhamID,
                SoLuong = ct.SoLuong,
                GiaNhap = ct.GiaNhap
            }).ToList();
        }

        public async Task<CTDonNhapDTO> GetCTDonNhapByIdAsync(int id)
        {
            var ctDonNhap = await _ctDonNhapRepository.GetByIdAsync(id);
            if (ctDonNhap == null) return null;

            return new CTDonNhapDTO
            {
                CTDonNhapID = ctDonNhap.CTDonNhapID,
                DonNhapID = ctDonNhap.DonNhapID,
                SanPhamID = ctDonNhap.SanPhamID,
                SoLuong = ctDonNhap.SoLuong,
                GiaNhap = ctDonNhap.GiaNhap
            };
        }

        public async Task AddCTDonNhapAsync(CTDonNhapDTO ctDonNhapDto)
        {
            var ctDonNhap = new CTDonNhap
            {
                DonNhapID = ctDonNhapDto.DonNhapID,
                SanPhamID = ctDonNhapDto.SanPhamID,
                SoLuong = ctDonNhapDto.SoLuong,
                GiaNhap = ctDonNhapDto.GiaNhap
            };
            await _ctDonNhapRepository.AddAsync(ctDonNhap);
            await _ctDonNhapRepository.SaveAsync();
        }

        public async Task UpdateCTDonNhapAsync(int id, CTDonNhapDTO ctDonNhapDto)
        {
            var ctDonNhap = await _ctDonNhapRepository.GetByIdAsync(id);
            if (ctDonNhap == null) return;

            ctDonNhap.SoLuong = ctDonNhapDto.SoLuong;
            ctDonNhap.GiaNhap = ctDonNhapDto.GiaNhap;

            _ctDonNhapRepository.Update(ctDonNhap);
            await _ctDonNhapRepository.SaveAsync();
        }

        public async Task DeleteCTDonNhapAsync(int id)
        {
            var ctDonNhap = await _ctDonNhapRepository.GetByIdAsync(id);
            if (ctDonNhap == null) return;

            _ctDonNhapRepository.Delete(ctDonNhap);
            await _ctDonNhapRepository.SaveAsync();
        }
    }
}

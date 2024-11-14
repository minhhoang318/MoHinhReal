using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class DonNhapService : IDonNhapService
    {
        private readonly IDonNhapRepository _donNhapRepository;

        public DonNhapService(IDonNhapRepository donNhapRepository)
        {
            _donNhapRepository = donNhapRepository;
        }

        public async Task<IEnumerable<DonNhapDTO>> GetAllDonNhapAsync()
        {
            var donNhapList = await _donNhapRepository.GetAllAsync();
            return donNhapList.Select(dn => new DonNhapDTO
            {
                DonNhapID = dn.DonNhapID,
                NgayNhapHang = dn.NgayNhapHang,
                NCCID = dn.NCCID,
                TrangThai = dn.TrangThai
            }).ToList();
        }

        public async Task<DonNhapDTO> GetDonNhapByIdAsync(int id)
        {
            var donNhap = await _donNhapRepository.GetByIdAsync(id);
            if (donNhap == null) return null;

            return new DonNhapDTO
            {
                DonNhapID = donNhap.DonNhapID,
                NgayNhapHang = donNhap.NgayNhapHang,
                NCCID = donNhap.NCCID,
                TrangThai = donNhap.TrangThai
            };
        }

        public async Task AddDonNhapAsync(DonNhapDTO donNhapDto)
        {
            var donNhap = new DonNhap
            {
                NgayNhapHang = donNhapDto.NgayNhapHang,
                NCCID = donNhapDto.NCCID,
                TrangThai = donNhapDto.TrangThai
            };
            await _donNhapRepository.AddAsync(donNhap);
            await _donNhapRepository.SaveAsync();
        }

        public async Task UpdateDonNhapAsync(int id, DonNhapDTO donNhapDto)
        {
            var donNhap = await _donNhapRepository.GetByIdAsync(id);
            if (donNhap == null) return;

            donNhap.NgayNhapHang = donNhapDto.NgayNhapHang;
            donNhap.NCCID = donNhapDto.NCCID;
            donNhap.TrangThai = donNhapDto.TrangThai;

            _donNhapRepository.Update(donNhap);
            await _donNhapRepository.SaveAsync();
        }

        public async Task DeleteDonNhapAsync(int id)
        {
            var donNhap = await _donNhapRepository.GetByIdAsync(id);
            if (donNhap == null) return;

            _donNhapRepository.Delete(donNhap);
            await _donNhapRepository.SaveAsync();
        }
    }
}

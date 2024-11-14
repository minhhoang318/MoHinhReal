using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class DonHangService : IDonHangService
    {
        private readonly IDonHangRepository _donHangRepository;

        public DonHangService(IDonHangRepository donHangRepository)
        {
            _donHangRepository = donHangRepository;
        }

        public async Task<IEnumerable<DonHangDTO>> GetAllDonHangAsync()
        {
            var donHangList = await _donHangRepository.GetAllAsync();
            return donHangList.Select(dh => new DonHangDTO
            {
                DonHangID = dh.DonHangID,
                KhachHangID = dh.KhachHangID,
                NgayDat = dh.NgayDat,
                TongTien = dh.TongTien,
                TrangThai = dh.TrangThai
            }).ToList();
        }

        public async Task<DonHangDTO> GetDonHangByIdAsync(int id)
        {
            var donHang = await _donHangRepository.GetByIdAsync(id);
            if (donHang == null) return null;

            return new DonHangDTO
            {
                DonHangID = donHang.DonHangID,
                KhachHangID = donHang.KhachHangID,
                NgayDat = donHang.NgayDat,
                TongTien = donHang.TongTien,
                TrangThai = donHang.TrangThai
            };
        }

        public async Task AddDonHangAsync(DonHangDTO donHangDto)
        {
            var donHang = new DonHang
            {
                KhachHangID = donHangDto.KhachHangID,
                NgayDat = donHangDto.NgayDat,
                TongTien = donHangDto.TongTien,
                TrangThai = donHangDto.TrangThai
            };
            await _donHangRepository.AddAsync(donHang);
            await _donHangRepository.SaveAsync();
        }

        public async Task UpdateDonHangAsync(int id, DonHangDTO donHangDto)
        {
            var donHang = await _donHangRepository.GetByIdAsync(id);
            if (donHang == null) return;

            donHang.KhachHangID = donHangDto.KhachHangID;
            donHang.NgayDat = donHangDto.NgayDat;
            donHang.TongTien = donHangDto.TongTien;
            donHang.TrangThai = donHangDto.TrangThai;

            _donHangRepository.Update(donHang);
            await _donHangRepository.SaveAsync();
        }

        public async Task DeleteDonHangAsync(int id)
        {
            var donHang = await _donHangRepository.GetByIdAsync(id);
            if (donHang == null) return;

            _donHangRepository.Delete(donHang);
            await _donHangRepository.SaveAsync();
        }
    }
}

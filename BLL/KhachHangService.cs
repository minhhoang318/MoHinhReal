using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachHangService : IKhachHangService
    {
        private readonly IKhachHangRepository _khachHangRepository;

        public KhachHangService(IKhachHangRepository khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;
        }

        public async Task<IEnumerable<KhachHangDTO>> GetAllKhachHangAsync()
        {
            var khachHangList = await _khachHangRepository.GetAllAsync();
            return khachHangList.Select(kh => new KhachHangDTO
            {
                KhachHangID = kh.KhachHangID,
                HoTen = kh.HoTen,
                Email = kh.Email,
                SDT = kh.SDT,
                DiaChi = kh.DiaChi
            }).ToList();
        }

        public async Task<KhachHangDTO> GetKhachHangByIdAsync(int id)
        {
            var khachHang = await _khachHangRepository.GetByIdAsync(id);
            if (khachHang == null) return null;

            return new KhachHangDTO
            {
                KhachHangID = khachHang.KhachHangID,
                HoTen = khachHang.HoTen,
                Email = khachHang.Email,
                SDT = khachHang.SDT,
                DiaChi = khachHang.DiaChi
            };
        }

        public async Task AddKhachHangAsync(KhachHangDTO khachHangDto)
        {
            var khachHang = new KhachHang
            {
                HoTen = khachHangDto.HoTen,
                Email = khachHangDto.Email,
                SDT = khachHangDto.SDT,
                DiaChi = khachHangDto.DiaChi
            };
            await _khachHangRepository.AddAsync(khachHang);
            await _khachHangRepository.SaveAsync();
        }

        public async Task UpdateKhachHangAsync(int id, KhachHangDTO khachHangDto)
        {
            var khachHang = await _khachHangRepository.GetByIdAsync(id);
            if (khachHang == null) return;

            khachHang.HoTen = khachHangDto.HoTen;
            khachHang.Email = khachHangDto.Email;
            khachHang.SDT = khachHangDto.SDT;
            khachHang.DiaChi = khachHangDto.DiaChi;

            _khachHangRepository.Update(khachHang);
            await _khachHangRepository.SaveAsync();
        }

        public async Task DeleteKhachHangAsync(int id)
        {
            var khachHang = await _khachHangRepository.GetByIdAsync(id);
            if (khachHang == null) return;

            _khachHangRepository.Delete(khachHang);
            await _khachHangRepository.SaveAsync();
        }
    }
}

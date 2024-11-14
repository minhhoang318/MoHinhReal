using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamService : ISanPhamService
    {
        private readonly ISanPhamRepository _sanPhamRepository;

        public SanPhamService(ISanPhamRepository sanPhamRepository)
        {
            _sanPhamRepository = sanPhamRepository;
        }

        public async Task<IEnumerable<SanPhamDTO>> GetAllSanPhamAsync()
        {
            var sanPhams = await _sanPhamRepository.GetAllAsync();
            return sanPhams.Select(sp => new SanPhamDTO
            {
                SanPhamID = sp.SanPhamID,
                TenSanPham = sp.TenSanPham,
                GiaBan = sp.GiaBan,
                MotaSanPham = sp.MotaSanPham,
                LoaiID = sp.LoaiID,
                ImageURL = sp.ImageURL
            }).ToList();
        }

        public async Task<SanPhamDTO> GetSanPhamByIdAsync(int id)
        {
            var sanPham = await _sanPhamRepository.GetByIdAsync(id);
            if (sanPham == null) return null;

            return new SanPhamDTO
            {
                SanPhamID = sanPham.SanPhamID,
                TenSanPham = sanPham.TenSanPham,
                GiaBan = sanPham.GiaBan,
                MotaSanPham = sanPham.MotaSanPham,
                LoaiID = sanPham.LoaiID,
                ImageURL = sanPham.ImageURL
            };
        }

        public async Task AddSanPhamAsync(SanPhamDTO sanPhamDto)
        {
            var sanPham = new SanPham
            {
                TenSanPham = sanPhamDto.TenSanPham,
                GiaBan = sanPhamDto.GiaBan,
                MotaSanPham = sanPhamDto.MotaSanPham,
                LoaiID = sanPhamDto.LoaiID,
                ImageURL = sanPhamDto.ImageURL
            };
            await _sanPhamRepository.AddAsync(sanPham);
            await _sanPhamRepository.SaveAsync();
        }

        public async Task UpdateSanPhamAsync(int id, SanPhamDTO sanPhamDto)
        {
            var sanPham = await _sanPhamRepository.GetByIdAsync(id);
            if (sanPham == null) return;

            sanPham.TenSanPham = sanPhamDto.TenSanPham;
            sanPham.GiaBan = sanPhamDto.GiaBan;
            sanPham.MotaSanPham = sanPhamDto.MotaSanPham;
            sanPham.LoaiID = sanPhamDto.LoaiID;
            sanPham.ImageURL = sanPhamDto.ImageURL;

            _sanPhamRepository.Update(sanPham);
            await _sanPhamRepository.SaveAsync();
        }

        public async Task DeleteSanPhamAsync(int id)
        {
            var sanPham = await _sanPhamRepository.GetByIdAsync(id);
            if (sanPham == null) return;

            _sanPhamRepository.Delete(sanPham);
            await _sanPhamRepository.SaveAsync();
        }
    }
}

using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class KhoService : IKhoService
    {
        private readonly IKhoRepository _khoRepository;

        public KhoService(IKhoRepository khoRepository)
        {
            _khoRepository = khoRepository;
        }

        public async Task<IEnumerable<KhoDTO>> GetAllKhoAsync()
        {
            var khoList = await _khoRepository.GetAllAsync();
            return khoList.Select(kho => new KhoDTO
            {
                KhoID = kho.KhoID,
                SanPhamID = kho.SanPhamID,
                SLTon = kho.SLTon,
                NgayNhapKho = kho.NgayNhapKho,
                GiaNhap = kho.GiaNhap,
            }).ToList();
        }

        public async Task<KhoDTO> GetKhoByIdAsync(int id)
        {
            var kho = await _khoRepository.GetByIdAsync(id);
            if (kho == null) return null;

            return new KhoDTO
            {
                KhoID = kho.KhoID,
                SanPhamID = kho.SanPhamID,
                SLTon = kho.SLTon,
                NgayNhapKho = kho.NgayNhapKho,
                GiaNhap = kho.GiaNhap
            };
        }

        public async Task AddKhoAsync(KhoDTO khoDto)
        {
            var kho = new Kho
            {
                SanPhamID = khoDto.SanPhamID,
                SLTon = khoDto.SLTon,
                NgayNhapKho = khoDto.NgayNhapKho,
                GiaNhap = khoDto.GiaNhap
            };
            await _khoRepository.AddAsync(kho);
            await _khoRepository.SaveAsync();
        }

        public async Task UpdateKhoAsync(int id, KhoDTO khoDto)
        {
            var kho = await _khoRepository.GetByIdAsync(id);
            if (kho == null) return;

            kho.SLTon = khoDto.SLTon;
            kho.NgayNhapKho = khoDto.NgayNhapKho;
            kho.GiaNhap = khoDto.GiaNhap;

            _khoRepository.Update(kho);
            await _khoRepository.SaveAsync();
        }

        public async Task DeleteKhoAsync(int id)
        {
            var kho = await _khoRepository.GetByIdAsync(id);
            if (kho == null) return;

            _khoRepository.Delete(kho);
            await _khoRepository.SaveAsync();
        }
    }
}

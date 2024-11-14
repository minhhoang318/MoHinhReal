using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiService : ILoaiService
    {
        private readonly ILoaiRepository _loaiRepository;

        public LoaiService(ILoaiRepository loaiRepository)
        {
            _loaiRepository = loaiRepository;
        }

        public async Task<IEnumerable<LoaiDTO>> GetAllLoaiAsync()
        {
            var loaiList = await _loaiRepository.GetAllAsync();
            return loaiList.Select(loai => new LoaiDTO
            {
                LoaiID = loai.LoaiID,
                TenLoai = loai.TenLoai,
                MotaLoai = loai.MotaLoai,
                ParentID = loai.ParentID
            }).ToList();
        }

        public async Task<LoaiDTO> GetLoaiByIdAsync(int id)
        {
            var loai = await _loaiRepository.GetByIdAsync(id);
            if (loai == null) return null;

            return new LoaiDTO
            {
                LoaiID = loai.LoaiID,
                TenLoai = loai.TenLoai,
                MotaLoai = loai.MotaLoai,
                ParentID = loai.ParentID
            };
        }

        public async Task AddLoaiAsync(LoaiDTO loaiDto)
        {
            var loai = new Loai
            {
                TenLoai = loaiDto.TenLoai,
                MotaLoai = loaiDto.MotaLoai,
                ParentID = loaiDto.ParentID
            };
            await _loaiRepository.AddAsync(loai);
            await _loaiRepository.SaveAsync();
        }

        public async Task UpdateLoaiAsync(int id, LoaiDTO loaiDto)
        {
            var loai = await _loaiRepository.GetByIdAsync(id);
            if (loai == null) return;

            loai.TenLoai = loaiDto.TenLoai;
            loai.MotaLoai = loaiDto.MotaLoai;
            loai.ParentID = loaiDto.ParentID;

            _loaiRepository.Update(loai);
            await _loaiRepository.SaveAsync();
        }

        public async Task DeleteLoaiAsync(int id)
        {
            var loai = await _loaiRepository.GetByIdAsync(id);
            if (loai == null) return;

            _loaiRepository.Delete(loai);
            await _loaiRepository.SaveAsync();
        }
    }
}

using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class NCCService : INCCService
    {
        private readonly INCCRepository _nccRepository;

        public NCCService(INCCRepository nccRepository)
        {
            _nccRepository = nccRepository;
        }

        public async Task<IEnumerable<NCCDTO>> GetAllNCCAsync()
        {
            var nccList = await _nccRepository.GetAllAsync();
            return nccList.Select(ncc => new NCCDTO
            {
                NCCID = ncc.NCCID,
                TenNCC = ncc.TenNCC,
                DiaChi = ncc.DiaChi,
                SDT = ncc.SDT
            }).ToList();
        }

        public async Task<NCCDTO> GetNCCByIdAsync(int id)
        {
            var ncc = await _nccRepository.GetByIdAsync(id);
            if (ncc == null) return null;

            return new NCCDTO
            {
                NCCID = ncc.NCCID,
                TenNCC = ncc.TenNCC,
                DiaChi = ncc.DiaChi,
                SDT = ncc.SDT
            };
        }

        public async Task AddNCCAsync(NCCDTO nccDto)
        {
            var ncc = new NCC
            {
                TenNCC = nccDto.TenNCC,
                DiaChi = nccDto.DiaChi,
                SDT = nccDto.SDT
            };
            await _nccRepository.AddAsync(ncc);
            await _nccRepository.SaveAsync();
        }

        public async Task UpdateNCCAsync(int id, NCCDTO nccDto)
        {
            var ncc = await _nccRepository.GetByIdAsync(id);
            if (ncc == null) return;

            ncc.TenNCC = nccDto.TenNCC;
            ncc.DiaChi = nccDto.DiaChi;
            ncc.SDT = nccDto.SDT;

            _nccRepository.Update(ncc);
            await _nccRepository.SaveAsync();
        }

        public async Task DeleteNCCAsync(int id)
        {
            var ncc = await _nccRepository.GetByIdAsync(id);
            if (ncc == null) return;

            _nccRepository.Delete(ncc);
            await _nccRepository.SaveAsync();
        }
    }
}

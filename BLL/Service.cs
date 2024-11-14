using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interface;
using DAL.Interfaces;

namespace BLL   
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        // Lấy tất cả các đối tượng
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // Lấy đối tượng theo ID
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // Thêm mới đối tượng
        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
        }

        // Cập nhật đối tượng
        public async Task Update(int id, T entity)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null) return;

            // Cập nhật dữ liệu của đối tượng hiện có
            UpdateEntity(existingEntity, entity);

            _repository.Update(existingEntity);
            await _repository.SaveAsync();
        }

        // Xóa đối tượng theo ID
        public async Task Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                _repository.Delete(entity);
                await _repository.SaveAsync();
            }
        }

        // Phương thức cập nhật entity (ghi đè ở các lớp con nếu cần)
        protected virtual void UpdateEntity(T existingEntity, T newEntity)
        {
            // Mặc định không làm gì - lớp con có thể ghi đè để thực hiện cập nhật
        }
    }
}

using Microsoft.EntityFrameworkCore;
using YumBlazor.Data.Repository.IRepository;

namespace YumBlazor.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            try
            {
                await _db.AddAsync(category);
                await _db.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var getCat = await _db.Categories.FindAsync(id);
                if (getCat != null)
                {
                    _db.Categories.Remove(getCat);
                    await _db.SaveChangesAsync();
                    return true;
                }    
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                var getAll = await _db.Categories.ToListAsync();
                if (getAll != null && getAll.Count > 0)
                {
                    return getAll;
                }
                return new List<Category>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            try
            {
                var getById = await _db.Categories.FindAsync(id);
                if (getById != null)
                {
                    return getById;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            try
            {
                var getUpdate = await _db.Categories.FindAsync(category.Id);
                if (getUpdate != null)
                {
                    getUpdate.Name = category.Name;
                    _db.Categories.Update(getUpdate);
                    await _db.SaveChangesAsync();
                    return getUpdate;
                }
                return null; 
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

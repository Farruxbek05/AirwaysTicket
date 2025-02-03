using Airways.Core.Entity;

namespace Airways.DataAccess.Repository
{
    public interface IPersonRepository
    {
        Task<int> CreateAsync(Person person);
        Task<List<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Person person);
        Task<bool> DeleteAsync(int id);
    }

}

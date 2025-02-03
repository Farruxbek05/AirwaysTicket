using Airways.Core.Entity;
using Airways.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airways.DataAccess.Repository.Impl
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataBaseContext _context;

        public PersonRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            _context.Persons.Update(person);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null) return false;

            _context.Persons.Remove(person);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}

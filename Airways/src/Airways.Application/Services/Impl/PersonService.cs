using Airways.Core.Entity;
using Airways.DataAccess.Repository;

namespace Airways.Application.Services.Impl
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreatePerson(string firstName, string lastName)
        {
            var person = new Person { FirstName = firstName, LastName = lastName };
            return await _repository.CreateAsync(person);
        }

        public async Task<List<Person>> GetAllPersons()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdatePerson(int id, string firstName, string lastName)
        {
            var person = await _repository.GetByIdAsync(id);
            if (person == null) return false;

            person.FirstName = firstName;
            person.LastName = lastName;

            return await _repository.UpdateAsync(person);
        }

        public async Task<bool> DeletePerson(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }

}

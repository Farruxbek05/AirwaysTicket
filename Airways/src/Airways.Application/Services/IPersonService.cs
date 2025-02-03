using Airways.Core.Entity;

namespace Airways.Application.Services
{
    public interface IPersonService
    {
        Task<int> CreatePerson(string firstName, string lastName);
        Task<List<Person>> GetAllPersons();
        Task<Person> GetPersonById(int id);
        Task<bool> UpdatePerson(int id, string firstName, string lastName);
        Task<bool> DeletePerson(int id);
    }

}

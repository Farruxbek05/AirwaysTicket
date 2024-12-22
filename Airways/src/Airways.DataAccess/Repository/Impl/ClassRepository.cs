using Airways.Core.Entity;
using Airways.DataAccess.Persistence;

namespace Airways.DataAccess.Repository.Impl
{
    public class ClassRepository:BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(DataBaseContext dataBaseContext) :base(dataBaseContext) { }  
    }
}

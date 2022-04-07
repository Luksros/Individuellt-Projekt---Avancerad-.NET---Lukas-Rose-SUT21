using System.Collections;
using System.Threading.Tasks;

namespace Indivuduellt_Projekt_API.Services
{
    public interface IRepo<T>
    {
        public Task<IEnumerable> GetAll();
        public Task<T> Get(int id);
        public Task<T> Add(T Entity);
        public Task<T> Update(T Entity);
        public Task<T> Delete(int id);
    }
}

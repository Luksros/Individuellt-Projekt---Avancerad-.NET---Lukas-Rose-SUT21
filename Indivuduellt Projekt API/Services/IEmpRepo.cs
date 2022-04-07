using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indivuduellt_Projekt_API.Services
{
    public interface IEmpRepo<T>
    {
        public Task<IEnumerable> GetAll();
        public Task<T> Get(int id);
        public Task<T> Add(T Entity);
        public Task<T> Update(T Entity);
        public Task<T> Delete(int id);
        public Task<T> GetWithReport(int id);
        public Task<IEnumerable> EmployeesInProjects(int id);
        public Task<int> HoursByWeek(int id, int week);
    }
}

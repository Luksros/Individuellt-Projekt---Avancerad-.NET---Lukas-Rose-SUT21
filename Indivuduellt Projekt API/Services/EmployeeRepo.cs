using Individuellt_Projekt___Avancerad_.NET___Lukas_Rose_SUT21;
using Indivuduellt_Projekt_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indivuduellt_Projekt_API.Services
{
    public class EmployeeRepo : IEmpRepo<Employee>
    {
        private IPDbContext context { get; set; }
        public EmployeeRepo(IPDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable> GetAll()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee> Get(int id)
        {
            return await context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> GetWithReport(int id)
        {
            return await context.Employees.Include(e => e.TimeReports).ThenInclude(t => t.Project).FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<int> HoursByWeek(int id, int week)
        {
            var collection = await context.TimeReports.Where(e => e.Week == week && e.EmployeeId == id).ToListAsync();
            return collection.Sum(e => e.WorkHours);
        }

        public async Task<Employee> Add(Employee Entity)
        {
            await context.Employees.AddAsync(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }

        public async Task<Employee> Update(Employee Entity)
        {
            Employee empToUpdate = await context.Employees.FirstOrDefaultAsync(e => e.Id == Entity.Id);
            if (empToUpdate != null)
            {
                empToUpdate.FName = Entity.FName;
                empToUpdate.LName = Entity.LName;
                empToUpdate.Title = Entity.Title;
                await context.SaveChangesAsync();
                return empToUpdate;
            }
            return null;
        }

        public async Task<Employee> Delete(int id)
        {
            Employee empToDelete = await context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (empToDelete != null)
            {
                context.Employees.Remove(empToDelete);
                await context.SaveChangesAsync();
                return empToDelete;
            }
            return null;
        }
        public async Task<IEnumerable> EmployeesInProjects(int id)
        {
            return await context.TimeReports.Include(x => x.Project).Include(t => t.Employee).Where(r => r.ProjectId == id).Select(x => x.Employee).Distinct().ToListAsync();         
        }
    }
}

using Individuellt_Projekt___Avancerad_.NET___Lukas_Rose_SUT21;
using Indivuduellt_Projekt_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indivuduellt_Projekt_API.Services
{
    public class TimeRepo : IRepo<TimeReport>
    {
        private IPDbContext context { get; set; }
        public TimeRepo(IPDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable> GetAll()
        {
            return await context.TimeReports.ToListAsync();
        }

        public async Task<TimeReport> Get(int id)
        {
            return await context.TimeReports.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TimeReport> Add(TimeReport Entity)
        {
            await context.TimeReports.AddAsync(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }

        public async Task<TimeReport> Update(TimeReport Entity)
        {
            TimeReport repToUpdate = await context.TimeReports.FirstOrDefaultAsync(e => e.Id == Entity.Id);
            if (repToUpdate != null)
            {
                repToUpdate.Week = Entity.Week;
                repToUpdate.WorkHours = Entity.WorkHours;
                await context.SaveChangesAsync();
                return repToUpdate;
            }
            return null;
        }

        public async Task<TimeReport> Delete(int id)
        {
            TimeReport repToDelete = await context.TimeReports.FirstOrDefaultAsync(e => e.Id == id);
            if (repToDelete != null)
            {
                context.TimeReports.Remove(repToDelete);
                await context.SaveChangesAsync();
                return repToDelete;
            }
            return null;
        }
        
    }
}

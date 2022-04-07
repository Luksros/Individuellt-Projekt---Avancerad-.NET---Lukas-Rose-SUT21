using Individuellt_Projekt___Avancerad_.NET___Lukas_Rose_SUT21;
using Indivuduellt_Projekt_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Threading.Tasks;

namespace Indivuduellt_Projekt_API.Services
{
    public class ProjectRepo : IRepo<Project>
    {
        private IPDbContext context { get; set; }
        public ProjectRepo(IPDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable> GetAll()
        {
            return await context.Projects.ToListAsync();
        }

        public async Task<Project> Get(int id)
        {
            return await context.Projects.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Project> Add(Project Entity)
        {
            await context.Projects.AddAsync(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }

        public async Task<Project> Update(Project Entity)
        {
            Project projToUpdate = await context.Projects.FirstOrDefaultAsync(e => e.Id == Entity.Id);
            if (projToUpdate != null)
            {
                projToUpdate.ProjectName = Entity.ProjectName;
                await context.SaveChangesAsync();
                return projToUpdate;
            }
            return null;
        }

        public async Task<Project> Delete(int id)
        {
            Project projToDelete = await context.Projects.FirstOrDefaultAsync(e => e.Id == id);
            if (projToDelete != null)
            {
                context.Projects.Remove(projToDelete);
                await context.SaveChangesAsync();
                return projToDelete;
            }
            return null;
        }
    }
}

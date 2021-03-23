using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fileManagerTaskAPI.Models.fileManagerRepository
{
    public class fileManagerRepository : IfileManagerRepository
    {
        private readonly fileManagerDbContext dbContext;

        public fileManagerRepository(fileManagerDbContext context)
        {
            this.dbContext = context;
        }
        public async Task<fileManager> add(fileManager file)
        {
            dbContext.fileManagers.Add(file);
            await dbContext.SaveChangesAsync();

            return file;
        }

        public async Task<IEnumerable<fileManager>> GetFilesData()
        {
            return await dbContext.fileManagers.OrderBy(x => x.CreatationDate).ToListAsync();
        }
    }
}

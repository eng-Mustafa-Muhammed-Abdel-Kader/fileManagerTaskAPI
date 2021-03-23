using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fileManagerTaskAPI.Models
{
    public class fileManagerDbContext : DbContext
    {
        public fileManagerDbContext(DbContextOptions<fileManagerDbContext> options) : base(options)
        {

        }

        public DbSet<fileManager> fileManagers { get; set; }
    }
}

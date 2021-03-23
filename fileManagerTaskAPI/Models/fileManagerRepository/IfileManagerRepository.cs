using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fileManagerTaskAPI.Models.fileManagerRepository
{
    public interface IfileManagerRepository
    {
        Task<IEnumerable<fileManager>> GetFilesData();
        Task<fileManager> add(fileManager file);
    }
}

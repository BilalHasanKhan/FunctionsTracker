using System;
using System.Linq;
using TrackerModels.Models;

namespace TrackerRepositories.Interfaces
{
    public interface IRFCRepository
    {
        IQueryable<RFC> All { get; }
        RFC Find(int id);
        void InsertOrUpdate(RFC RFC);
        void Delete(int id);
        void Save();

    }
}

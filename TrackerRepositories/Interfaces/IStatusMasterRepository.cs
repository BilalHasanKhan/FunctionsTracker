using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;

namespace TrackerRepositories.Interfaces
{
    public interface IStatusRepository
    {
        IQueryable<StatusMaster> All { get; }

        StatusMaster Find(int id);
        StatusMaster Find(string name);
        void InsertOrUpdate(StatusMaster StatusMaster);
        void Delete(int id);
        void Save();

    }
}

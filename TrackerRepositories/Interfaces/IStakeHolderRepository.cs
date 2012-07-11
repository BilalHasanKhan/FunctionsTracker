using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels;
using TrackerModels.Models;

namespace TrackerRepositories.Interfaces
{
    public interface IStakeHolderRepository
    {
        IQueryable<StakeHolderMaster> All { get; }
        StakeHolderMaster GetByID(int ID);
        void Save();
        void Delete(int ID);
        void InsertOrUpdate(StakeHolderMaster item);
    }
}

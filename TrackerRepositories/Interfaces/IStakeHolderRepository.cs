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
        IQueryable<StakeHolderMaster> GetAll();
        StakeHolderMaster Get(int ID);
        StakeHolderMaster Add(StakeHolderMaster item);
        void Remove(int ID);
        bool Update(StakeHolderMaster item);
    }
}

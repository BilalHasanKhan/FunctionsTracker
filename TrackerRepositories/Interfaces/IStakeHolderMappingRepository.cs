using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using TrackerModels;
using TrackerModels.Models;

namespace TrackerRepositories.Interfaces
{
    public interface IStakeHolderMappingRepository
    {

        IQueryable<StakeHolderMapping> GetAll();
        StakeHolderMapping GetByACRID(int StakeholderID);
        StakeHolderMapping GetByStakeholderID(int ACRID);
        void InsertOrUpdate(StakeHolderMapping StakeHolderMapping);
        void Delete(int id);
        void Save();

    }
}

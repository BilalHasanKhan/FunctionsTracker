using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerRepositories.Repositories;
using TrackerModels.Context;
using TrackerModels.Models;
using TrackerRepositories.Interfaces;

namespace TrackerRepositories.Repositories
{
    public class StakeHolderMappingRepository : IStakeHolderMappingRepository
    {


        TrackerContext _context = new TrackerContext();

        StakeHolderMapping GetByACRID(int StakeholderID)
        {
            return _context.StakeHolderMapping.SingleOrDefault(c => c.StakeholderID == StakeholderID);

        }

        StakeHolderMapping GetByStakeholderID(int ACRID)
        {
            return _context.StakeHolderMapping.SingleOrDefault(c => c.ACRID == ACRID);
        }

        #region IStakeHolderMappingRepository Members

        StakeHolderMapping IStakeHolderMappingRepository.GetByACRID(int StakeholderID)
        {
            throw new NotImplementedException();
        }

        StakeHolderMapping IStakeHolderMappingRepository.GetByStakeholderID(int ACRID)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

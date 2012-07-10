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

        StakeHolderMapping GetByACRID(int StakeholderID);
        StakeHolderMapping GetByStakeholderID(int ACRID);

    }
}

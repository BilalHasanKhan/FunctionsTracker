using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerRepositories.Repositories;
using TrackerModels.Context;
using TrackerModels.Models;
using TrackerRepositories.Interfaces;
using System.Data;

namespace TrackerRepositories.Repositories
{
    public class StakeHolderMappingRepository : IStakeHolderMappingRepository
    {


        TrackerContext _context = new TrackerContext();

        StakeHolderMapping GetByACRID(int StakeholderID)
        {
            return _context.StakeHolderMapping.SingleOrDefault(c => c.StakeHolderID == StakeholderID);

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

        #region IStakeHolderMappingRepository Members

        IQueryable<StakeHolderMapping> IStakeHolderMappingRepository.GetAll()
        {
            return _context.StakeHolderMapping;
        }

        void IStakeHolderMappingRepository.InsertOrUpdate(StakeHolderMapping StakeHolderMapping)
        {
            if (StakeHolderMapping.MapID == default(int))
            {                // New entity
                _context.StakeHolderMapping.Add(StakeHolderMapping);
            }
            else
            {                // Existing entity
                _context.Entry(StakeHolderMapping).State = EntityState.Modified;
            }
        }

        void IStakeHolderMappingRepository.Delete(int id)
        {
            var SM = _context.StakeHolderMapping.Find(id);
            _context.StakeHolderMapping.Remove(SM);
        }

        void IStakeHolderMappingRepository.Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            { }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;
using TrackerRepositories.Interfaces;

namespace TrackerRepositories.Repositories
{
    class StakeHolderRepository : IStakeHolderRepository
    {
        private List<StakeHolderMaster> _StakeHolderMaster = new List<StakeHolderMaster>();
        private int _nextId = 1;


        IQueryable<StakeHolderMaster> GetAll()
        {
            return _StakeHolderMaster.AsQueryable();
        }

        StakeHolderMaster Get(int ID)
        {
            return _StakeHolderMaster.Find(c=>c.ID==ID);
        }

        StakeHolderMaster Add(StakeHolderMaster item)
        {
            item.ID = _nextId++;
            _StakeHolderMaster.Add(item);
            return item;        
        }

        void IStakeHolderRepository.Remove(int ID)
        {
             StakeHolderMaster SHD = _StakeHolderMaster.Find(c => c.ID == ID);
            _StakeHolderMaster.Remove(SHD);
        }

        bool Update(StakeHolderMaster item)
        {
            
            int index = _StakeHolderMaster.FindIndex(c=> c.ID == item.ID);
            if (index == -1)
            {
                return false;
            }
            _StakeHolderMaster.RemoveAt(index);
            _StakeHolderMaster.Add(item);
            return true;
            
        }

        #region IStakeHolderRepository Members

        IQueryable<StakeHolderMaster> IStakeHolderRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        StakeHolderMaster IStakeHolderRepository.Get(int ID)
        {
            throw new NotImplementedException();
        }

        StakeHolderMaster IStakeHolderRepository.Add(StakeHolderMaster item)
        {
            throw new NotImplementedException();
        }

        bool IStakeHolderRepository.Update(StakeHolderMaster item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

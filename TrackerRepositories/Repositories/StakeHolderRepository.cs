using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;
using TrackerModels.Context;
using TrackerRepositories.Interfaces;
using System.Data;

namespace TrackerRepositories.Repositories
{
    public class StakeHolderRepository : IStakeHolderRepository
    {
        TrackerContext _context = new TrackerContext();

        public IQueryable<StakeHolderMaster> All
        {
            get { return _context.StakeHolderMaster; }
        }

       public  StakeHolderMaster GetByID(int ID)
        {
            return _context.StakeHolderMaster.SingleOrDefault(c => c.ID == ID);
        }

     
        public void InsertOrUpdate(StakeHolderMaster StakeHolderMaster)
        {
            if (StakeHolderMaster.ID == default(int))
            {                // New entity
                _context.StakeHolderMaster.Add(StakeHolderMaster);
            }
            else
            {                // Existing entity
                _context.Entry(StakeHolderMaster).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var SM = _context.StakeHolderMaster.Find(id);
            _context.StakeHolderMaster.Remove(SM);
        }

       public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            { }
        }



      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;
using TrackerModels.Context;
using TrackerModels.Models;
using TrackerRepositories.Interfaces;

namespace TrackerRepositories.Repositories
{
  public  class IncidentMappingRepository : IIncidentRequestMapping
    {
      TrackerContext _context =new TrackerContext();
      
        public IQueryable<IncidentRequestMapping> All
        {
            get { return _context.IncidentRequestMapping; }
        }



        public IncidentRequestMapping Find(int id)
        {
            return _context.IncidentRequestMapping.Find(id);
        }

      //public IncidentRequestMapping Find(int no)
      //  {
      //      return _context.IncidentRequestMapping.Find(no);
      //  }

      //public IncidentRequestMapping Find(int appid)
      //  {
      //      return _context.IncidentRequestMapping.Find(appid);
      //  }

              
        public void InsertOrUpdate(IncidentRequestMapping IncidentRequestMapping)
        {
            if (IncidentRequestMapping.IncidentRequestId==default(int))
                {      
                // New entity
                _context.IncidentRequestMapping.Add(IncidentRequestMapping);
                
            }
            else
            {  
                // Existing entity
                _context.Entry(IncidentRequestMapping).State = EntityState.Modified;
             
               
                
            }
        }

        public void Delete(int id)
        {
            var IM = _context.IncidentRequestMapping.Find(id);
            _context.IncidentRequestMapping.Remove(IM);
            _context.IncidentRequestMapping.Remove(IM);
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

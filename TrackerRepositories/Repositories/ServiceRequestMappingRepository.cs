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
  public  class ServiceRequestMappingRepository : IServiceRequestMapping
    {
      TrackerContext _context =new TrackerContext();
      
        public IQueryable<ServiceRequestMapping> All
        {
            get { return _context.ServiceRequestMapping; }
        }



        public ServiceRequestMapping Find(int id)
        {
            return _context.ServiceRequestMapping.Find(id);
        }


        public void InsertOrUpdate(ServiceRequestMapping serviceRequestMapping)
        {
            if (serviceRequestMapping.RequestMappingId == default(int))
                {      
                // New entity
                    _context.ServiceRequestMapping.Add(serviceRequestMapping);
                
            }
            else
            {  
                // Existing entity
                _context.Entry(serviceRequestMapping).State = EntityState.Modified;
             
               
                
            }
        }

        public void Delete(int id)
        {
            var SM = _context.ServiceRequestMapping.Find(id);
            _context.ServiceRequestMapping.Remove(SM);
            
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

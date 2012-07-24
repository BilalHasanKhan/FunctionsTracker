using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;
using System.Web;
using TrackerModels.Context;
using TrackerModels.Models;
using TrackerRepositories.Interfaces;

namespace TrackerRepositories.Repositories
{
    public class ServerIPMappingRepository : IServerIPMappingRepsository
         {
        TrackerContext _context = new TrackerContext();
        public IQueryable<ServerIPMapping> All
        {
            get { return _context.ServerIPMappings; }
        }
        public IQueryable<ServerIPMapping> Allincluding(params Expression<Func<ServerIPMapping, object>>[] includeProperties)
        {

            IQueryable<ServerIPMapping> query = _context.ServerIPMappings;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
                
            }
            return query;
          
        }
        public ServerIPMapping Find(int Id)
        {
           return _context.ServerIPMappings.Find(Id);
        }
        public void InsertOrUpdate(ServerIPMapping ServerIPMapping)
        {
            if (ServerIPMapping.ID == default(int))
            {
                _context.ServerIPMappings.Add(ServerIPMapping);
            }
            else
            {
                _context.Entry(ServerIPMapping).State = EntityState.Modified;
            }
        }
        public void Delete(int Id)
        {
            var mapping = _context.ServerIPMappings.Find(Id);
            _context.ServerIPMappings.Remove(mapping);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

   
    }
      
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using TrackerRepositories.Interfaces;
using TrackerModels.Context;
using System.Data;
using System.Data.Entity;
using TrackerModels.Models;

namespace TrackerRepositories.Repositories
{
   public class ServerAppMappingRepository : IServerAppMappingRepository
    {
        TrackerContext _context = new TrackerContext();

        public IQueryable<ServerAppMapping> All
        {
            get { return _context.ServerAppMapping ; }
        }

        public IQueryable<ServerAppMapping> AllIncluding(params System.Linq.Expressions.Expression<Func<ServerAppMapping, object>>[] includeProperties)
        {
            IQueryable<ServerAppMapping> query = _context.ServerAppMapping;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);

            }

            return query;
        }

        public ServerAppMapping FindByAppId(int appId)
        {
            return _context.ServerAppMapping.Single(a => a.AppId == appId);
        }

        public List<ServerAppMapping> FindByServerId(int serverId)
        {
            return _context.ServerAppMapping.Where(a => a.ServerId == serverId).ToList();
        }

        public void InsertOrUpdate(ServerAppMapping serverAppMapping)
        {
           if(serverAppMapping.AppMappingId==default(int))
           {
               _context.ServerAppMapping.Add(serverAppMapping);

           }

           else
           {

               _context.Entry(serverAppMapping).State = EntityState.Modified;
           }
        }

        public void Delete(int id)
        {
            var mapping = _context.ServerAppMapping.Find(id);
            _context.ServerAppMapping.Remove(mapping);
        }

        public void Save()
        {
           _context.SaveChanges();
        }

      
    }
}

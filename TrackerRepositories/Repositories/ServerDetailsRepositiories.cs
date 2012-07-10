using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TrackerModels.Context;
using TrackerModels.Models;
using TrackerRepositories.Interfaces;

namespace TrackerRepositories.Repositories
{
    public class ServerDetailsRepositiories : IServerDetailsRepositiories
    {
        TrackerContext _context = new TrackerContext();
        public IQueryable<ServerDetails> All
        {
            get { return _context.ServerDetails; }
        }

        public IQueryable<ServerDetails> AllIncluding(params Expression<Func<ServerDetails, object>>[] includeProperties)
        {
            IQueryable<ServerDetails> query = _context.ServerDetails;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public ServerDetails FindByServerName(String ServerName)
        {

            return _context.ServerDetails.Single(s => s.ServerName.Equals(ServerName));
            
        }

        
        public void InsertOrUpdate(ServerDetails details)
        {
            if (details.ServerId == default(int))
            {

                _context.ServerDetails.Add(details);
            }

            else
            {
                _context.Entry(details).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var details = _context.ServerDetails.Find(id);
            _context.ServerDetails.Remove(details);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

  
}


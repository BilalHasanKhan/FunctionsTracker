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
   public class ACRRepository : IACRRepository
    {
        TrackerContext _context = new TrackerContext();

        public IQueryable<ACR> All
        {
            get { return _context.ACR ; }
        }

        public IQueryable<ACR> AllIncluding(params System.Linq.Expressions.Expression<Func<ACR, object>>[] includeProperties)
        {
           IQueryable<ACR> query = _context.ACR;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);

            }

            return query;
        }

        public List<ACR> FindByAppId(int appId)
        {
           return _context.ACR.Where(a => a.ApplicationId==appId).ToList();
        }

        public ACR FindByACRName(string acrName)
        {
            return _context.ACR.Single(a => a.ACR_Name==acrName);
        }

        public void InsertOrUpdate(ACR acr)
        {
           if(acr.ACRID==default(int))
           {
               _context.ACR.Add(acr);

           }

           else
           {

               _context.Entry(acr).State = EntityState.Modified;
           }
        }

        public void Delete(int id)
        {
           var acr =_context.ACR.Find(id);
            _context.ACR.Remove(acr);
        }

        public void Save()
        {
           _context.SaveChanges();
        }

      
    }
}

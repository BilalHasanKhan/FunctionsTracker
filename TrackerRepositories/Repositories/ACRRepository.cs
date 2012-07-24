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

        public string GetACRStatus(int acrId)
        {

            var result = from a in _context.ACR
                         join b in _context.StatusMaster on a.StatusId equals b.StatusId
                         where a.ACRID == acrId
                         select b.StatusName;

            return result.ToString();

        }

        public int GetNumberOfAssignees(int ACRId)
        {
            return (from a in _context.ACR
                    join m in _context.AssigneeMapping on a.ACRID equals m.ACRId
                    where a.ACRID == 1
                    select m.AssigneeMappingId
                    ).Count();

        }
        
        // Added By Sadaf
        public List<ACR> FindByStatusId(int statusId)
        {
            return _context.ACR.Where(a => a.StatusId == statusId).ToList();
        }


        public IList<ACR> FindAll()
        {
            return _context.ACR.ToList();
        }
      
       //Added By Monika
       public string GetACRSummary(int acrid)
        {
            var acrSummary = from a in _context.ACR
                             where a.ACRID == acrid
                             select a.Summary;

            return acrSummary.ToString();
        }

        public string ACRAssignedTo(int acrId)
        {
            var acrAssignedTo = from a in _context.ACR
                                join b in _context.Users on a.AssigneeMapping equals b.UserID
                                where a.ACRID == acrId
                                select b.FirstName;

            return acrAssignedTo.First().ToString();
        }
        //Added By Monika
      
    }
}

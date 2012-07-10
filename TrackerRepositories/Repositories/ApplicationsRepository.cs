using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;
using TrackerModels.Context;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data;
using TrackerRepositories.Interfaces;


namespace TrackerRepositories
{
    public class ApplicationsRepository : IApplicationsRepository
    {       
        TrackerContext _context = new TrackerContext();
        

        /// <summary>
        /// Returns IQueryable<Applications>
        /// </summary>
        
        public IQueryable<Applications> All
        {
            get { return _context.Applications; }
        }


        /// <summary>
        /// Include all Proerties
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns>IQueryable<Applications></returns>
        
        public IQueryable<Applications> AllIncluding(params Expression<Func<Applications, object>>[] includeProperties)
        {
            IQueryable<Applications> query = _context.Applications;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty); 
            }

            return query;
            
        }
        
        /// <summary>
        /// Finds Applications by AppId
        /// </summary>
        /// <param name="appId"></param>
        /// <returns> Applications</returns>
         
        public Applications FindByAppId(int appId)
        {
            return _context.Applications.SingleOrDefault(app => app.AppId == appId);
        }


        /// <summary>
        /// Finds Applications by AppName
        /// </summary>
        /// <param name="appName"></param>
        /// <returns>Applications</returns>
        public Applications FindByAppName(string appName)
        {
            return _context.Applications.SingleOrDefault(app => app.AppName == appName);
        }


        /// <summary>
        /// Insert or Update the changes
        /// </summary>
        /// <param name="applications"></param>
         
        public void InsertOrUpdate(Applications applications)
        { 
         if (applications.AppId == default(int)) 
         {
                
             // New entity                
             _context.Applications.Add(applications);            
         } 
         else 
         {
                
             // Existing entity                
             _context.Entry(applications).State = EntityState.Modified;            
             
         }
        
        }

        /// <summary>
        /// Performs Deletion
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id) 
        {
            var application = _context.Applications.Find(id);
            _context.Applications.Remove(application);
            
        }

        /// <summary>
        /// Save the changes
        /// </summary>
        public void Save() 
        { 
            try { _context.SaveChanges(); } 
            catch (Exception e) { } 
        }


    }


   
}


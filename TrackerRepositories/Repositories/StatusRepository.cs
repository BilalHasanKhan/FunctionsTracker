using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data;
using TrackerModels.Context;
using TrackerModels.Models;
using TrackerRepositories.Interfaces;

namespace TrackerRepositories
{
    public class StatusRepository : IStatusRepository
    {
        TrackerContext context = new TrackerContext();

        public IQueryable<StatusMaster> All
        {
            get { return context.StatusMaster.Where(i => i.IsActive); }
        }



        public StatusMaster Find(int id)
        {
            return context.StatusMaster.Find(id);
        }

        public StatusMaster Find(string name)
        {
            return context.StatusMaster.Find(name);
        }


        public void InsertOrUpdate(StatusMaster statusmaster)
        {
            if (statusmaster.StatusId == default(int))
            {                // New entity
                context.StatusMaster.Add(statusmaster);
            }
            else
            {                // Existing entity
                context.Entry(statusmaster).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var SM = context.StatusMaster.Find(id);
            context.StatusMaster.Remove(SM);
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            { }
        }
    }


   
}

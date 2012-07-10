using System;
using System.Collections.Generic;
using System.Linq;
using TrackerModels;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data;
using TrackerModels.Context;
using TrackerModels.Models;
using TrackerRepositories.Interfaces;

namespace TrackerRepositories.Repositories
{
    public class RFCRepository : IRFCRepository
    {
        TrackerContext _context = new TrackerContext();
        public IQueryable<RFC> All
        {
            get { return _context.RFC; }
        }

      
        public RFC Find(int id)
        {
           return _context.RFC.SingleOrDefault(r => r.RFCID == id);
        }

        public void InsertOrUpdate(RFC rfc)
        {
            if (rfc.RFCID == default(int))
            {
                //New Entity
                _context.RFC.Add(rfc);
            }
            else
            {
                _context.Entry(rfc).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var rfc = _context.RFC.SingleOrDefault(r => r.RFCID==id);
            _context.RFC.Remove(rfc);
        }

        public void Save()
        {
            _context.SaveChanges();

        }
    }


}
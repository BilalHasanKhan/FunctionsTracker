using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Context;
using TrackerModels.Models;
using System.Linq.Expressions;
using TrackerRepositories.Interfaces;
using System.Data;
using System.Data.Entity;


namespace TrackerRepositories.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        TrackerContext _context = new TrackerContext();
        public IQueryable<DocumentAttachment> All
        {
            get
            {
                return _context.DocumentAttachment;
            }
        }

        public IQueryable<DocumentAttachment> AllIncluding(params System.Linq.Expressions.Expression<Func<DocumentAttachment, object>>[] includeProperties)
        {
            IQueryable<DocumentAttachment> query = _context.DocumentAttachment;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;

        }

        public DocumentAttachment Find(int id)
        {
            return _context.DocumentAttachment.Find(id);
        }

        public void InsertOrUpdate(DocumentAttachment docattach)
        {
            //ToDo Context initialization

            if (docattach.DocAttachId == default(int))
            {
                // New entity

                _context.DocumentAttachment.Add(docattach);

            }
            else
            {
                // Update existing entity
                _context.Entry(docattach).State = EntityState.Modified;

            }


        }

        public void Delete(int id)
        {
            var docattach = _context.DocumentAttachment.Find(id);
            _context.DocumentAttachment.Remove(docattach);

        }

        public void Save()
        {
            _context.SaveChanges();

        }
    }
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;
using System.Linq.Expressions;

namespace TrackerRepositories.Interfaces
{
    public interface IAttachmentRepository
    {
        IQueryable<DocumentAttachment> All { get; }
        IQueryable<DocumentAttachment> AllIncluding(params Expression<Func<DocumentAttachment, object>>[] includeProperties);
        DocumentAttachment Find(int id);
        void InsertOrUpdate(DocumentAttachment attachment);
        void Delete(int id);
        void Save();

    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;
using System.Linq.Expressions;

namespace TrackerRepositories.Interfaces
{
    public interface IServerDetailsRepositiories
    {
        IQueryable<ServerDetails> All { get; }
        IQueryable<ServerDetails> AllIncluding(params Expression<Func<ServerDetails, object>>[] includeProperties);
        ServerDetails FindByServerName(string ServerName);
        void InsertOrUpdate(ServerDetails details);
        void Delete(int id);
        void Save();
    }
}

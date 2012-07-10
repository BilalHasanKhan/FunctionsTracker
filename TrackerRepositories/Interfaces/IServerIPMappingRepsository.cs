using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using TrackerModels.Models;

namespace TrackerRepositories.Interfaces
{
    public interface IServerIPMappingRepsository
    {
         IQueryable<ServerIPMapping> All { get; }
         IQueryable<ServerIPMapping> Allincluding(params Expression<Func<ServerIPMapping, object>>[] includeProperties);
         ServerIPMapping Find(int id);
         void InsertOrUpdate(ServerIPMapping serverIPMapping);
         void Delete(int id);
         void Save();

    }
}
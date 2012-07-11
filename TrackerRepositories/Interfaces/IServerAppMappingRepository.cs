using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;
using System.Linq.Expressions;

namespace TrackerRepositories.Interfaces
{
    public interface IServerAppMappingRepository
    {
        IQueryable<ServerAppMapping> All { get; }
        IQueryable<ServerAppMapping> AllIncluding(params Expression<Func<ACR, object>>[] includeProperties);
        ServerAppMapping FindByAppId(int appId);
        List<ServerAppMapping> FindByServerId(int ServerId);
        void InsertOrUpdate(ServerAppMapping serverAppMapping);
        void Delete(int id);
        void Save();
    }
}

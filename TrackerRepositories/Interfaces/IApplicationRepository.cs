using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;
using System.Linq.Expressions;

namespace TrackerRepositories.Interfaces
{
    public interface IApplicationsRepository
    {
        IQueryable<Applications> All { get; }
        IQueryable<Applications> AllIncluding(params Expression<Func<Applications, object>>[] includeProperties);
        Applications FindByAppId(int appId);
        Applications FindByAppName(string appName);
        void InsertOrUpdate(Applications application);
        void Delete(int id);
        void Save();

    }
}

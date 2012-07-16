using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;
using System.Linq.Expressions;

namespace TrackerRepositories.Interfaces
{
    public interface IACRRepository
    {
        IQueryable<ACR> All { get; }
        IQueryable<ACR> AllIncluding(params Expression<Func<ACR, object>>[] includeProperties);
        List<ACR> FindByAppId(int appId);
        ACR FindByACRName(string acrName);
        string GetACRStatus(int acrId);
        void InsertOrUpdate(ACR application);
        void Delete(int id);
        void Save();
    }
}

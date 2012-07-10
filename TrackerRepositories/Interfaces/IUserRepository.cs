using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TrackerModels;
using System.Linq.Expressions;
using TrackerModels.Models;

namespace TrackerRepositories.Interfaces
{
    public interface IUsersReporsitory
    {
        
        IQueryable<Users> All { get; }
        IQueryable<Users> AllIncluding(params Expression<Func<Users, object>>[] includeProperties);
        Users Find(int id);
        Users FindByEmpID(int EmpId);
        void InsertOrUpdate(Users user);
        void Delete(int id);
        void Save();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;
using TrackerRepositories.Interfaces;
using TrackerModels.Context;
using TrackerModels.Models;


namespace TrackerRepositories
{
   
        public class UserRepository : IUsersReporsitory
        {
            //private List<Users> _UserDetails = new List<Users>();
            //private int _nextId = 1;

            TrackerContext context=new TrackerContext();
            
            public IQueryable<Users> All
            {
                get { return context.Users; }
                    //.All(u => u.IsActive==true) a; }
            }

            public IQueryable<Users> AllIncluding(params Expression<Func<Users, object>>[] includeProperties)
            {
                IQueryable<Users> query = context.Users; 
                foreach (var includeProperty in includeProperties) 
                { 
                    query = query.Include(includeProperty);
                } 
                return query;
            }

            public Users Find(int id)
            {
                return context.Users.Find(id);
            }

            public Users FindByEmpID(int EmpId)
            {
                return context.Users.SingleOrDefault(u => u.EmpID == EmpId);
            }

            public void InsertOrUpdate(Users user)
            {
                if (user.UserID == default(int))
                {                
                    // New entity                
                    context.Users.Add(user);  
                } else
                {             
                    // Existing entity           
                    context.Entry(user).State = EntityState.Modified;    
                }
            }

            public void Delete(int Userid)
            {
                var user = context.Users.Find(Userid); 
                context.Users.Remove(user);
            }

            public void Save()
            {
                try
                {
                    context.SaveChanges();
                }
                catch(Exception e)
                {
                }
            }
        }
}

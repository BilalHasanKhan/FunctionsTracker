using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;

namespace TrackerRepositories.Interfaces
{

    public interface IIncidentRequestMapping
    {
        IQueryable<IncidentRequestMapping> All { get; }
        IncidentRequestMapping Find(int id);
        //IncidentRequestMapping Find(int no);
        //IncidentRequestMapping Find(int appid);
        void InsertOrUpdate(IncidentRequestMapping IncidentRequestMapping);
        void Delete(int id);
        void Save();

    }
}

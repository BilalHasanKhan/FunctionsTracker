using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerModels.Models;

namespace TrackerRepositories.Interfaces
{

    public interface IServiceRequestMapping
    {
        IQueryable<ServiceRequestMapping> All { get; }
        ServiceRequestMapping Find(int id);
        void InsertOrUpdate(ServiceRequestMapping IncidentRequestMapping);
        void Delete(int id);
        void Save();

    }
}

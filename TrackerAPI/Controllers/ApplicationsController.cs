using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackerRepositories.Interfaces;
using TrackerModels.Models;

namespace FunctionsTrackerAPI.Controllers
{
    public class ApplicationsController : ApiController
    {

        private readonly IApplicationsRepository _applicationsRepository;

        public ApplicationsController(IApplicationsRepository applicationRepository)
        {
            this._applicationsRepository = applicationRepository;

        }

        // GET api/applications
        public IQueryable<Applications> Get()
        {
            return _applicationsRepository.All;
        }

        // GET api/applications/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/applications
        public void Post(string value)
        {
        }

        // PUT api/applications/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/applications/5
        public void Delete(int id)
        {
        }
    }
}

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
    public class ACRController : ApiController
    {
        private readonly IACRRepository _acrRepository;

        public ACRController(IACRRepository acrRepository)
        {

            _acrRepository = acrRepository;

        }

    
        public IList<ACR> GetAcrByApplicationId(int applicationId)
        {
            return _acrRepository.FindByAppId(applicationId);
        }

       
        public ACR Get(string acrName)
        {
            return _acrRepository.FindByACRName(acrName);
        }

        
        public void Post(string value)
        {
        }

        
        public void Put(int id, string value)
        {
        }

        
        public void Delete(int id)
        {
        }
    }
}
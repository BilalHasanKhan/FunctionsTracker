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
            try
            {
                return _acrRepository.FindByAppId(applicationId);
            }

            catch (HttpResponseException h)
            {
                var messgae = h.Message;
                return new List<ACR>();
            }
        }

           
        public ACR GetACRByName(string acrName)
        {
            return _acrRepository.FindByACRName(acrName);
        }

        [HttpPost]
        public  HttpResponseMessage PostNewACR(ACR acr)
        {

            try
                {

                _acrRepository.InsertOrUpdate(acr);
                _acrRepository.Save();
                }

                catch(HttpResponseException ex)
                {

                    return Request.CreateResponse(HttpStatusCode.Conflict,acr);
                }

            
            var response = Request.CreateResponse<ACR>(HttpStatusCode.Created, acr);
            string uri = "/Tracker/ACR?acrName="+acr.ACR_Name;
            response.Headers.Location = new Uri(Request.RequestUri,uri);

            return response;
    }

        
        public HttpResponseMessage Put(int Id, ACR acr)
        {
            _acrRepository.InsertOrUpdate(acr);
            _acrRepository.Save();

            var response = Request.CreateResponse<ACR>(HttpStatusCode.Accepted, acr);
            string uri = "/Tracker/ACR?acrName=" + acr.ACR_Name;
            response.Headers.Location = new Uri(Request.RequestUri, uri);

            return response;

        }

        
        public void Delete(int id)
        {
        }
    }
}
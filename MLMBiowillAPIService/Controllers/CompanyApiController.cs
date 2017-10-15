using MLMBiowillBusinessEntities;
using MLMBiowillBusinessEntities.Common;
using MLMBiowillBusinesslogic.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MLMBiowillAPIService.Controllers
{
    public class CompanyApiController : ApiController
    {
        CompanyManager _CompManager;

        public CompanyApiController()
        {
            _CompManager = new CompanyManager();
        }
        // GET: api/CompanyApi
        [HttpGet]
        [Route("api/CompanyApi")]
        public HttpResponseMessage Get()
        {
            PaginationInfo Pager = new PaginationInfo();
            var companyDet = _CompManager.Get_CompanyMasters(ref Pager);
            if (companyDet != null && companyDet.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, companyDet);
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound
                                    , "No Company Details found");
        }

        // GET: api/CompanyApi/5
        [HttpGet]
        [Route("api/CompanyApi/{id:int}")]
        public HttpResponseMessage Get(int id)
        {                                                          
            var companyDet = _CompManager.Get_CompanyMaster_By_Id(id);
            if (companyDet != null)
                return Request.CreateResponse(HttpStatusCode.OK,companyDet);
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound
                                    , "Company Id does not Exists in Database");
        }

        // POST: api/CompanyApi
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/CompanyApi/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/CompanyApi/5
        public void Delete(int id)
        {

        }
    }
}

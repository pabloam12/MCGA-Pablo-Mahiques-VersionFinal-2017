using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using ASF.Business;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.Services.Http
{
    [RoutePrefix("rest/Client")]
    public class ClientServices : ApiController
    {

        [HttpPost]
        [Route( "Add" )]
        public Client Add ( Client Client )
        {
            try
            {
                //instancia de la business
                var bc = new ClientBusiness();
                return bc.Add( Client );
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException( httpError );
            }
        }

        [HttpGet]
        [Route( "All" )]
        public AllResponse All ()
        {
            try
            {
                var response = new AllResponse();
                var bc = new ClientBusiness();
                response.ResultClient = bc.All();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException( httpError );
            }
        }

        [HttpPost]
        [Route( "Edit" )]
        public void Edit ( Client Client )
        {
            try
            {
                var bc = new ClientBusiness();
                bc.Edit( Client );
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException( httpError );
            }
        }

        [HttpGet]
        [Route( "Find" )]
        public FindResponse Find ( int id )
        {
            try
            {
                var response = new FindResponse();
                var bc = new ClientBusiness();
                response.ResultClient = bc.Find( id );
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException( httpError );
            }
        }

        [HttpGet]
        [Route( "Remove/{id}" )]
        public void Remove ( int id )
        {
            try
            {
                var bc = new ClientBusiness();
                bc.Remove( id );
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException( httpError );
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using ASF.Business;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.Services.Http
{
    [RoutePrefix( "rest/Order" )]
    public class OrderServices : ApiController
    {

        [HttpPost]
        [Route( "Add" )]
        public Order Add ( Order Order )
        {
            try
            {
                //instancia de la business
                var bc = new OrderBusiness();
                return bc.Add( Order );
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
                var bc = new OrderBusiness();
                response.ResultOrder = bc.All();
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
        public void Edit ( Order Order )
        {
            try
            {
                var bc = new OrderBusiness();
                bc.Edit( Order );
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
                var bc = new OrderBusiness();
                response.ResultOrder = bc.Find( id );
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
                var bc = new OrderBusiness();
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

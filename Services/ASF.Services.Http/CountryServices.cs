using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASF.Business;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.Services.Http
{
        /// <summary>
        /// Country HTTP service controller.
        /// </summary>
        [RoutePrefix("rest/Country")]
        public class CountryService : ApiController
        {
            [HttpPost]
            [Route("Add")]
            public Country Add(Country Country)
            {
                try
                {
                    //instancia de la business
                    var bc = new CountryBusiness();
                    return bc.Add(Country);
                }
                catch (Exception ex)
                {
                    var httpError = new HttpResponseMessage()
                    {
                        StatusCode = (HttpStatusCode)422,
                        ReasonPhrase = ex.Message
                    };

                    throw new HttpResponseException(httpError);
                }
            }

            [HttpGet]
            [Route("All")]
            public AllResponse All()
            {
                try
                {
                    var response = new AllResponse();
                    var bc = new CountryBusiness();
                    response.ResultCountry = bc.All();
                    return response;
                }
                catch (Exception ex)
                {
                    var httpError = new HttpResponseMessage()
                    {
                        StatusCode = (HttpStatusCode)422,
                        ReasonPhrase = ex.Message
                    };

                    throw new HttpResponseException(httpError);
                }
            }
            
            [HttpPost]
            [Route("Edit")]
            public void Edit(Country Country)
            {
                try
                {
                    var bc = new CountryBusiness();
                    bc.Edit(Country);
                }
                catch (Exception ex)
                {
                    var httpError = new HttpResponseMessage()
                    {
                        StatusCode = (HttpStatusCode)422,
                        ReasonPhrase = ex.Message
                    };

                    throw new HttpResponseException(httpError);
                }
            }

            [HttpGet]
            [Route("Find")]
            public FindResponse Find(int id)
            {
                try
                {
                    var response = new FindResponse();
                    var bc = new CountryBusiness();
                    response.ResultCountry = bc.Find(id);
                    return response;
                }
                catch (Exception ex)
                {
                    var httpError = new HttpResponseMessage()
                    {
                        StatusCode = (HttpStatusCode)422,
                        ReasonPhrase = ex.Message
                    };

                    throw new HttpResponseException(httpError);
                }
            }

            [HttpGet]
            [Route("Remove/{id}")]
            public void Remove(int id)
            {
                try
                {
                    var bc = new CountryBusiness();
                    bc.Remove(id);
                }
                catch (Exception ex)
                {
                    var httpError = new HttpResponseMessage()
                    {
                        StatusCode = (HttpStatusCode)422,
                        ReasonPhrase = ex.Message
                    };

                    throw new HttpResponseException(httpError);
                }
            }
        }
    }

